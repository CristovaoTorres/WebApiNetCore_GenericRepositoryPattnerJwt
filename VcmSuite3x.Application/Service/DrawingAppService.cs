using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VcmSuite3x.Application.Interface;
using VcmSuite3x.Application.Model;
using VcmSuite3x.Application.ViewModel;
using VcmSuite3x_api.Core;
using VcmSuite3x_api.Core.Interface;
using VcmSuite3x_api.Core.Models;
using static VcmSuite3x_api.Core.Repository.UnitOfWork;


namespace VcmSuite3x.Application.Service
{
    public class DrawingAppService : IDrawingAppService
    {
        private readonly IUnitOfWork _unitOfw;

        public DrawingAppService(IUnitOfWork unitOfw)
        {
            _unitOfw = unitOfw;

        }

        public GraphLinksModel CreateFluxograma(int fluxogramaId, int topologia, FluxogramaTipo tipoFluxograma)
        {

            return new GraphLinksModel
            {
                NodeDataArray = pr_VCM_NoDrawingSelect(fluxogramaId),
                LinkDataArray = pr_VCM_CorrenteDrawingSelect(fluxogramaId),
                Erros = Validate(tipoFluxograma, topologia)
            };
        }

        public List<DiagramaLinkModel> pr_VCM_CorrenteDrawingSelect(Int32 fluxogramaId)
        {
            using (var context = new VCMContext())
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = string.Format("exec [pr_VCM_CorrenteDrawingSelect] {0}", fluxogramaId);
                context.Database.OpenConnection();

                List<DiagramaLinkModel> diagramaLinkModels = new List<DiagramaLinkModel>();
                using (var rdr = command.ExecuteReader())
                {
                    Int32 ordId = rdr.GetOrdinal("Id");
                    Int32 ordCodigo = rdr.GetOrdinal("Codigo");
                    Int32 ordEntradaId = rdr.GetOrdinal("EntradaId");
                    Int32 ordEntradaCodigo = rdr.GetOrdinal("EntradaCodigo");
                    Int32 ordSaidaId = rdr.GetOrdinal("SaidaId");
                    Int32 ordSaidaCodigo = rdr.GetOrdinal("SaidaCodigo");
                    Int32 ordModalId = rdr.GetOrdinal("ModalId");
                    Int32 ordPortaEntradaIndex = rdr.GetOrdinal("PortaEntradaIndex");
                    Int32 ordPortaSaidaIndex = rdr.GetOrdinal("PortaSaidaIndex");

                    while (rdr.Read())
                    {
                        diagramaLinkModels.Add(
                        new DiagramaLinkModel
                        {
                            Key = rdr.GetInt32(ordId),
                            Code = rdr.GetString(ordCodigo),
                            From = rdr.GetInt32(ordEntradaId),
                            To = rdr.GetInt32(ordSaidaId),
                            ToPort = ((PortSpot)rdr.GetInt32(ordPortaSaidaIndex)).ToString().ToLower(),
                            EntradaIndex = rdr.GetInt32(ordPortaEntradaIndex),
                            FromPort = ((PortSpot)rdr.GetInt32(ordPortaEntradaIndex)).ToString().ToLower(),
                            SaidaIndex = rdr.GetInt32(ordPortaSaidaIndex),
                            Color = rdr.IsDBNull(ordModalId) ? ((ModalColor)0).ToString() : ((ModalColor)rdr.GetInt32(ordModalId)).ToString(),

                        });
                    }
                }

                return diagramaLinkModels;
            }
        }

        public List<Drawing> pr_VCM_NoDrawingSelect(Int32 fluxogramaId)
        {
            try
            {
                List<Drawing> drawingList = (from nd in _unitOfw.NoDrawingRepository.Get()

                                             join n in _unitOfw.NoRepository.Get() on nd.NoId equals n.Id

                                             join te in _unitOfw.TipoEntidadeRepository.Get() on n.TipoEntidadeId equals te.Id

                                             join ndc in _unitOfw.NoDrawingRepository.Get() on new { a = n.Id, b = nd.Conector, c = Convert.ToBoolean(0) } equals new { a = ndc.NoId, b = Convert.ToBoolean(1), c = ndc.Conector } into x
                                             from ndcc in x.DefaultIfEmpty()

                                             join fd in _unitOfw.FluxogramaDrawingRepository.Get() on new { a = ndcc.FluxogramaId } equals new { a = fd.Id } into y
                                             from fdd in y.DefaultIfEmpty()
                                             where nd.FluxogramaId == fluxogramaId
                                             select new Drawing
                                             {
                                                 Key = n.Id,
                                                 Code = string.IsNullOrWhiteSpace(fdd.Nome) ? n.Codigo : $"{n.Codigo} : {fdd.Nome}",
                                                 Categoria = te.Prefixo,
                                                 CoordenadaX = nd.CoordenadaX,
                                                 CoordenadaY = nd.CoordenadaY,

                                             }).ToList();

                return drawingList;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public List<string> Validate(FluxogramaTipo tipoFluxograma, int topologiaId)
        {
            List<string> validateErrors = new List<string>();

            if (_unitOfw.ProdutoRepository.Get(y => y.TopologiaId == topologiaId).Count() == 0)
                validateErrors.Add("Não há Produto para a topologia em uso.");

            if (_unitOfw.PeriodoRepository.Get(y => y.TopologiaId == topologiaId).Count() == 0)
                validateErrors.Add("Não há Período para a topologia em uso.");

            if (tipoFluxograma == FluxogramaTipo.Cenario)
            {
                if (_unitOfw.EstadoRepository.Get(y => y.TopologiaId == topologiaId).Count() == 0)
                    validateErrors.Add("Não há Estado para a topologia em uso.");

                if (_unitOfw.ContratoRepository.Get(y => y.TopologiaId == topologiaId
                                                    && y.TipoEntidade.Nome == "TakeOrPay"
                                                    && y.TipoEntidade.Nome == "VendaFamilia"
                                                    && y.TipoEntidade.Nome == "VendaProduto").Count() == 0)
                    validateErrors.Add("Não há TakeOrPay e/ou VendaFamilia para a topologia em uso.");



                var correntes = _unitOfw.CorrenteRepository.Get(y => y.TopologiaId == topologiaId).ToList();
                var correnteNaoContemProduto = correntes.Where(x => !_unitOfw.CorrenteProdutoRepository.Get().Select(y => y.CorrenteId).Contains(x.Id)).ToList();
                if (correnteNaoContemProduto.Count() > 0)
                {
                    var elementos = correnteNaoContemProduto.Select(y => y.Codigo).Join(",");
                    string msg = correnteNaoContemProduto.Count > 1 ? $"Os elementos {elementos} não contém produtos." : $"O elemento {elementos} não contém produtos.";

                    validateErrors.Add(msg);

                }

                // 1. Verifica se existem contratos por produto cadastrados na Topologia

                if (_unitOfw.ContratoRepository.Get(y => y.TopologiaId == topologiaId && y.TipoEntidade.Nome == "VendaProduto").Count() > 0)
                {
                    //Continuar fazendo a validação da classe MercadoContratoValidation linha 48
                }



            }



            return validateErrors;

        }
    }
}
