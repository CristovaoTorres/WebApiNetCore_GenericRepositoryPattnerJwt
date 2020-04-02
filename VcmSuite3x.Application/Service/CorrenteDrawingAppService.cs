using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VcmSuite3x.Application.Interface;
using VcmSuite3x_api.Core.Interface;
using VcmSuite3x_api.Core.Models;

namespace VcmSuite3x.Application.Service
{
    public class CorrenteDrawingAppService : ICorrenteDrawingAppService
    {

        public CorrenteDrawingAppService(IUnitOfWork unitOfWork)
        {
            _unitOfw = unitOfWork;
        }

        private readonly IUnitOfWork _unitOfw;

        public int Register(out string code, int portaEntradaIndex, int portaEntradaId, int portaSaidaIndex, int portaSaidaId, int fluxogramaId)
        {
            int portaEntradaIdOut = _unitOfw.PortaDrawingRepository.Get(y => y.NoId == portaEntradaId && y.FluxogramaId == fluxogramaId
                                                                               && y.Index == portaEntradaIndex).FirstOrDefault().Id;

            int portaSaidaIdOut = _unitOfw.PortaDrawingRepository.Get(y => y.NoId == portaSaidaId && y.FluxogramaId == fluxogramaId
                                                                  && y.Index == portaSaidaIndex).FirstOrDefault().Id;

            int TopologiaId = _unitOfw.FluxogramaDrawingRepository.Get(y => y.Id == fluxogramaId).FirstOrDefault().TopologiaId;

            string codigo = string.Empty;
            int correnteId = Pr_CorrenteInsert(ref codigo, TopologiaId, portaEntradaId, portaSaidaId, null, null, null);
            code = codigo;

            CorrenteDrawingSave(correnteId, portaEntradaIdOut, portaSaidaIdOut, fluxogramaId);

            #region
            //var innerGroupJoinQuery2 =
            //from n in _unitOfw.NoDrawingRepository.Get()
            //join nD in _unitOfw.NoDrawingRepository.Get()
            //on n.NoId equals nD.NoId
            //where n.Conector == true && n.FluxogramaId == fluxogramaId
            //&& (n.NoId == portaEntradaId || n.NoId == portaSaidaId)
            //&& nD.Conector == false
            //select new
            //{
            //    noId = n.NoId == portaEntradaId ? portaSaidaId :
            //    n.NoId == portaSaidaId ? portaEntradaId : new int(),
            //    ConnectorId = n.NoId,
            //    FluxogramaDestinoId = nD.FluxogramaId
            //};

            //var retorno = innerGroupJoinQuery2.ToList();
            //if (retorno.Count > 0)
            //{

            //}

            #endregion
            //Cadastro dos produtos do No de Origem na Corrente
            InsertCorrenteProduto(portaEntradaId, correnteId);

            //Cadastro dos produtos do No de Origem no No de Destino
            InsertNoProduto(portaSaidaId, portaEntradaId);

            return correnteId;
        }

        private int Fn_find_NovoCodigoByNome(string nome, int topologiaId, ref string codigo)
        {
            int tipoEntidadeId;
            string prefixo, novoCodigo = string.Empty;

            TipoEntidade tipoentidade = _unitOfw.TipoEntidadeRepository.Get(y => y.Nome == nome).FirstOrDefault();

            tipoEntidadeId = tipoentidade.Id;
            prefixo = tipoentidade.Prefixo;

            if (!string.IsNullOrEmpty(prefixo))
                novoCodigo = _unitOfw.Fn_get_CodigoByTipoEntidadeId(tipoEntidadeId, topologiaId, prefixo);

            codigo = novoCodigo;
            return tipoEntidadeId;
        }

        private int Pr_CorrenteInsert(ref string codigo, int topologiaId, int entradaId, int saidaId, string nota = null, int? modalId = null, string descricao = null)
        {
            try
            {
                int tipoEntidadeId = 0;

                if (string.IsNullOrEmpty(codigo))
                    tipoEntidadeId = Fn_find_NovoCodigoByNome("Corrente", topologiaId, ref codigo);

                else
                    tipoEntidadeId = _unitOfw.TipoEntidadeRepository.Get(y => y.Nome == "Corrente").FirstOrDefault().Id;

                Corrente corrente = new Corrente
                {
                    Codigo = codigo,
                    Descricao = descricao,
                    TipoEntidadeId = tipoEntidadeId,
                    TopologiaId = topologiaId,
                    ModalId = modalId,
                    Nota = nota,
                    EntradaId = entradaId,
                    SaidaId = saidaId
                };

                _unitOfw.CorrenteRepository.Insert(corrente);
                return corrente.Id;
            }
            catch (Exception ex)
            {
                return 0;
                throw;
            }
        }

        private void InsertCorrenteProduto(int portaEntradaId, int correnteId)
        {
            try
            {
                List<CorrenteProduto> noProdutoOrigemList = (from p in _unitOfw.NoProdutoRepository.Get(y => y.NoId == portaEntradaId)
                                                             select new CorrenteProduto
                                                             {
                                                                 CorrenteId = correnteId,
                                                                 ProdutoId = p.ProdutoId
                                                             }).ToList();

                if (noProdutoOrigemList.Count > 0)
                    _unitOfw.CorrenteProdutoRepository.InsertRange(noProdutoOrigemList);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void CorrenteDrawingSave(int correnteId, int portaEntradaIdOut, int portaSaidaIdOut, int fluxogramaId)
        {
            try
            {
                CorrenteDrawing correnteDrawing = new CorrenteDrawing
                {
                    CorrenteId = correnteId,
                    PortaEntradaId = portaEntradaIdOut,
                    PortaSaidaId = portaSaidaIdOut,
                    FluxogramaId = fluxogramaId
                };

                _unitOfw.CorrenteDrawingRepository.Insert(correnteDrawing);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void InsertNoProduto(int portaSaidaId, int portaEntradaId)
        {
            try
            {
                var noIdDestinos = from p in _unitOfw.NoProdutoRepository.Get()
                                   join f in _unitOfw.NoProdutoRepository.Get() on p.ProdutoId equals f.ProdutoId into fg
                                   from fgi in (from f in fg
                                                where f.NoId == portaSaidaId
                                                select f).DefaultIfEmpty()
                                   where p.NoId == portaEntradaId && fgi.NoId == null
                                   select new { NoId = portaSaidaId, p.ProdutoId };


                List<NoProduto> noProdutosList =
                                noIdDestinos.Select(x => new NoProduto
                                {
                                    NoId = x.NoId,
                                    ProdutoId = x.ProdutoId
                                }).ToList();

                if (noProdutosList.Count > 0)
                    _unitOfw.NoProdutoRepository.InsertRange(noProdutosList);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region delete

        public bool Delete(int correnteId)
        {
            //pr_VCM_CorrenteDrawingDelete
            try
            {
                _unitOfw.CorrenteDrawingRepository?.Delete(y => y.CorrenteId == correnteId);

                #region  pr_CorrenteDelete  /*Inicio*/
                DiagramaCenario diagramaCenariofare = _unitOfw.DiagramaCenarioRepository.Get(y => y.TransportadorFareloId == correnteId).FirstOrDefault();
                if (diagramaCenariofare != null)
                {
                    diagramaCenariofare.TransportadorFareloId = null;
                    _unitOfw.DiagramaCenarioRepository.Update(diagramaCenariofare);
                }

                DiagramaCenario diagramaCenarioRemo = _unitOfw.DiagramaCenarioRepository.Get(y => y.TransportadorRemoidoId == correnteId).FirstOrDefault();
                if (diagramaCenarioRemo != null)
                {
                    diagramaCenarioRemo.TransportadorFareloId = null;
                    _unitOfw.DiagramaCenarioRepository.Update(diagramaCenarioRemo);
                }

                _unitOfw.CorrenteProdutoRepository?.Delete(y => y.CorrenteId == correnteId);

                _unitOfw.CorrenteCenarioRepository?.Delete(y => y.CorrenteId == correnteId);

                _unitOfw.CorrenteCenarioLimiteRepository?.Delete(y => y.CorrenteId == correnteId);

                _unitOfw.CorrenteCenarioSimboloRepository?.Delete(y => y.CorrenteId == correnteId);

                _unitOfw.CorrenteDrawingRepository?.Delete(y => y.CorrenteId == correnteId);

                Corrente corrente = _unitOfw.CorrenteRepository.Get(y => y.Id == correnteId).FirstOrDefault();

                _unitOfw.pr_ValoresClear(correnteId, corrente.TipoEntidadeId, corrente.TopologiaId, "");

                _unitOfw.CorrenteRepository.Delete(corrente);

                #endregion /*Fim */

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion
    }
}
