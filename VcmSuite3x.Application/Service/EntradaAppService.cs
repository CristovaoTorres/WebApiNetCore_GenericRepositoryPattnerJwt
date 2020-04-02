using FastMember;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using VcmSuite3x.Application.Interface;
using VcmSuite3x.Application.Model;
using VcmSuite3x_api.Core.Interface;
using VcmSuite3x_api.Core.Models;

namespace VcmSuite3x.Application.Service
{
    public class EntradaAppService : IEntradaAppService
    {
        private readonly IUnitOfWork _unitOfw;
        private readonly IMercadoAppService _mercadoAppService;
        private readonly IConfiguracaoAppService _configuracaoAppService;
        private readonly ISimboloService _simboloService;
        private readonly IEntradaAppService _entradaAppService;
        private readonly ICenarioFluxoAppService _cenarioFluxoAppService;
        public EntradaAppService()
        {
            this.Agrupamento = (a, c) => { };
        }

        public EntradaAppService(IUnitOfWork unitOfWork, IMercadoAppService mercadoAppService, ICenarioFluxoAppService cenarioFluxoAppService)
        {
            _unitOfw = unitOfWork;
            _mercadoAppService = mercadoAppService;
            this.Agrupamento = (a, c) => { };
            _cenarioFluxoAppService = cenarioFluxoAppService;
        }

        private MercadoCenario mercadoCenario;


        protected Int32 Dimensoes
        {
            get;
            set;
        }

        protected Action<Boolean, String> Agrupamento { get; set; }

        public void Update(string data, string no)
        {
            Collection<EntradaRequest> entitiess = JsonConvert.DeserializeObject<Collection<EntradaRequest>>(data);
            Collection<Entrada> entities = JsonConvert.DeserializeObject<Collection<Entrada>>(data);

            if (entities.Count(e => e != null) > 0)
            {
                try
                {
                    Collection<EntradaRequest> entradas = new Collection<EntradaRequest>();

                    if (no == "MC")
                        entradas = this.GetEntradas(entitiess);

                    if (no == "UF")
                        entradas = this.GetEntradasWithoutValidate(entitiess);

                    _cenarioFluxoAppService.SaveEntrada(entradas.ToList());
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        protected virtual Collection<EntradaRequest> GetEntradasWithoutValidate(Collection<EntradaRequest> entities)
        {
            return entities;
        }

        protected virtual Collection<EntradaRequest> GetEntradas(Collection<EntradaRequest> entities)
        {
            try
            {
                Collection<EntradaRequest> entradas = new Collection<EntradaRequest>();

                TypeAccessor entradaAccessor = TypeAccessor.Create(typeof(EntradaRequest));
                TypeAccessor modelAccessor = TypeAccessor.Create(typeof(EntradaRequest));

                var agrupamento = (Dictionary<String, Int32>)modelAccessor[entities[0], "Agrupamento"];

                if (agrupamento.Count == 0)
                {
                    entradas = new Collection<EntradaRequest>(entities.Where(e => e != null && e.CenarioId > 0 && e.SimboloId > 0 && e.EntidadeCodigo1 != null)
                                                               .Select(e => new EntradaRequest
                                                               {
                                                                   Id = e.Id,
                                                                   CenarioId = e.CenarioId,
                                                                   SimboloId = e.SimboloId,
                                                                   GrandezaApresentacao = e.GrandezaApresentacao,
                                                                   EntidadeCodigo1 = e.EntidadeCodigo1,
                                                                   EntidadeCodigo2 = e.EntidadeCodigo2,
                                                                   EntidadeCodigo3 = e.EntidadeCodigo3,
                                                                   EntidadeCodigo4 = e.EntidadeCodigo4,
                                                                   EntidadeCodigo5 = e.EntidadeCodigo5,
                                                                   EntidadeCodigo6 = e.EntidadeCodigo6,
                                                                   UnidadeMedidaDenominadorId = e.UnidadeMedidaDenominadorId,
                                                                   UnidadeMedidaNumeradorId = e.UnidadeMedidaNumeradorId,
                                                                   ValorAtual = e.GrandezaApresentacao
                                                               }).ToList());
                }
                else
                {
                    foreach (EntradaRequest item in entities.Where(e => e.CenarioId > 0 && e.SimboloId > 0 && e.EntidadeCodigo1 != null))
                    {
                        Int32 cenarioId = item.CenarioId;
                        Int32 simboloId = item.SimboloId;
                        Decimal grandezaApresentacao = item.GrandezaApresentacao;

                        agrupamento = (Dictionary<String, Int32>)modelAccessor[item, "Agrupamento"];
                        foreach (var grupo in agrupamento)
                        {
                            EntradaRequest entrada = new EntradaRequest
                            {
                                Id = grupo.Value,
                                CenarioId = cenarioId,
                                SimboloId = simboloId,
                                GrandezaApresentacao = grandezaApresentacao,
                                UnidadeMedidaDenominadorId = item.UnidadeMedidaDenominadorId,
                                UnidadeMedidaNumeradorId = item.UnidadeMedidaNumeradorId,
                                ValorAtual = grandezaApresentacao
                            };

                            Int32 dimensoes = this.Dimensoes;
                            for (int i = 1; i < dimensoes; i++)
                            {
                                String campo = String.Format("EntidadeCodigo{0}", i);
                                entradaAccessor[entrada, campo] = modelAccessor[item, campo];
                            }

                            entradaAccessor[entrada, String.Format("EntidadeCodigo{0}", dimensoes)] = grupo.Key;

                            entradas.Add(entrada);
                        }
                    }
                }

                return (ValidateMC(entradas) ? entradas : null);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool Validate(Collection<EntradaRequest> entradas)
        {
            return true;
        }

        public void NoCenarioSimboloFind(int cenarioId, int simboloId, string codigo)
        {
            //pr_VCM_NoCenarioSimboloFind
            var noCenarioSimbolo = (from ncs in _unitOfw.NoCenarioSimboloRepository.Get(y => y.CenarioId == cenarioId && y.SimboloId == simboloId)
                                    join n in _unitOfw.NoRepository.Get(y => y.Codigo == codigo) on ncs.NoId equals n.Id
                                    join t in _unitOfw.TopologiaRepository.Get() on n.TopologiaId equals t.Id
                                    join cn in _unitOfw.CenarioRepository.Get(y => y.Id == cenarioId) on new { A = t.Id, B = ncs.CenarioId }
                                                                                                  equals new { A = cn.TopologiaId, B = cn.Id }
                                    select new
                                    {
                                        ncs
                                    }).FirstOrDefault();
        }

        public void FindConfiguracao(String entidadeRaizCodigo)
        {
            //Configuracao config = null;

            if (!String.IsNullOrEmpty(entidadeRaizCodigo))
            {
                GetConfiguracao(entidadeRaizCodigo);

                ConfiguracaoRequest configToFind = _configuracaoAppService.Find();
                //ConfiguracaoRequest configToFind = new ConfiguracaoRepository().Find(this.configuracao);
                if (configToFind != null) this.configuracao = configToFind;
            }
        }
        private ConfiguracaoRequest _configuracao = new ConfiguracaoRequest();

        public ConfiguracaoRequest configuracao
        {
            get { return _configuracao; }
            set { _configuracao = value; }
        }
        protected Collection<Simbolo> Simbolos { get; set; }

        public String codigoSimbolo;

        private String[] _CodigosSimbolo;
        protected String[] CodigosSimbolo
        {
            get
            {
                return _CodigosSimbolo;
            }
            set
            {
                _CodigosSimbolo = value;
                if (_CodigosSimbolo != null && _CodigosSimbolo.Count() > 0)
                {
                    this.codigoSimbolo = value[0];

                    Simbolos = new Collection<Simbolo>();
                    //IQuery<Simbolo> query = SimboloQuery.Create(SessionInfo.CadeiaId);
                    //foreach (String codigo in CodigosSimbolo) Simbolos.Add(query.Find(codigo));
                }
            }

        }

        protected virtual Simbolo SimboloDefault
        {
            get { return _simboloService.Find(this.CodigosSimbolo[0]); }
        }

        protected virtual void SetConfiguracao(ConfiguracaoRequest config, String entidadeRaizCodigo)
        {
            config.Elemento = entidadeRaizCodigo;

        }

        protected virtual void GetConfiguracao(String entidadeRaizCodigo)
        {
            this.configuracao = new ConfiguracaoRequest
            {
                CenarioId = 1,
                SimboloId = this.SimboloDefault.Id
            };
            this.SetConfiguracao(this.configuracao, entidadeRaizCodigo);
            //return config;
        }



        public bool ValidateMC(Collection<EntradaRequest> entradas)
        {
            return true;


            //Continuar escrevendo o metodo de validação;
            if (entradas.Count > 0)
            {
                this.mercadoCenario = _mercadoAppService.MercadoCenarioFindByCodigo(entradas[0].EntidadeCodigo1, entradas[0].CenarioId);
                this.FindConfiguracao(entradas[0].EntidadeCodigo1);

                if (mercadoCenario.IsSpot)
                {
                    //validation = new entradacomparevalidation(entradas, sessioninfo.cadeiaid, demandalimminimo, demandalimmaximo);
                }
                //else
                //{
                //    if (this.configuracao.TipoEntrada.Value == (int)TiposConfiguracaoEntrada.ComExcedente)    // Para o caso de Valor Fixo com excedente
                //    {
                //        validation = new EntradaCompareValidation(entradas, SessionInfo.CadeiaId, DemandaLimMinimoContratosComExcedente, DemandaLimMaximoContratosComExcedente);
                //    }
                //    else
                //    {
                //        validation = new EntradaCompareValidation(entradas, SessionInfo.CadeiaId, DemandaLimMinimoContratos, DemandaLimMaximoContratos);
                //    }
                //}
                //validation.OnError = this.OnValidationError;

                //return validation.Validate();
            }
            return true;
        }

        public List<EntradaRequest> Select(int id, Collection<Simbolo> simbolos, string codigoRaiz, ConfiguracaoRequest configuracao)
        {
            return new List<EntradaRequest>();
        }

        //public IEnumerable<Entrada> SelectEntradas(String entidadeRaizCodigo)
        //{
        //    int cenarioId = 0;

        //    //return repository.Select(SessionInfo.Cenario.Id, SimboloQuery.Create(SessionInfo.CadeiaId).Find(this.CodigosSimbolo[0]).Id, entidadeRaizCodigo);
        //    IEnumerable<Entrada> entradas = repository.Select(cenarioId, this.Simbolos, entidadeRaizCodigo, this.filtro);

        //    return entradas;
        //}

    }
}
