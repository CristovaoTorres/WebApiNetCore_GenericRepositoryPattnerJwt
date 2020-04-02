using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VcmSuite3x.Application.Interface;
using VcmSuite3x_api.Core.Interface;
using VcmSuite3x_api.Core.Models;
using VcmSuite3x_api.Core.Repository;
using VcmSuite3x_api.Models;

namespace VcmSuite3x.Application.Service

{
    public class NoDrawingAppService : INoDrawingAppService
    {
        private readonly IUnitOfWork _unitOfw;
        private readonly ICorrenteDrawingAppService _correnteBo;


        public NoDrawingAppService(IUnitOfWork unitOfWork, ICorrenteDrawingAppService correnteDrawingBO)
        {

            _unitOfw = unitOfWork;
            _correnteBo = correnteDrawingBO;
        }
        public bool Insert(int portas, int fluxogramaId, ref int noId, ref string codigo, string categoria, bool conector, float CoordenadaX, float CoordenadaY)
        {
            try
            {
                int topologiaId = _unitOfw.FluxogramaDrawingRepository.Get(y => y.Id == fluxogramaId).FirstOrDefault().TopologiaId;
                int tipoEntidadeId = _unitOfw.TipoEntidadeRepository.Get(y => y.Prefixo == categoria).FirstOrDefault().Id;

                //pr_VCM_NoDrawingInsert
                noId = NoInsert(ref codigo, tipoEntidadeId, topologiaId, false, false);

                if (noId == 0)
                    return false;

                NoDrawing noDrawing = new NoDrawing
                {
                    NoId = noId,
                    FluxogramaId = fluxogramaId,
                    CoordenadaX = CoordenadaX,
                    CoordenadaY = CoordenadaY,
                    Conector = conector
                };

                _unitOfw.NoDrawingRepository.Insert(noDrawing);

                List<PortaDrawing> portasDrawing = new List<PortaDrawing>();
                for (Int32 i = 0; i <= portas; i++)
                    portasDrawing.Add(new PortaDrawing { Index = i, FluxogramaId = fluxogramaId, NoId = noId });

                _unitOfw.PortaDrawingRepository.InsertRange(portasDrawing);
                return true;

            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }
        public bool Update(int fluxogramaId, int noId, float coordenadaX, float coordenadaY)
        {

            NoDrawing no = _unitOfw.NoDrawingRepository.Get(y => y.NoId == noId && y.FluxogramaId == fluxogramaId).FirstOrDefault();
            no.CoordenadaX = coordenadaX;
            no.CoordenadaY = coordenadaY;
            _unitOfw.NoDrawingRepository.Update(no);

            return true;
        }
        public bool Delete(int noId, int fluxogramaId)
        {
            //pr_VCM_NoDrawingDelete
            try
            {

                List<Corrente> correntes = _unitOfw.CorrenteRepository.Get(y => y.EntradaId == noId || y.SaidaId == noId).ToList();

                NoDrawing noDrawing = _unitOfw.NoDrawingRepository.Get(y => y.NoId == noId && y.FluxogramaId == fluxogramaId).FirstOrDefault();

                //Exclusão das correntes associadas ao nó.  
                foreach (var oneCorrente in correntes)
                {

                    List<CorrenteDrawing> correnteDrawings = _unitOfw.CorrenteDrawingRepository.Get(y => y.CorrenteId == oneCorrente.Id).ToList();

                    _unitOfw.CorrenteDrawingRepository.DeleteRange(correnteDrawings);

                    //pr_VCM_CorrenteDrawingDelete
                    _correnteBo.Delete(oneCorrente.Id);
                }

                //Exclusão das portas do nó.
                _unitOfw.PortaDrawingRepository.Delete(y => y.NoId == noId
                                                                && (y.FluxogramaId == fluxogramaId || noDrawing.Conector == false));

                //Exclusão do nó.

                _unitOfw.NoDrawingRepository.Delete(y => y.NoId == noId
                                                && (y.FluxogramaId == fluxogramaId || noDrawing.Conector == false));

                if (noDrawing.Conector == false)
                {
                    #region //pr_NoDelete

                    _unitOfw.NoProdutoRepository.Delete(y => y.NoId == noId);
                    _unitOfw.NoCenarioLimiteRepository.Delete(y => y.NoId == noId);
                    _unitOfw.NoCenarioSimboloRepository.Delete(y => y.NoId == noId);
                    _unitOfw.ArmazenamentoCenarioRepository.Delete(y => y.NoId == noId);
                    _unitOfw.DiagramaCenarioRepository.Delete(y => y.NoId == noId);
                    _unitOfw.DivisorCenarioRepository.Delete(y => y.NoId == noId);
                    _unitOfw.FornecimentoCenarioRepository.Delete(y => y.NoId == noId);
                    _unitOfw.MercadoCenarioRepository.Delete(y => y.NoId == noId);
                    _unitOfw.ProcessamentoCenarioRepository.Delete(y => y.NoId == noId);
                    _unitOfw.UnificadorCenarioRepository.Delete(y => y.NoId == noId);
                    _unitOfw.PortoCenarioRepository.Delete(y => y.NoId == noId);
                }

                No no = _unitOfw.NoRepository.GetWithIncludeAll(y => y.Id == noId);

                _unitOfw.pr_ValoresClear(noId, no.TipoEntidadeId, no.TopologiaId,null);

                _unitOfw.NoRepository.Delete(no);
                #endregion

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public bool Pr_LocalizacaoExists(string localizacao, int topologiaId)
        {
            return true;
        }
        public int NoInsert(ref string codigo, int tipoEntidadeId, int topologiaId, bool entradas, bool saidas)
        {
            //pr_NoInsert

            try
            {

                if (string.IsNullOrEmpty(codigo))
                {

                    codigo = _unitOfw.Fn_find_NovoCodigoById(tipoEntidadeId, topologiaId);

                    No no = new No
                    {
                        Codigo = codigo,
                        Descricao = null,
                        TipoEntidadeId = tipoEntidadeId,
                        TopologiaId = topologiaId,
                        Localizacao = null,
                        Nota = null,
                        Entradas = null,
                        Saidas = null
                    };
                    _unitOfw.NoRepository.Insert(no);
                    return no.Id;
                }
                return 0;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
