using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VcmSuite3x.Application.Interface;
using VcmSuite3x.Application.Util;
using VcmSuite3x_api.Core.Interface;
using VcmSuite3x_api.Core.Models;

namespace VcmSuite3x.Application.Service
{
    public class ElementoAppService : IElementoAppService
    {
        private readonly IUnitOfWork _unitOfw;
        private readonly IMercadoAppService _mercadoAppService;

        public ElementoAppService(IUnitOfWork unitOfw, IMercadoAppService mercadoAppService)
        {
            _unitOfw = unitOfw;
            _mercadoAppService = mercadoAppService;
        }

        public object Get(int elementoId, int cenarioId, string tipoElemento)
        {

            if (tipoElemento == TipoElemento.UF.ToString())
                return FornecimentoCenarioFind(elementoId, cenarioId);

            else if (tipoElemento == TipoElemento.UA.ToString())
                return ArmazenamentoCenarioFind(elementoId, cenarioId);

            else if (tipoElemento == TipoElemento.MC.ToString())
                return _mercadoAppService.MercadoCenarioFind(elementoId, cenarioId);

            else if (tipoElemento == TipoElemento.UP.ToString())
                return ProcessamentoCenarioFind(elementoId, cenarioId);

            return false;
        }

        #region FornecimentoCenario
        public FornecimentoCenario FornecimentoCenarioFind(int elementoId, int cenarioId)
        {
            //pr_VCM_FornecimentoCenarioFind

            //fn_FindNoCodigoById
            string codigo = _unitOfw.NoRepository.Get(y => y.Id == elementoId).FirstOrDefault()?.Codigo;

            if (!string.IsNullOrEmpty(codigo))
            {
                var forcimento = _unitOfw.FornecimentoCenarioRepository.Get(y => y.NoId == elementoId && y.CenarioId == cenarioId).FirstOrDefault();

                if (forcimento == null)
                {
                    _unitOfw.FornecimentoCenarioRepository.Insert(new FornecimentoCenario
                    {
                        NoId = elementoId,
                        CenarioId = cenarioId,
                        Suprimento = false,
                        SuprimentoAgregado = false,
                        SuprimentoSemiContinuo = false,
                        SuprimentoAgregadoSemiContinuo = false,
                        IncluirCalculoImpostos = false
                    });
                }
                return forcimento;
            }
            return null;
        }

        public ProcessamentoCenario ProcessamentoCenarioFind(int elementoId, int cenarioId)
        {
            //pr_VCane_ProcessamentoCenarioFind

            string codigo = _unitOfw.NoRepository.Get(y => y.Id == elementoId).FirstOrDefault()?.Codigo;

            if (!string.IsNullOrEmpty(codigo))
            {
                ProcessamentoCenario processamentoCenario = _unitOfw.ProcessamentoCenarioRepository.Get(y => y.NoId == elementoId && y.CenarioId == cenarioId).FirstOrDefault();

                if (processamentoCenario == null)
                {
                    _unitOfw.ProcessamentoCenarioRepository.Insert(new ProcessamentoCenario
                    {
                        NoId = elementoId,
                        CenarioId = cenarioId,
                        ConsumoEnergiaEletrica = false,
                        IncluirCalculoImpostos = false,
                        ConsumoVapor = false
                    });

                }
                return processamentoCenario;
            }

            return null;
        }
        public ArmazenamentoCenario ArmazenamentoCenarioFind(int elementoId, int cenarioId)
        {
            string codigo = _unitOfw.NoRepository.Get(y => y.Id == elementoId).FirstOrDefault()?.Codigo;

            if (!string.IsNullOrEmpty(codigo))
            {
                ArmazenamentoCenario armazenamentoCenario = _unitOfw.ArmazenamentoCenarioRepository.Get(y => y.NoId == elementoId && y.CenarioId == cenarioId).FirstOrDefault();

                if (armazenamentoCenario == null)
                {
                    TipoArmazenamento tipoArmazenamento = _unitOfw.TipoArmazenamentoRepository.Get(y => y.Nome == Util.TipoArmazenamentoEnum.Agrupado.ToString()).FirstOrDefault();

                    _unitOfw.ArmazenamentoCenarioRepository.Insert(new ArmazenamentoCenario
                    {
                        NoId = elementoId,
                        CenarioId = cenarioId,
                        TipoArmazenamentoId = tipoArmazenamento.Id,
                        IncluirCalculoImpostos = false,
                        Capex = 0,
                        ComFaixa = false
                    });
                }
                return armazenamentoCenario;
            }
            return null;
        }
        #endregion

    }
}
