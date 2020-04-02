using AutoMapper;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using VcmSuite3x.Application.Interface;
using VcmSuite3x.Application.Model;
using VcmSuite3x.Application.Util;
using VcmSuite3x_api.Core;
using VcmSuite3x_api.Core.Interface;
using VcmSuite3x_api.Core.Models;
using static VcmSuite3x.Application.Util.Enum;
using VcmSuite3x.Application.Extensions;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace VcmSuite3x.Application.Service
{
    public class CenarioFluxoAppService : ICenarioFluxoAppService
    {
        private readonly IUnitOfWork _unitOfw;
        private readonly IMapper _mapper;
        private readonly IEntradaSimbolo _entradaSimbolo;
        public CenarioFluxoAppService(IUnitOfWork unitOfw, IMapper mapper, IEntradaSimbolo entradaSimbolo)
        {
            _unitOfw = unitOfw;
            _mapper = mapper;
            _entradaSimbolo = entradaSimbolo;
        }

        public void Post(string model)
        {

            #region Funcionado
            //RequestCenarioFluxogramaSave cenarioUF = model.ToObject<RequestCenarioFluxogramaSave>();
            //SaveFornecimentoCenario(cenarioUF);

            //RequestCenarioArmazenamentoSave SaveUA = model.ToObject<RequestCenarioArmazenamentoSave>();
            //SaveArmazenamentoCenario(SaveUA.NoId, SaveUA.CenarioId, SaveUA.IncluirCalculoImpostos, SaveUA.TipoArmazenamentoId, SaveUA.Capex, SaveUA.ComFaixa);


            //RequestCenarioProcessamentoSave SaveUP = model.ToObject<RequestCenarioProcessamentoSave>();
            //SaveProcessamentoCenario(SaveUP.NoId, SaveUP.CenarioId, SaveUP.IncluirCalculoImpostos, SaveUP.ConsumoEnergiaEletrica, SaveUP.ConsumoVapor);

            #endregion
        }

        public void SaveEntrace(List<Entrada> entradas)
        {

        }
        #region Save

        public void SaveEntrada(List<EntradaRequest> entradas)
        {

            foreach (var item in entradas)
                item.AdjustFromUI();


            var entradasMapper = _mapper.Map<List<EntradaRequest>, List<Entrada>>(entradas);

            _unitOfw.pr_VCM_EntradaEdit(entradasMapper);

            //Continuar
            //pr_VCM_EntradaEdit
            //var Resultado = (from Ep in entradas.Where(y => y.Grandeza != 0)
            //                 join E in _unitOfw.EntradaRepository.Get(y => y.Id == null) on new { A = Ep.CenarioId, B = Ep.SimboloId }
            //                                                        equals new { A = E.CenarioId, B = E.SimboloId }
            //                 into e
            //                 from E in e.DefaultIfEmpty()
            //                 where (!string.IsNullOrWhiteSpace(Ep.EntidadeCodigo1) ? Ep.EntidadeCodigo1 : "0") == (!string.IsNullOrWhiteSpace(E.EntidadeCodigo1) ? E.EntidadeCodigo1 : "0")
            //                    &&
            //                       (!string.IsNullOrWhiteSpace(Ep.EntidadeCodigo2) ? Ep.EntidadeCodigo2 : "0") == (!string.IsNullOrWhiteSpace(E.EntidadeCodigo2) ? E.EntidadeCodigo2 : "0")
            //                    &&
            //                       (!string.IsNullOrWhiteSpace(Ep.EntidadeCodigo3) ? Ep.EntidadeCodigo3 : "0") == (!string.IsNullOrWhiteSpace(E.EntidadeCodigo3) ? E.EntidadeCodigo3 : "0")
            //                    &&
            //                       (!string.IsNullOrWhiteSpace(Ep.EntidadeCodigo4) ? Ep.EntidadeCodigo4 : "0") == (!string.IsNullOrWhiteSpace(E.EntidadeCodigo4) ? E.EntidadeCodigo4 : "0")
            //                    &&
            //                       (!string.IsNullOrWhiteSpace(Ep.EntidadeCodigo5) ? Ep.EntidadeCodigo5 : "0") == (!string.IsNullOrWhiteSpace(E.EntidadeCodigo5) ? E.EntidadeCodigo5 : "0")
            //                    &&
            //                       (!string.IsNullOrWhiteSpace(Ep.EntidadeCodigo6) ? Ep.EntidadeCodigo6 : "0") == (!string.IsNullOrWhiteSpace(E.EntidadeCodigo6) ? E.EntidadeCodigo6 : "0")
            //                 select new
            //                 {
            //                     E
            //                 });

            //List<Entrada> entradasConverted = Resultado as List<Entrada>;

            //foreach (var item in entradasConverted)
            //    _unitOfw.EntradaRepository.Update(item);

        }

        private bool SaveFornecimentoCenario(RequestCenarioFluxogramaSave cenarioFluxograma)
        {
            using (var context = new VCMContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        FornecimentoCenario fornecimentoCenarioOld = _unitOfw.FornecimentoCenarioRepository.Get(y => y.NoId == cenarioFluxograma.NoId
                                                            && y.CenarioId == cenarioFluxograma.CenarioId).FirstOrDefault();

                        bool incluirCalculoImpostosOld = fornecimentoCenarioOld.IncluirCalculoImpostos;
                        bool suprimentoOld = fornecimentoCenarioOld.Suprimento;

                        string codigo = _unitOfw.NoRepository.Get(y => y.Id == cenarioFluxograma.NoId).Select(y => y.Codigo).FirstOrDefault();

                        List<Simbolo> simbolos = new List<Simbolo>();
                        if (!cenarioFluxograma.IncluirCalculoImpostos)
                        {
                            simbolos = _unitOfw.SimboloRepository.Get(y => y.Codigo == SimboloCodigo.PrecoCompraNF.ToString()
                                                                     || y.Codigo == SimboloCodigo.PrecoVendaNF.ToString()
                                                                     || y.Codigo == SimboloCodigo.ICMSPorctSubstEnt.ToString()
                                                                     || y.Codigo == SimboloCodigo.ICMSPorctSubstSai.ToString()
                                                                     || y.Codigo == SimboloCodigo.ValorBenefICMS.ToString()).ToList();
                        }
                        else
                        {
                            incluirCalculoImpostosOld = _unitOfw.ArmazenamentoCenarioRepository.Get(y => y.NoId == cenarioFluxograma.NoId
                                                                                                                        && y.CenarioId == cenarioFluxograma.CenarioId)
                                                                                                                     .Select(y => y.IncluirCalculoImpostos).FirstOrDefault();
                        }
                        if (suprimentoOld != cenarioFluxograma.Suprimento && cenarioFluxograma.Suprimento == false)
                            simbolos.AddRange(_unitOfw.SimboloRepository.Get(y => y.Codigo == SimboloCodigo.SuprLo.ToString() && y.Codigo == SimboloCodigo.SuprUp.ToString()).ToList());

                        EntradaDelete(cenarioFluxograma.CenarioId, codigo, simbolos.Select(y => y.Id).ToList(), context);

                        FornecimentoCenario tobeSave = _mapper.Map<FornecimentoCenario>(cenarioFluxograma);
                        context.FornecimentoCenario.Update(tobeSave);

                        if (!incluirCalculoImpostosOld && cenarioFluxograma.IncluirCalculoImpostos)
                            LerValoresSaidaEntradaBaseCalculoImposto(cenarioFluxograma.CenarioId, codigo, context);

                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }
                }
            }
            return true;

        }
        public bool SaveArmazenamentoCenario(int elementoId, int cenarioId, bool incluircalculoImposto, int tipoArmazenamentoId, decimal capex, bool comFaixa)
        {
            using (var context = new VCMContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        //pr_VCM_ArmazenamentoCenarioUpdate
                        var codigo = _unitOfw.NoRepository.Get(y => y.Id == elementoId).FirstOrDefault()?.Codigo;

                        List<int> simbolos = new List<int>();
                        if (!incluircalculoImposto)
                        {
                            simbolos = _unitOfw.SimboloRepository.Get(y => y.Codigo == SimboloCodigo.PrecoCompraNF.ToString()
                                                                                 || y.Codigo == SimboloCodigo.PrecoVendaNF.ToString()
                                                                                 || y.Codigo == SimboloCodigo.ICMSPorctSubstEnt.ToString()
                                                                                 || y.Codigo == SimboloCodigo.ICMSPorctSubstSai.ToString()
                                                                                 || y.Codigo == SimboloCodigo.ValorBenefICMS.ToString()).Select(y => y.Id).ToList();
                        }
                        EntradaDelete(cenarioId, codigo, simbolos, context);
                        ArmazenamentoCenario armazenamentoCenario = _unitOfw.ArmazenamentoCenarioRepository.Get(y => y.NoId == elementoId && y.CenarioId == cenarioId).FirstOrDefault();

                        bool incluirCalculoImpostoOld = armazenamentoCenario.IncluirCalculoImpostos;

                        armazenamentoCenario.TipoArmazenamentoId = tipoArmazenamentoId;
                        armazenamentoCenario.IncluirCalculoImpostos = incluircalculoImposto;
                        armazenamentoCenario.Capex = capex;
                        armazenamentoCenario.ComFaixa = comFaixa;
                        _unitOfw.ArmazenamentoCenarioRepository.Update(armazenamentoCenario);

                        if (!incluirCalculoImpostoOld && incluircalculoImposto)
                            LerValoresSaidaEntradaBaseCalculoImposto(cenarioId, codigo, context);

                        if (comFaixa)
                        {
                            var faixacustoFixo = (from fcf in _unitOfw.FaixaCustoFixoRepository.Get(y => y.Id == cenarioId && y.Codigo != "F001")
                                                  join c in _unitOfw.CenarioRepository.Get() on fcf.TopologiaId equals c.TopologiaId
                                                  select new List<int>
                                                  {
                                                      fcf.Id
                                                  }).FirstOrDefault();

                            var toBeDelete = _unitOfw.NoCenarioFaixaCustoFixoRepository.Get(y => y.NoId == elementoId && y.CenarioId == cenarioId && faixacustoFixo.Contains(y.FaixaId)).ToList();
                            context.NoCenarioFaixaCustoFixo.RemoveRange(toBeDelete);

                            var simbolosId = _unitOfw.SimboloRepository.Get(v => (v.Codigo == "valorFaixaInfU" || v.Codigo == "valorFaixaSupU")
                                                                            || (v.Codigo == "CfxoUA")).Select(s => s.Id).ToList();

                            List<Entrada> entradasTobeDelete = _unitOfw.EntradaRepository.Get(y => y.EntidadeCodigo1 == codigo && y.EntidadeCodigo3 != "F001"
                                                                                              && simbolosId.Contains(y.SimboloId)).ToList();
                            context.Entrada.RemoveRange(entradasTobeDelete);
                        }
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }
                }
            }

            return true;
        }

        public bool SaveProcessamentoCenario(int elementoId, int cenarioId, bool incluirCalculoImposto, bool consumoEnergiaEletrica, bool consumoVapor)
        {
            using (var context = new VCMContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        //pr_VCane_ProcessamentoCenarioUpdate
                        var codigo = _unitOfw.NoRepository.Get(y => y.Id == elementoId).FirstOrDefault()?.Codigo;

                        List<int> simbolosId = new List<int>();
                        if (!incluirCalculoImposto)
                        {
                            simbolosId = _unitOfw.SimboloRepository.Get(y => y.Codigo == SimboloCodigo.PrecoCompraNF.ToString()
                                                                                 || y.Codigo == SimboloCodigo.PrecoVendaNF.ToString()
                                                                                 || y.Codigo == SimboloCodigo.ICMSPorctSubstEnt.ToString()
                                                                                 || y.Codigo == SimboloCodigo.ICMSPorctSubstSai.ToString()
                                                                                 || y.Codigo == SimboloCodigo.ValorBenefICMS.ToString()).Select(y => y.Id).ToList();
                        }
                        if (!consumoEnergiaEletrica || !consumoVapor)
                        {
                            if (!consumoEnergiaEletrica)
                                simbolosId.AddRange(_unitOfw.SimboloRepository.Get(y => y.Codigo == SimboloCodigo.ConseeT.ToString()).Select(y => y.Id).ToList());

                            if (!consumoVapor)
                                simbolosId.AddRange(_unitOfw.SimboloRepository.Get(y => y.Codigo == SimboloCodigo.ConsvapT.ToString()).Select(y => y.Id).ToList());
                        }


                        List<Entrada> entradasTobeDelete = _unitOfw.EntradaRepository.Get(y => simbolosId.Contains(y.SimboloId)
                                                                                          && (y.EntidadeCodigo1 == codigo
                                                                                          || simbolosId == null || simbolosId.Count == 0)).ToList();
                        EntradaDelete(cenarioId, codigo, simbolosId, context);

                        context.ProcessamentoCenario.Update(new ProcessamentoCenario
                        {
                            NoId = elementoId,
                            CenarioId = cenarioId,
                            ConsumoEnergiaEletrica = consumoEnergiaEletrica,
                            ConsumoVapor = consumoVapor,
                            IncluirCalculoImpostos = incluirCalculoImposto
                        });

                        context.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }
                }
            }
            return true;
        }
        #endregion

        #region Auxiliares
        public bool EntradaDelete(int cenarioId, string codigo, List<int> simbolos, VCMContext context)
        {
            //pr_VCM_EntradaDelete
            context.Entrada.RemoveRange(_unitOfw.EntradaRepository.Get(y => y.CenarioId == cenarioId && simbolos.Contains(y.SimboloId)
                                                         && (string.IsNullOrWhiteSpace(codigo) || y.EntidadeCodigo1 == codigo)).ToList());
            return true;
        }
        public EntradaSimbolo EntradaSimbolo(int cenarioId, string codigo, EEntryBySymbolType type)
        {
            return _entradaSimbolo.GetSimbolo(cenarioId, codigo, type); ;

        }
        private bool LerValoresSaidaEntradaBaseCalculoImposto(int cenarioId, string entidadeRaizCodigo, VCMContext context)
        {
            //pr_VCM_LerValoresSaidaBaseCalculoImposto
            //pr_VCM_LerValoresEntradaBaseCalculoImposto

            List<Entrada> entradaInsertList = new List<Entrada>();

            entradaInsertList.AddRange(LerValoresSaidaEntradaBaseCalculoImposto(cenarioId, entidadeRaizCodigo, 693, 695));
            entradaInsertList.AddRange(LerValoresSaidaEntradaBaseCalculoImposto(cenarioId, entidadeRaizCodigo, 694, 696));
            entradaInsertList.AddRange(LerValoresSaidaEntradaBaseCalculoImposto(cenarioId, entidadeRaizCodigo, 695, 693));
            entradaInsertList.AddRange(LerValoresSaidaEntradaBaseCalculoImposto(cenarioId, entidadeRaizCodigo, 696, 694));


            context.Entrada.AddRange(entradaInsertList);
            return true;
        }
        private List<Entrada> LerValoresSaidaEntradaBaseCalculoImposto(int cenarioId, string entidadeRaizCodigo, int precoCompraSimboloId, int precoVendaSimboloId)
        {
            return (from D in _unitOfw.EntradaRepository.Get(y => y.CenarioId == cenarioId && y.EntidadeCodigo2 == entidadeRaizCodigo
                                                                   && (y.SimboloId == precoVendaSimboloId)
                                                                   && y.EntidadeCodigo1 == null)
                    join O in _unitOfw.EntradaRepository.Get() on new
                    {
                        a = D.EntidadeCodigo1,
                        b = D.EntidadeCodigo2,
                        c = D.EntidadeCodigo3,
                        d = D.EntidadeCodigo4,
                        e = D.EntidadeCodigo5,
                        f = precoVendaSimboloId
                    } equals new
                    {
                        a = O.EntidadeCodigo2,
                        b = O.EntidadeCodigo1,
                        c = O.EntidadeCodigo3,
                        d = O.EntidadeCodigo4,
                        e = O.EntidadeCodigo5,
                        f = O.SimboloId
                    } into x
                    from vnpp in x.DefaultIfEmpty()
                    select new Entrada
                    {
                        CenarioId = cenarioId,
                        TipoValorId = D.TipoValorId,
                        SimboloId = precoCompraSimboloId,
                        Grandeza = D.Grandeza,
                        EntidadeCodigo1 = D.EntidadeCodigo1,
                        EntidadeCodigo2 = D.EntidadeCodigo2,
                        EntidadeCodigo3 = D.EntidadeCodigo3,
                        EntidadeCodigo4 = D.EntidadeCodigo4,
                        EntidadeCodigo5 = D.EntidadeCodigo5,
                        EntidadeCodigo6 = D.EntidadeCodigo6
                    }).ToList();

        }

        #endregion

    }
}
