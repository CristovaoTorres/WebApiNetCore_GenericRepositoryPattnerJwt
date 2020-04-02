using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VcmSuite3x_api.Core.Extension;
using VcmSuite3x_api.Core.Helper;
using VcmSuite3x_api.Core.Interface;
using VcmSuite3x_api.Core.Models;
using dp = Dapper;

namespace VcmSuite3x_api.Core.Repository
{
    public class UnitOfWork : IUnitOfWork, System.IDisposable
    {

        protected VCMContext _dbContext;


        public UnitOfWork()
        {
        }

        private GenericRepository<Application> applicationRepository;
        private GenericRepository<Projeto> projetoRepository;
        private GenericRepository<Produto> produtoRepository;
        private GenericRepository<UnidadeMedida> unidadeMedidaRepository;
        private GenericRepository<MedidaProjeto> medidaProjetoRepository;
        private GenericRepository<TipoUnidade> tipoUnidadeRepository;
        private GenericRepository<TipoValor> tipoValorRepository;
        private GenericRepository<TipoEntidade> tipoEntidadeRepository;
        private GenericRepository<Cenario> cenarioRepository;
        private GenericRepository<Topologia> topologiaRepository;
        private GenericRepository<Cadeia> cadeiaRepository;
        private GenericRepository<FornecimentoCenario> fornecimentoCenarioRepository;
        private GenericRepository<PortaDrawing> portaDrawingRepository;
        private GenericRepository<NoDrawing> noDrawingRepository;
        private GenericRepository<NoCenarioLimite> noCenarioLimiteRepository;
        private GenericRepository<NoCenarioSimbolo> noCenarioSimboloRepository;
        private GenericRepository<FluxogramaDrawing> fluxogramaDrawingRepository;
        private GenericRepository<No> noRepository;
        private GenericRepository<Calculo> calculoRepository;
        private GenericRepository<Corrente> correnteRepository;
        private GenericRepository<CorrenteDrawing> correnteDrawingRepository;
        private GenericRepository<Estado> estadoRepository;
        private GenericRepository<Pais> paisRepository;
        private GenericRepository<Contrato> contratoRepository;
        private GenericRepository<Desconto> descontoRepository;
        private GenericRepository<FaixaDesconto> faixaDescontoRepository;
        private IGenericRepository<FaixaCustoFixo> faixaCustoFixoRepository;
        private GenericRepository<Familia> familiaRepository;
        private GenericRepository<Blend> blendRepository;
        private GenericRepository<Conjunto> conjuntoRepository;
        private GenericRepository<Periodo> periodoRepository;
        private GenericRepository<PeriodoAgregado> periodoAgregadoRepository;
        private GenericRepository<PeriodoAgregadoItem> periodoAgregadoItemRepository;
        private GenericRepository<PrecoBase> precoBaseRepository;
        private GenericRepository<Regiao> regiaoRepository;
        private GenericRepository<Restricao> restricaoRepository;
        private GenericRepository<DivisorCenario> divisorCenarioRepository;
        private GenericRepository<Silo> siloRepository;
        private GenericRepository<Valvula> valvulaRepository;
        private GenericRepository<Propriedade> propriedadeRepository;
        private IGenericRepository<PropriedadeTopologia> propriedadeTopologiaRepository;
        private GenericRepository<NoProduto> noProdutoRepository;
        private GenericRepository<CorrenteProduto> correnteProdutoRepository;
        private IGenericRepository<TipoProduto> tipoProdutoRepository;
        private IGenericRepository<TipoDemanda> tipoDemandaRepository;
        private GenericRepository<ElementoTipoProduto> elementoTipoProdutoRepository;
        private GenericRepository<NoFamilia> noFamiliaRepository;
        private GenericRepository<ProdutoFamilia> produtoFamiliaRepository;
        private GenericRepository<ProdutoContrato> produtoContratoRepository;
        private GenericRepository<FamiliaContrato> familiaContratoRepository;
        private GenericRepository<TemplateMedida> templateMedidaRepository;
        private GenericRepository<Simbolo> simboloRepository;
        private GenericRepository<Entrada> entradaRepository;
        private GenericRepository<TipoPropriedade> tipoPropriedadeRepository;
        private GenericRepository<PeriodoCenario> periodoCenarioRepository;
        private GenericRepository<CorrenteCenario> correnteCenarioRepository;
        private GenericRepository<CorrenteCenarioLimite> correnteCenarioLimiteRepository;
        private GenericRepository<CorrenteCenarioSimbolo> correnteCenarioSimboloRepository;
        private GenericRepository<DiagramaCenario> diagramaCenarioRepository;
        private GenericRepository<MercadoCenario> mercadoCenarioRepository;
        private GenericRepository<MercadoContrato> mercadoContratoRepository;
        private GenericRepository<ArmazenamentoCenario> armazenamentoCenarioRepository;
        private GenericRepository<ProcessamentoCenario> processamentoCenarioRepository;
        private GenericRepository<UnificadorCenario> unificadorCenarioRepository;
        private GenericRepository<PortoCenario> portoCenarioRepository;
        private GenericRepository<Entidade> entidadeRepository;
        private GenericRepository<EntidadeSimbolo> entidadeSimboloRepository;
        private GenericRepository<TipoArmazenamento> tipoArmazenamentoRepository;
        private IGenericRepository<NoCenarioFaixaCustoFixo> noCenarioFaixaCustoFixoRepository;



        public IGenericRepository<Calculo> CalculoRepository
        {
            get
            {
                if (this.calculoRepository == null)
                {
                    this.calculoRepository = new GenericRepository<Calculo>(_dbContext);
                }
                return calculoRepository;
            }
        }

        public IGenericRepository<PortoCenario> PortoCenarioRepository
        {
            get
            {
                if (this.portoCenarioRepository == null)
                {
                    this.portoCenarioRepository = new GenericRepository<PortoCenario>(_dbContext);
                }
                return portoCenarioRepository;
            }
        }


        public IGenericRepository<EntidadeSimbolo> EntidadeSimboloRepository
        {
            get
            {
                if (this.entidadeSimboloRepository == null)
                {
                    this.entidadeSimboloRepository = new GenericRepository<EntidadeSimbolo>(_dbContext);
                }
                return entidadeSimboloRepository;
            }
        }
        public IGenericRepository<UnificadorCenario> UnificadorCenarioRepository
        {
            get
            {
                if (this.unificadorCenarioRepository == null)
                {
                    this.unificadorCenarioRepository = new GenericRepository<UnificadorCenario>(_dbContext);
                }
                return unificadorCenarioRepository;
            }
        }
        public IGenericRepository<ProcessamentoCenario> ProcessamentoCenarioRepository
        {
            get
            {
                if (this.processamentoCenarioRepository == null)
                {
                    this.processamentoCenarioRepository = new GenericRepository<ProcessamentoCenario>(_dbContext);
                }
                return processamentoCenarioRepository;
            }
        }
        public IGenericRepository<DivisorCenario> DivisorCenarioRepository
        {
            get
            {
                if (this.divisorCenarioRepository == null)
                {
                    this.divisorCenarioRepository = new GenericRepository<DivisorCenario>(_dbContext);
                }
                return divisorCenarioRepository;
            }
        }
        public IGenericRepository<ArmazenamentoCenario> ArmazenamentoCenarioRepository
        {
            get
            {
                if (this.armazenamentoCenarioRepository == null)
                {
                    this.armazenamentoCenarioRepository = new GenericRepository<ArmazenamentoCenario>(_dbContext);
                }
                return armazenamentoCenarioRepository;
            }
        }
        public IGenericRepository<NoCenarioSimbolo> NoCenarioSimboloRepository
        {
            get
            {
                if (this.noCenarioSimboloRepository == null)
                {
                    this.noCenarioSimboloRepository = new GenericRepository<NoCenarioSimbolo>(_dbContext);
                }
                return noCenarioSimboloRepository;
            }
        }
        public IGenericRepository<NoCenarioLimite> NoCenarioLimiteRepository
        {
            get
            {
                if (this.noCenarioLimiteRepository == null)
                {
                    this.noCenarioLimiteRepository = new GenericRepository<NoCenarioLimite>(_dbContext);
                }
                return noCenarioLimiteRepository;
            }
        }

        public IGenericRepository<TipoDemanda> TipoDemandaRepository
        {
            get
            {
                if (this.tipoDemandaRepository == null)
                {
                    this.tipoDemandaRepository = new GenericRepository<TipoDemanda>(_dbContext);
                }
                return tipoDemandaRepository;
            }
        }
        public IGenericRepository<FaixaCustoFixo> FaixaCustoFixoRepository
        {
            get
            {
                if (this.faixaCustoFixoRepository == null)
                {
                    this.faixaCustoFixoRepository = new GenericRepository<FaixaCustoFixo>(_dbContext);
                }
                return faixaCustoFixoRepository;
            }
        }
        public IGenericRepository<NoCenarioFaixaCustoFixo> NoCenarioFaixaCustoFixoRepository
        {
            get
            {
                if (this.noCenarioFaixaCustoFixoRepository == null)
                {
                    this.noCenarioFaixaCustoFixoRepository = new GenericRepository<NoCenarioFaixaCustoFixo>(_dbContext);
                }
                return noCenarioFaixaCustoFixoRepository;
            }
        }
        public IGenericRepository<CorrenteCenarioSimbolo> CorrenteCenarioSimboloRepository
        {
            get
            {
                if (this.correnteCenarioSimboloRepository == null)
                {
                    this.correnteCenarioSimboloRepository = new GenericRepository<CorrenteCenarioSimbolo>(_dbContext);
                }
                return correnteCenarioSimboloRepository;
            }
        }
        public IGenericRepository<CorrenteCenarioLimite> CorrenteCenarioLimiteRepository
        {
            get
            {
                if (this.correnteCenarioLimiteRepository == null)
                {
                    this.correnteCenarioLimiteRepository = new GenericRepository<CorrenteCenarioLimite>(_dbContext);
                }
                return correnteCenarioLimiteRepository;
            }
        }
        public IGenericRepository<DiagramaCenario> DiagramaCenarioRepository
        {
            get
            {
                if (this.diagramaCenarioRepository == null)
                {
                    this.diagramaCenarioRepository = new GenericRepository<DiagramaCenario>(_dbContext);
                }
                return diagramaCenarioRepository;
            }
        }
        public IGenericRepository<TipoPropriedade> TipoPropriedadeRepository
        {
            get
            {
                if (this.tipoPropriedadeRepository == null)
                {
                    this.tipoPropriedadeRepository = new GenericRepository<TipoPropriedade>(_dbContext);
                }
                return tipoPropriedadeRepository;
            }
        }
        public IGenericRepository<Entrada> EntradaRepository
        {
            get
            {
                if (this.entradaRepository == null)
                {
                    this.entradaRepository = new GenericRepository<Entrada>(_dbContext);
                }
                return entradaRepository;
            }
        }
        public IGenericRepository<Simbolo> SimboloRepository
        {
            get
            {
                if (this.simboloRepository == null)
                {
                    this.simboloRepository = new GenericRepository<Simbolo>(_dbContext);
                }
                return simboloRepository;
            }
        }
        public IGenericRepository<TipoValor> TipoValorRepository
        {
            get
            {
                if (this.tipoValorRepository == null)
                {
                    this.tipoValorRepository = new GenericRepository<TipoValor>(_dbContext);
                }
                return tipoValorRepository;
            }
        }
        public IGenericRepository<TemplateMedida> TemplateMedidaRepository
        {
            get
            {
                if (this.templateMedidaRepository == null)
                {
                    this.templateMedidaRepository = new GenericRepository<TemplateMedida>(_dbContext);
                }
                return templateMedidaRepository;
            }
        }
        public IGenericRepository<ProdutoFamilia> ProdutoFamiliaRepository
        {
            get
            {
                if (this.produtoFamiliaRepository == null)
                {
                    this.produtoFamiliaRepository = new GenericRepository<ProdutoFamilia>(_dbContext);
                }
                return produtoFamiliaRepository;
            }
        }
        public IGenericRepository<ElementoTipoProduto> ElementoTipoProdutoRepository
        {
            get
            {
                if (this.elementoTipoProdutoRepository == null)
                {
                    this.elementoTipoProdutoRepository = new GenericRepository<ElementoTipoProduto>(_dbContext);
                }
                return elementoTipoProdutoRepository;
            }
        }
        public IGenericRepository<TipoProduto> TipoProdutoRepository
        {
            get
            {
                if (this.tipoProdutoRepository == null)
                {
                    this.tipoProdutoRepository = new GenericRepository<TipoProduto>(_dbContext);
                }
                return tipoProdutoRepository;
            }
        }
        public IGenericRepository<NoProduto> NoProdutoRepository
        {
            get
            {
                if (this.noProdutoRepository == null)
                {
                    this.noProdutoRepository = new GenericRepository<NoProduto>(_dbContext);
                }
                return noProdutoRepository;
            }
        }
        public IGenericRepository<CorrenteProduto> CorrenteProdutoRepository
        {
            get
            {
                if (this.correnteProdutoRepository == null)
                {
                    this.correnteProdutoRepository = new GenericRepository<CorrenteProduto>(_dbContext);
                }
                return correnteProdutoRepository;
            }
        }
        public IGenericRepository<CorrenteCenario> CorrenteCenarioRepository
        {
            get
            {
                if (this.correnteCenarioRepository == null)
                {
                    this.correnteCenarioRepository = new GenericRepository<CorrenteCenario>(_dbContext);
                }
                return correnteCenarioRepository;
            }
        }
        public IGenericRepository<CorrenteDrawing> CorrenteDrawingRepository
        {
            get
            {
                if (this.correnteDrawingRepository == null)
                {
                    this.correnteDrawingRepository = new GenericRepository<CorrenteDrawing>(_dbContext);
                }
                return correnteDrawingRepository;
            }
        }
        public IGenericRepository<PropriedadeTopologia> PropriedadeTopologiaRepository
        {
            get
            {
                if (this.propriedadeTopologiaRepository == null)
                {
                    this.propriedadeTopologiaRepository = new GenericRepository<PropriedadeTopologia>(_dbContext);
                }
                return propriedadeTopologiaRepository;
            }
        }
        public IGenericRepository<Propriedade> PropriedadeRepository
        {
            get
            {
                if (this.propriedadeRepository == null)
                {
                    this.propriedadeRepository = new GenericRepository<Propriedade>(_dbContext);
                }
                return propriedadeRepository;
            }
        }
        public GenericRepository<Valvula> ValvulaRepository
        {
            get
            {
                if (this.valvulaRepository == null)
                {
                    this.valvulaRepository = new GenericRepository<Valvula>(_dbContext);
                }
                return valvulaRepository;
            }
        }
        public GenericRepository<Silo> SiloRepository
        {
            get
            {
                if (this.siloRepository == null)
                {
                    this.siloRepository = new GenericRepository<Silo>(_dbContext);
                }
                return siloRepository;
            }
        }
        public IGenericRepository<Familia> FamiliaRepository
        {
            get
            {
                if (this.familiaRepository == null)
                {
                    this.familiaRepository = new GenericRepository<Familia>(_dbContext);
                }
                return familiaRepository;
            }
        }

        public GenericRepository<FaixaDesconto> FaixaDescontoRepository
        {
            get
            {
                if (this.faixaDescontoRepository == null)
                {
                    this.faixaDescontoRepository = new GenericRepository<FaixaDesconto>(_dbContext);
                }
                return faixaDescontoRepository;
            }
        }
        public GenericRepository<Regiao> RegiaoRepository
        {
            get
            {
                if (this.regiaoRepository == null)
                {
                    this.regiaoRepository = new GenericRepository<Regiao>(_dbContext);
                }
                return regiaoRepository;
            }
        }
        public GenericRepository<Restricao> RestricaoRepository
        {
            get
            {
                if (this.restricaoRepository == null)
                {
                    this.restricaoRepository = new GenericRepository<Restricao>(_dbContext);
                }
                return restricaoRepository;
            }
        }
        public GenericRepository<PrecoBase> PrecobaseRepository
        {
            get
            {
                if (this.precoBaseRepository == null)
                {
                    this.precoBaseRepository = new GenericRepository<PrecoBase>(_dbContext);
                }
                return precoBaseRepository;
            }
        }
        public IGenericRepository<PeriodoAgregado> PeriodoAgregadoRepository
        {
            get
            {
                if (this.periodoAgregadoRepository == null)
                {
                    this.periodoAgregadoRepository = new GenericRepository<PeriodoAgregado>(_dbContext);
                }
                return periodoAgregadoRepository;
            }
        }
        public IGenericRepository<PeriodoCenario> PeriodoCenarioRepository
        {
            get
            {
                if (this.periodoCenarioRepository == null)
                {
                    this.periodoCenarioRepository = new GenericRepository<PeriodoCenario>(_dbContext);
                }
                return periodoCenarioRepository;
            }
        }
        public IGenericRepository<PeriodoAgregadoItem> PeriodoAgregadoItemRepository
        {
            get
            {
                if (this.periodoAgregadoItemRepository == null)
                {
                    this.periodoAgregadoItemRepository = new GenericRepository<PeriodoAgregadoItem>(_dbContext);
                }
                return periodoAgregadoItemRepository;
            }
        }
        public IGenericRepository<Periodo> PeriodoRepository
        {
            get
            {
                if (this.periodoRepository == null)
                {
                    this.periodoRepository = new GenericRepository<Periodo>(_dbContext);
                }
                return periodoRepository;
            }
        }
        public GenericRepository<Desconto> DescontoRepository
        {
            get
            {
                if (this.descontoRepository == null)
                {
                    this.descontoRepository = new GenericRepository<Desconto>(_dbContext);
                }
                return descontoRepository;
            }
        }
        public GenericRepository<Conjunto> ConjuntoRepository
        {
            get
            {
                if (this.conjuntoRepository == null)
                {
                    this.conjuntoRepository = new GenericRepository<Conjunto>(_dbContext);
                }
                return conjuntoRepository;
            }
        }
        public IGenericRepository<Contrato> ContratoRepository
        {
            get
            {
                if (this.contratoRepository == null)
                {
                    this.contratoRepository = new GenericRepository<Contrato>(_dbContext);
                }
                return contratoRepository;
            }
        }
        public IGenericRepository<FaixaCustoFixo> FamiliaCustoFixoRepository
        {
            get
            {

                if (this.faixaCustoFixoRepository == null)
                {
                    this.faixaCustoFixoRepository = new GenericRepository<FaixaCustoFixo>(_dbContext);
                }
                return faixaCustoFixoRepository;
            }
        }
        public IGenericRepository<Blend> BlendRepository
        {
            get
            {

                if (this.blendRepository == null)
                {
                    this.blendRepository = new GenericRepository<Blend>(_dbContext);
                }
                return blendRepository;
            }
        }
        public GenericRepository<Pais> PaisRepository
        {
            get
            {

                if (this.paisRepository == null)
                {
                    this.paisRepository = new GenericRepository<Pais>(_dbContext);
                }
                return paisRepository;
            }
        }
        public IGenericRepository<Estado> EstadoRepository
        {
            get
            {

                if (this.estadoRepository == null)
                {
                    this.estadoRepository = new GenericRepository<Estado>(_dbContext);
                }
                return estadoRepository;
            }
        }
        public IGenericRepository<Corrente> CorrenteRepository
        {
            get
            {

                if (this.correnteRepository == null)
                {
                    this.correnteRepository = new GenericRepository<Corrente>(_dbContext);
                }
                return correnteRepository;
            }
        }
        public IGenericRepository<No> NoRepository
        {
            get
            {

                if (this.noRepository == null)
                {
                    this.noRepository = new GenericRepository<No>(_dbContext);
                }
                return noRepository;
            }
        }
        public IGenericRepository<NoDrawing> NoDrawingRepository
        {
            get
            {

                if (this.noDrawingRepository == null)
                {
                    this.noDrawingRepository = new GenericRepository<NoDrawing>(_dbContext);
                }
                return noDrawingRepository;
            }
        }
        public IGenericRepository<FluxogramaDrawing> FluxogramaDrawingRepository
        {
            get
            {

                if (this.fluxogramaDrawingRepository == null)
                {
                    this.fluxogramaDrawingRepository = new GenericRepository<FluxogramaDrawing>(_dbContext);
                }
                return fluxogramaDrawingRepository;
            }
        }
        public IGenericRepository<PortaDrawing> PortaDrawingRepository
        {
            get
            {

                if (this.portaDrawingRepository == null)
                {
                    this.portaDrawingRepository = new GenericRepository<PortaDrawing>(_dbContext);
                }
                return portaDrawingRepository;
            }
        }
        public IGenericRepository<FornecimentoCenario> FornecimentoCenarioRepository
        {
            get
            {

                if (this.fornecimentoCenarioRepository == null)
                {
                    this.fornecimentoCenarioRepository = new GenericRepository<FornecimentoCenario>(_dbContext);
                }
                return fornecimentoCenarioRepository;
            }
        }
        public GenericRepository<Application> ApplicationRepository
        {
            get
            {

                if (this.applicationRepository == null)
                {
                    this.applicationRepository = new GenericRepository<Application>(_dbContext);
                }
                return applicationRepository;
            }
        }
        public IGenericRepository<Produto> ProdutoRepository
        {
            get
            {

                if (this.produtoRepository == null)
                {
                    this.produtoRepository = new GenericRepository<Produto>(_dbContext);
                }
                return produtoRepository;
            }
        }
        public IGenericRepository<Cadeia> CadeiaRepository
        {
            get
            {

                if (this.cadeiaRepository == null)
                {
                    this.cadeiaRepository = new GenericRepository<Cadeia>(_dbContext);
                }
                return cadeiaRepository;
            }
        }
        public IGenericRepository<Topologia> TopologiaRepository
        {
            get
            {

                if (this.topologiaRepository == null)
                {
                    this.topologiaRepository = new GenericRepository<Topologia>(_dbContext);
                }
                return topologiaRepository;
            }
        }
        public IGenericRepository<Cenario> CenarioRepository
        {
            get
            {

                if (this.cenarioRepository == null)
                {
                    this.cenarioRepository = new GenericRepository<Cenario>(_dbContext);
                }
                return cenarioRepository;
            }
        }
        public IGenericRepository<Projeto> ProjetoRepository
        {
            get
            {

                if (this.projetoRepository == null)
                {
                    this.projetoRepository = new GenericRepository<Projeto>(_dbContext);
                }
                return projetoRepository;
            }
        }
        public IGenericRepository<UnidadeMedida> UnidadeMedidaRepository
        {
            get
            {

                if (this.unidadeMedidaRepository == null)
                {
                    this.unidadeMedidaRepository = new GenericRepository<UnidadeMedida>(_dbContext);
                }
                return unidadeMedidaRepository;
            }
        }
        public IGenericRepository<TipoUnidade> TipoUnidadeRepository
        {
            get
            {

                if (this.tipoUnidadeRepository == null)
                {
                    this.tipoUnidadeRepository = new GenericRepository<TipoUnidade>(_dbContext);
                }
                return tipoUnidadeRepository;
            }
        }
        public IGenericRepository<TipoEntidade> TipoEntidadeRepository
        {
            get
            {

                if (this.tipoEntidadeRepository == null)
                {
                    this.tipoEntidadeRepository = new GenericRepository<TipoEntidade>(_dbContext);
                }
                return tipoEntidadeRepository;
            }
        }
        public IGenericRepository<MedidaProjeto> MedidaProjetoRepository
        {
            get
            {

                if (this.medidaProjetoRepository == null)
                {
                    this.medidaProjetoRepository = new GenericRepository<MedidaProjeto>(_dbContext);
                }
                return medidaProjetoRepository;
            }
        }
        public IGenericRepository<NoFamilia> NoFamiliaRepository
        {
            get
            {

                if (this.noFamiliaRepository == null)
                {
                    this.noFamiliaRepository = new GenericRepository<NoFamilia>(_dbContext);
                }
                return noFamiliaRepository;
            }
        }
        public IGenericRepository<ProdutoContrato> ProdutoContratoRepository
        {
            get
            {

                if (this.produtoContratoRepository == null)
                {
                    this.produtoContratoRepository = new GenericRepository<ProdutoContrato>(_dbContext);
                }
                return produtoContratoRepository;
            }
        }
        public IGenericRepository<FamiliaContrato> FamiliaContratoRepository
        {
            get
            {

                if (this.familiaContratoRepository == null)
                {
                    this.familiaContratoRepository = new GenericRepository<FamiliaContrato>(_dbContext);
                }
                return familiaContratoRepository;
            }
        }
        public IGenericRepository<MercadoCenario> MercadoCenarioRepository
        {
            get
            {

                if (this.mercadoCenarioRepository == null)
                {
                    this.mercadoCenarioRepository = new GenericRepository<MercadoCenario>(_dbContext);
                }
                return mercadoCenarioRepository;
            }
        }
        public IGenericRepository<MercadoContrato> MercadoContratoRepository
        {
            get
            {

                if (this.mercadoContratoRepository == null)
                {
                    this.mercadoContratoRepository = new GenericRepository<MercadoContrato>(_dbContext);
                }
                return mercadoContratoRepository;
            }
        }
        public IGenericRepository<Entidade> EntidadeRepository
        {
            get
            {

                if (this.entidadeRepository == null)
                {
                    this.entidadeRepository = new GenericRepository<Entidade>(_dbContext);
                }
                return entidadeRepository;
            }
        }

        public IGenericRepository<TipoArmazenamento> TipoArmazenamentoRepository
        {
            get
            {

                if (this.tipoArmazenamentoRepository == null)
                {
                    this.tipoArmazenamentoRepository = new GenericRepository<TipoArmazenamento>(_dbContext);
                }
                return tipoArmazenamentoRepository;
            }
        }




        #region Methods



        public string Fn_find_NovoCodigoById(int tipoEntidadeId, int topologiaId)
        {
            try
            {
                string novoCodigo = null;

                string prefixo = TipoEntidadeRepository.Get(y => y.Id == tipoEntidadeId).FirstOrDefault().Prefixo;

                if (!string.IsNullOrEmpty(prefixo))
                    novoCodigo = Fn_get_CodigoByTipoEntidadeId(tipoEntidadeId, topologiaId, prefixo);

                return novoCodigo;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public string Fn_get_CodigoByTipoEntidadeId(int tipoEntidadeid, int topologiaId, string prefixo)
        {
            int novoId;
            string novoCodigo;
            //novoId = Entidades(topologiaId, "", prefixo, tipoEntidadeid) + 1;

            novoId = EntidadeRepository.EntidadesEntity($"y => y.TipoEntidadeId == {tipoEntidadeid} && y.TopologiaId == {topologiaId}").Result.Count() + 1;
            //Pega os códigos das entidades e insere +1 para criar o novo código
            novoCodigo = Fn_get_CodigoById(prefixo, novoId, topologiaId);

            while (novoCodigo == null)
            {
                novoId += 1;
                novoCodigo = Fn_get_CodigoById(prefixo, novoId, topologiaId);
            }
            return novoCodigo;
        }
        public string Fn_get_CodigoById(string prefixo, int novoId, int topologiaId)
        {
            string novoCodigo = string.Format("{0}{1}", prefixo, novoId);

            //Verifica se o código criado existe nas entidades com a topologia
            //if (Entidades(topologiaId, novoCodigo, prefixo, default(int)) > 0)
            if (EntidadeRepository.EntidadesEntity($@"y => y.TopologiaId == {topologiaId} && y.Codigo == ""{novoCodigo}""").Result.Count() > 0)
                return null;

            return novoCodigo;
        }
        public int EntidadeCorrente(int topologiaid, string novoCodigo, string prefixo, int? tipoEntidadeId = null)
        {

            //Para insert de corrente só precisa verificar a tabela de corrente que é onde tem a chave composta(código, tipoentidade, topologia)
            //assim evitando o buscar em varias outras tabelas sem necessidade. fazer isso para as demais entidades;

            int id = 0;
            return id += CorrenteRepository.Get(y => y.Codigo == (novoCodigo == "" ? y.Codigo : novoCodigo) && y.TipoEntidadeId == (tipoEntidadeId > 0 ? tipoEntidadeId : y.TipoEntidadeId) && y.TopologiaId == topologiaid).ToList().Select(H => H.Id).Count();
        }
        public List<Produto> GetProdutoNo(Int32 noId)
        {
            try
            {
                //vw_NoProduto

                //Codigo estava funcionando, mas comecou a da Timeout, Verificar depois
                //TODO
                //var noProduto = (from n in NoRepository.Get()
                //                 join np in NoProdutoRepository.Get() on n.Id equals np.NoId
                //                 join cp in CorrenteProdutoRepository.Get() on np.ProdutoId equals cp.ProdutoId
                //                 join c in CorrenteRepository.Get() on new { a = cp.CorrenteId, b = n.Id } equals new { a = c.Id, b = c.SaidaId }
                //                 select new
                //                 {
                //                     NoId = n.Id,
                //                     np.ProdutoId
                //                 }).Select(y => new { y.NoId, y.ProdutoId }).Distinct().AsQueryable();

                //List<Produto> produtosSelect = (from p in ProdutoRepository.Get()

                //                                join np in NoProdutoRepository.Get() on p.Id equals np.ProdutoId

                //                                join n in NoRepository.Get() on np.NoId.Value equals n.Id

                //                                join tp in TipoProdutoRepository.Get() on p.TipoEntidadeId equals tp.Id

                //                                join vnp in noProduto.ToList() on new { a = np.ProdutoId, b = (int?)np.NoId.Value } equals new { a = vnp.ProdutoId, b = (int?)vnp.NoId } into x
                //                                from vnpp in x.DefaultIfEmpty()

                //                                where n.Id == noId
                //                                select new Produto
                //                                {
                //                                    Id = p.Id,
                //                                    Codigo = p.Codigo,
                //                                    Descricao = p.Descricao,
                //                                    TipoProdutoNome = tp.Nome,
                //                                    ProdutoCorrente = vnpp.ProdutoId
                //                                }).ToList();

                #region Proc

                List<Produto> produtosSelect = new List<Produto>();
                using (var context = new VCMContext())
                using (var command = context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = string.Format("exec [pr_VCM_NoProdutoSelect] {0}", noId);
                    context.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        Int32 ordId = result.GetOrdinal("Id");
                        Int32 ordCodigo = result.GetOrdinal("Codigo");
                        Int32 ordDescricao = result.GetOrdinal("Descricao");
                        Int32 ordTipoProdutoNome = result.GetOrdinal("TipoProdutoNome");
                        Int32 ordProdutoCorrente = result.GetOrdinal("ProdutoCorrente");
                        while (result.Read())
                        {

                            produtosSelect.Add(
                            new Produto
                            {
                                Id = result.GetInt32(ordId),
                                Codigo = result.GetString(ordCodigo),
                                Descricao = result.GetStringOrNull(ordDescricao),
                                TipoProdutoNome = result.GetString(ordTipoProdutoNome),
                                ProdutoCorrente = result.GetInt32OrNull(ordProdutoCorrente)

                            });
                        }

                    }
                }
                #endregion

                return produtosSelect;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public class ProdutoDelete
        {
            public int Id { get; set; }
            public int TipoEntidadeId { get; set; }
        }



        public bool pr_VCM_NoProdutosUpdate(int id, string codigo, string descricao, int tipoEntidadeId, int topologiaId, string localizacao, string nota, int[] posted)
        {
            var commandText = "declare @p8 dbo.RelacaoType ";
            foreach (var item in posted)
                commandText += $" insert into @p8 values({item})";

            string localizacaotext = !string.IsNullOrEmpty(localizacao) ? $"'{localizacao}'" : "null";

            using (var context = new VCMContext())
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = $"{commandText} exec [pr_VCM_NoProdutosUpdate] {id},'{codigo}','{descricao}',{tipoEntidadeId},{topologiaId}, {localizacaotext},'{nota}',@p8";
                context.Database.OpenConnection();
                command.ExecuteReader();
            }

            return true;

            //TODO:Nao deletar, continuar escrevendo o código da procedure

            //var noProduto = (from n in NoRepository.Get()
            //                 join np in NoProdutoRepository.Get() on n.Id equals np.NoId
            //                 join cp in CorrenteProdutoRepository.Get() on np.ProdutoId equals cp.ProdutoId
            //                 join c in CorrenteRepository.Get() on new { a = cp.CorrenteId, b = n.Id } equals new { a = c.Id, b = c.SaidaId }
            //                 where n.Id == id
            //                 select new
            //                 {
            //                     NoId = n.Id,
            //                     np.ProdutoId
            //                 }).Select(y => new { y.NoId, y.ProdutoId }).Distinct().ToList();


            //List<ProdutoDelete> ProdutosExcluidos = (from p in ProdutoRepository.Get()
            //                                         join np in NoProdutoRepository.Get() on p.Id equals np.ProdutoId
            //                                         where np.NoId == id && !posted.Contains(np.ProdutoId)
            //                                         where np.NoId == id && !noProduto.Select(y => y.ProdutoId).Contains(np.ProdutoId)
            //                                         select new ProdutoDelete
            //                                         {
            //                                             Id = p.Id,
            //                                             TipoEntidadeId = p.TipoEntidadeId
            //                                         }).Distinct().ToList();

            //List<KeyValuePair<int, int>> produtosPDeletar = new List<KeyValuePair<int, int>>();
            //foreach (var item in ProdutosExcluidos)
            //    produtosPDeletar.Add(new KeyValuePair<int, int>(item.Id, (int)item.TipoEntidadeId));


            //pr_NoUpdate(id, codigo, descricao, tipoEntidadeId, topologiaId, localizacao, nota, produtosPDeletar);
        }
        public bool pr_VCM_NoUpdate(int id, string codigo, string descricao, int tipoEntidadeId, int topologiaId, string localizacao, string nota)
        {
            string localizacaotext = !string.IsNullOrEmpty(localizacao) ? $"'{localizacao}'" : "null";
            using (var context = new VCMContext())
            {
                using (var command = context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = $"exec [pr_VCM_NoUpdate] {id},'{codigo}','{descricao}',{tipoEntidadeId},{topologiaId},{localizacaotext},'{nota}'";
                    context.Database.OpenConnection();
                    command.ExecuteReader();

                    command.Dispose();
                    command.Connection.Close();

                }
                context.SaveChangesAsync();
                context.Database.CloseConnection();
                context.Dispose();
            }

            #region

            //TODO:Cristovão 29/03/2020
            //Estre trecho de código foi feito devido os valores serem atualziados via Procedure, com isso o cache do UnitofWork 
            //nao era atualizado e seu valor continuava com o antigo

            this.noRepository = new GenericRepository<No>(_dbContext);
            this.entradaRepository = new GenericRepository<Entrada>(_dbContext);
            this.calculoRepository = new GenericRepository<Calculo>(_dbContext);
            this.noProdutoRepository = new GenericRepository<NoProduto>(_dbContext);
            this.correnteRepository = new GenericRepository<Corrente>(_dbContext);
            this.correnteProdutoRepository = new GenericRepository<CorrenteProduto>(_dbContext);
            #endregion



            //TODO: Não deletar, Continuar escrevendo a Proc
            //List<NoProduto> produtosExcluidos = no.NoProduto.Where(y => !model.Items.Posted.Contains(y.ProdutoId)).ToList();

            //foreach (NoProduto noProduto in produtosExcluidos)
            //    no.NoProduto.Remove(noProduto);

            //List<int> produtosExcluidos = new List<int>();
            //pr_NoUpdate(id, codigo, descricao, tipoEntidadeId, topologiaId, localizacao, nota, produtosExcluidos);

            return true;
        }

        public bool pr_CorrenteProdutoClear(int correnteId, int topologiaId, List<KeyValuePair<int, int>> produtosExcluidos)
        {
            using (var context = new VCMContext())
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = string.Format("exec [pr_CorrenteProdutoClear] {0}, {1}, {2}", correnteId, topologiaId, produtosExcluidos);
                context.Database.OpenConnection();
                command.ExecuteReader();
            }
            return true;
        }
        //public bool pr_NoUpdate(int id, string codigo, string descricao, int tipoEntidadeId, int topologiaId, string localizacao, string nota, List<KeyValuePair<int, int>> produtosPExcluir)
        //{

        //    LocalizacaoExiste(localizacao, topologiaId);

        //    ValoresUpdate(id, topologiaId, codigo, tipoEntidadeId);

        //    var noUpdate = noRepository.Get(y => y.Id == id).FirstOrDefault();
        //    noUpdate.Codigo = codigo;
        //    noUpdate.Descricao = descricao;
        //    noUpdate.Nota = nota;
        //    noUpdate.Localizacao = localizacao;

        //    noRepository.Update(noUpdate);

        //    pr_NoProdutoClear(produtosPExcluir, id, topologiaId);

        //    List<Corrente> correntes = correnteRepository.Get(y => y.EntradaId == id).ToList();

        //    foreach (var oneCorrente in correntes)
        //        pr_CorrenteProdutoClear(oneCorrente.Id, topologiaId, produtosPExcluir);

        //    return true;
        //}

        //public bool pr_NoProdutoClear(List<KeyValuePair<int, int>> produtosExcluidos, int noId, int topologiaId)
        //{

        //    string noCodigo = NoRepository.Get(y => y.Id == noId).Select(y => y.Codigo).FirstOrDefault();
        //    foreach (var item in produtosExcluidos)
        //    {
        //        noProdutoRepository.Delete(noProdutoRepository.Get(y => y.NoId == noId && y.ProdutoId == item.Key).FirstOrDefault());
        //        pr_ValoresClear(item.Key, 1, topologiaId, noCodigo);
        //    }

        //    var correntes = CorrenteRepository.Get(y => y.EntradaId == noId).ToList();
        //    return true;
        //}
        public bool pr_ValoresClear(int id, int tipoEntidadeId, int topologiaId, string entidadeCodigoRaiz)
        {
            try
            {
                //string exp = $"y => y.Id == {id} && y.TipoEntidadeId == {tipoEntidadeId} && y.TopologiaId == {topologiaId}";
                //var entrada = (from [pr_VCM_NoProdutosUpdate] in EntradaRepository.Get()
                //               join ves in EntidadeSimbolo(exp).ToList() on e.SimboloId equals ves.SimboloId
                //               join t in TopologiaRepository.Get(y => y.Id == topologiaId) on ves.TopologiaId equals t.Id
                //               join c in CenarioRepository.Get() on t.Id equals c.TopologiaId
                //               where e.CenarioId == c.Id && e.EntidadesCodigos.Contains($"{ves.Dimensao}>{ves.Codigo}<")
                //               select new Entrada
                //               {
                //                   Id = e.Id
                //               }).ToList();

                using (var context = new VCMContext())
                using (var command = context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = string.Format("exec [pr_ValoresClear] {0}, {1}, {2}, '{3}'", id, tipoEntidadeId, topologiaId, entidadeCodigoRaiz);
                    context.Database.OpenConnection();
                    command.ExecuteReader();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool CreateEntrada(int cenarioId, int tipovalorId, int cadeiaId)
        {
            try
            {
                List<Entrada> entradas = (from p in simboloRepository.Get(y => y.CadeiaId == cadeiaId && y.Default != null)
                                          select new Entrada
                                          {
                                              CenarioId = cenarioId,
                                              TipoValorId = tipovalorId,
                                              SimboloId = p.Id,
                                              Grandeza = Convert.ToDecimal(p.Default)
                                          }).ToList();

                this.entradaRepository.InsertRange(entradas);
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }




        }
        public List<Entidade> PropriedadeEntidade(Expression<Func<PropriedadeTopologia, bool>> propExpree,
                                                       Expression<Func<TipoEntidade, bool>> tipoEExpree)
        {
            VCMContext _context = new VCMContext();
            List<Entidade> asda = new List<Entidade>();
            try
            {
                //[vw_PropriedadeEntidade]
                asda = (from p in _context.Propriedade
                        join pt in _context.PropriedadeTopologia.Where(propExpree) on p.Id equals pt.PropriedadeId
                        join te in _context.TipoEntidade.Where(tipoEExpree) on new { a = "Propriedade" } equals new { a = te.Nome }
                        where p.TipoPropriedadeId != null
                        select new Entidade { Id = pt.Id }).ToList();

            }
            catch (Exception ex)
            {

                throw;
            }



            return asda;
        }
        //public IQueryable<MedidaEntidades> GetMedidaEntidades()
        //{
        //    try
        //    {
        //        //vw_MedidaEntidades
        //        return (from f in FamiliaRepository.Get()
        //                join tp in TipoProdutoRepository.Get() on f.TipoProdutoId equals tp.Id

        //                join um in UnidadeMedidaRepository.Get() on tp.TipoUnidadeId equals um.TipoUnidadeId

        //                join mp in MedidaProjetoList().ToList() on new { a = um.TipoUnidadeId, b = um.Id, c = f.TopologiaId }
        //                                                    equals new { a = mp.TipoUnidadeId, b = mp.UnidadeMedidaId, c = mp.TopologiaID }
        //                select new MedidaEntidades
        //                {
        //                    TopologiaId = f.TopologiaId,
        //                    Codigo = f.Codigo,
        //                    TipoEntidadeId = f.TipoEntidadeId,
        //                    UnidadeMedidaId = mp.UnidadeMedidaId
        //                }).Concat((from p in ProdutoRepository.Get()
        //                           select new MedidaEntidades
        //                           {
        //                               TopologiaId = p.Id,
        //                               Codigo = p.Codigo,
        //                               TipoEntidadeId = p.TipoEntidadeId,
        //                               UnidadeMedidaId = p.UnidadeMedidaId
        //                           })).AsQueryable();


        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}
        public IQueryable<MedidaProjeto> MedidaProjetoList()
        {
            //vw_MedidaProjeto
            try
            {
                IQueryable<MedidaProjeto> medidaProjetoQuery = MedidaProjetoRepository.Get()
                    .Join(UnidadeMedidaRepository.Get(), medidaProjeto => medidaProjeto.UnidadeMedidaId, unidadeMedida => unidadeMedida.Id, (medidaProjeto, unidadeMedida) => new { medidaProjeto, unidadeMedida })
                    .Join(TopologiaRepository.Get(), medidaprojeto => medidaprojeto.medidaProjeto.ProjetoId, topologia => topologia.ProjetoId, (medidaprojeto, topologia) => new { medidaprojeto, topologia })
                    .Select(x => new MedidaProjeto
                    {
                        ProjetoId = x.topologia.ProjetoId,
                        TopologiaID = x.topologia.Id,
                        TipoUnidadeId = x.medidaprojeto.unidadeMedida.TipoUnidadeId,
                        UnidadeMedidaId = x.medidaprojeto.medidaProjeto.UnidadeMedidaId
                    }).AsQueryable();
                return medidaProjetoQuery;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        //public List<EntidadeSimbolo> EntidadeSimbolo(string exp)
        //{
        //    //vw_entidadesimbolo

        //    //"y => y.Id == 33503 && y.TipoEntidadeId == 223 && y.TopologiaId == 6116"

        //    List<EntidadeSimbolo> entidades = new List<EntidadeSimbolo>();
        //    try
        //    {
        //        entidades = (from es in EntidadeSimboloRepository.Get()
        //                     join ve in EntidadeRepository.EntidadesEntity(exp).Result
        //                     on es.TipoEntidadeId equals ve.TipoEntidadeId


        //                     join numerador in GetMedidaEntidades().ToList() on new { a = es.UnidadeNumerador, b = ve.TopologiaId, c = ve.TipoEntidadeId }
        //                                                                 equals new { a = Convert.ToBoolean(1), b = numerador.TopologiaId, c = numerador.TipoEntidadeId } into x
        //                     from numeradorX in x.DefaultIfEmpty()


        //                     join denominador in GetMedidaEntidades().ToList() on new { a = es.UnidadeDenominador, b = ve.TopologiaId, c = ve.TipoEntidadeId }
        //                                                                 equals new { a = Convert.ToBoolean(1), b = denominador.TopologiaId, c = denominador.TipoEntidadeId } into w
        //                     from denominadorx in w.DefaultIfEmpty()

        //                     select new EntidadeSimbolo
        //                     {
        //                         TopologiaId = ve.TopologiaId,
        //                         SimboloId = es.SimboloId,
        //                         TipoEntidadeId = ve.TipoEntidadeId,
        //                         Dimensao = es.Dimensao,
        //                         Codigo = ve.Codigo

        //                     }).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //    return entidades;
        //}
        public bool ValoresUpdate(int id, int topologiaId, string codigo, int tipoEntidadeId)
        {
            //pr_ValoresUpdate
            try
            {
                using (var context = new VCMContext())
                using (var command = context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = string.Format("exec [pr_ValoresUpdate] {0}, {1}, {2}, {3}", id, topologiaId, codigo, tipoEntidadeId);
                    context.Database.OpenConnection();
                    command.ExecuteReader();

                }
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool LocalizacaoExiste(string localizazao, int topologiaId)
        {
            if (EstadoRepository.Count(y => y.Sigla == localizazao && y.TopologiaId == topologiaId) > 0
                || PaisRepository.Count(y => y.Codigo == localizazao && y.TopologiaId == topologiaId) > 0)
                return true;

            return false;

        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (_dbContext != null)
                        _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        //public int Entidades(int topologiaId, string novoCodigo, string prefixo, int? tipoEntidadeId = null)
        //{

        //    int id = 0;

        //    if (string.IsNullOrEmpty(novoCodigo))
        //        id += EstadoRepository.Get(y => y.TipoEntidadeId == (tipoEntidadeId > 0 ? tipoEntidadeId : y.TipoEntidadeId) && y.TopologiaId == topologiaId).ToList().Select(H => H.Id).Count();

        //    id += CorrenteRepository.Get(y => y.Codigo == (novoCodigo == "" ? y.Codigo : novoCodigo) && y.TipoEntidadeId == (tipoEntidadeId > 0 ? tipoEntidadeId : y.TipoEntidadeId) && y.TopologiaId == topologiaId).ToList().Select(H => H.Id).Count();
        //    id += BlendRepository.Get(y => y.Codigo == (!string.IsNullOrEmpty(novoCodigo) ? novoCodigo : y.Codigo) && y.TipoEntidadeId == (tipoEntidadeId > 0 ? tipoEntidadeId : y.TipoEntidadeId) && y.TopologiaId == topologiaId).ToList().Select(H => H.Id).Count();
        //    id += ConjuntoRepository.Get(y => y.Codigo == (!string.IsNullOrEmpty(novoCodigo) ? novoCodigo : y.Codigo) && y.TipoEntidadeId == (tipoEntidadeId > 0 ? tipoEntidadeId : y.TipoEntidadeId) && y.TopologiaId == topologiaId).ToList().Select(H => H.Id).Count();
        //    id += ContratoRepository.Get(y => y.Codigo == (!string.IsNullOrEmpty(novoCodigo) ? novoCodigo : y.Codigo) && y.TipoEntidadeId == (tipoEntidadeId > 0 ? tipoEntidadeId : y.TipoEntidadeId) && y.TopologiaId == topologiaId).ToList().Select(H => H.Id).Count();
        //    id += DescontoRepository.Get(y => y.Codigo == (!string.IsNullOrEmpty(novoCodigo) ? novoCodigo : y.Codigo) && y.TipoEntidadeId == (tipoEntidadeId > 0 ? tipoEntidadeId : y.TipoEntidadeId) && y.TopologiaId == topologiaId).ToList().Select(H => H.Id).Count();
        //    id += FaixaDescontoRepository.Get(y => y.Codigo == (!string.IsNullOrEmpty(novoCodigo) ? novoCodigo : y.Codigo) && y.TipoEntidadeId == (tipoEntidadeId > 0 ? tipoEntidadeId : y.TipoEntidadeId) && y.TopologiaId == topologiaId).ToList().Select(H => H.Id).Count();
        //    id += FaixaCustoFixoRepository.Get(y => y.Codigo == (!string.IsNullOrEmpty(novoCodigo) ? novoCodigo : y.Codigo) && y.TipoEntidadeId == (tipoEntidadeId > 0 ? tipoEntidadeId : y.TipoEntidadeId) && y.TopologiaId == topologiaId).ToList().Select(H => H.Id).Count();
        //    id += FamiliaRepository.Get(y => y.TipoEntidadeId == (tipoEntidadeId > 0 ? tipoEntidadeId : y.TipoEntidadeId) && y.TopologiaId == topologiaId).ToList().Select(H => H.Id).Count();
        //    id += PaisRepository.Get(y => y.Codigo == (!string.IsNullOrEmpty(novoCodigo) ? novoCodigo : y.Codigo) && y.TipoEntidadeId == (tipoEntidadeId > 0 ? tipoEntidadeId : y.TipoEntidadeId) && y.TopologiaId == topologiaId).ToList().Select(H => H.Id).Count();


        //    //Corrigir aqui quando cria o periogo
        //    id += PeriodoRepository.Get(y => y.Codigo == (!string.IsNullOrEmpty(novoCodigo) ? novoCodigo : y.Codigo) && y.TipoEntidadeId == (tipoEntidadeId > 0 ? tipoEntidadeId : y.TipoEntidadeId) && y.TopologiaId == topologiaId).ToList().Select(H => H.Id).Count();
        //    id += PeriodoRepository.Get(y => y.TipoEntidadeId == (tipoEntidadeId > 0 ? tipoEntidadeId : y.TipoEntidadeId) && y.TopologiaId == topologiaId).ToList().Select(H => H.Id).Count();



        //    id += PeriodoAgregadoRepository.Get(y => y.Codigo == (!string.IsNullOrEmpty(novoCodigo) ? novoCodigo : y.Codigo) && y.TipoEntidadeId == (tipoEntidadeId > 0 ? tipoEntidadeId : y.TipoEntidadeId) && y.TopologiaId == topologiaId).ToList().Select(H => H.Id).Count();
        //    id += PrecobaseRepository.Get(y => y.Codigo == (!string.IsNullOrEmpty(novoCodigo) ? novoCodigo : y.Codigo) && y.TipoEntidadeId == (tipoEntidadeId > 0 ? tipoEntidadeId : y.TipoEntidadeId) && y.TopologiaId == topologiaId).ToList().Select(H => H.Id).Count();
        //    id += ProdutoRepository.Get(y => y.Codigo == (!string.IsNullOrEmpty(novoCodigo) ? novoCodigo : y.Codigo) && y.TipoEntidadeId == (tipoEntidadeId > 0 ? tipoEntidadeId : y.TipoEntidadeId) && y.TopologiaId == topologiaId).ToList().Select(H => H.Id).Count();
        //    id += RegiaoRepository.Get(y => y.Codigo == (!string.IsNullOrEmpty(novoCodigo) ? novoCodigo : y.Codigo) && y.TipoEntidadeId == (tipoEntidadeId > 0 ? tipoEntidadeId : y.TipoEntidadeId) && y.TopologiaId == topologiaId).ToList().Select(H => H.Id).Count();
        //    id += RestricaoRepository.Get(y => y.Codigo == (!string.IsNullOrEmpty(novoCodigo) ? novoCodigo : y.Codigo) && y.TipoEntidadeId == (tipoEntidadeId > 0 ? tipoEntidadeId : y.TipoEntidadeId) && y.TopologiaId == topologiaId).ToList().Select(H => H.Id).Count();
        //    id += SiloRepository.Get(y => y.Codigo == (!string.IsNullOrEmpty(novoCodigo) ? novoCodigo : y.Codigo) && y.TipoEntidadeId == (tipoEntidadeId > 0 ? tipoEntidadeId : y.TipoEntidadeId) && y.TopologiaId == topologiaId).ToList().Select(H => H.Id).Count();
        //    id += ValvulaRepository.Get(y => y.Codigo == (!string.IsNullOrEmpty(novoCodigo) ? novoCodigo : y.Codigo) && y.TipoEntidadeId == (tipoEntidadeId > 0 ? tipoEntidadeId : y.TipoEntidadeId) && y.TopologiaId == topologiaId).ToList().Select(H => H.Id).Count();
        //    id += NoRepository.Get(y => y.Codigo == (!string.IsNullOrEmpty(novoCodigo) ? novoCodigo : y.Codigo) && y.TipoEntidadeId == (tipoEntidadeId > 0 ? tipoEntidadeId : y.TipoEntidadeId) && y.TopologiaId == topologiaId).ToList().Select(H => H.Id).Count();


        //    //vw_PropriedadeEntidade
        //    var propriedadeEntidade =
        //                             from p in PropriedadeRepository.Get()
        //                             join pt in PropriedadeTopologiaRepository.Get()
        //                             on p.Id equals pt.PropriedadeId
        //                             from t in TipoEntidadeRepository.GetWithFilter(y => y.Nome == "Propriedade")
        //                             where p.TipoPropriedadeId != null
        //                             select new { pt.Id, Codigo = p.Nome, Descricao = (string)null, pt.TopologiaId, TipoEntidadeId = t.Id };

        //    id += propriedadeEntidade.ToList().Where(y => y.TopologiaId == topologiaId && y.TipoEntidadeId == tipoEntidadeId
        //                                              && y.Codigo == (!string.IsNullOrEmpty(novoCodigo) ? novoCodigo : y.Codigo)).Count();

        //    return id;

        //}

        public List<EntradaHelper> GetValuesFromProcedure(int scenarioId, string code, List<Simbolo> simbols, int entityType, bool detailed, bool exactValue)
        {
            List<EntradaHelper> entries = new List<EntradaHelper>();

            using (var context = new VCMContext())
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                DataTable dt = GetDatatableFromSimbols(simbols);

                command.CommandText = "pr_VCM_EntradaSelectBySimbolosWithFilter";
                command.Parameters.Add(new SqlParameter("@CenarioId", SqlDbType.Int) { Value = scenarioId });
                command.Parameters.Add(new SqlParameter("@EntidadeRaizCodigo", SqlDbType.VarChar) { Value = code });
                command.Parameters.Add(new SqlParameter("@Simbolos", SqlDbType.Structured) { Value = dt });
                command.Parameters.Add(new SqlParameter("@TipoEntidade", SqlDbType.Int) { Value = entityType });
                command.Parameters.Add(new SqlParameter("@Detalhado", SqlDbType.Bit) { Value = detailed });
                command.Parameters.Add(new SqlParameter("@ValorExato", SqlDbType.Bit) { Value = exactValue });

                command.CommandType = CommandType.StoredProcedure;

                context.Database.OpenConnection();
                command.CommandTimeout = 999999;
                var returnValue = command.ExecuteReader();

                while (returnValue.Read())
                {
                    int id = Convert.ToInt32(returnValue["Id"].ToString());
                    int simboloId = Convert.ToInt32(returnValue["SimboloId"].ToString());
                    decimal grandeza = Convert.ToDecimal(returnValue["Grandeza"].ToString());
                    int tipoValorId = Convert.ToInt32(returnValue["TipoValorId"].ToString());
                    string entidadeCodigo1 = returnValue["EntidadeCodigo1"].ToString();
                    string entidadeCodigo2 = returnValue["EntidadeCodigo2"].ToString();
                    string entidadeCodigo3 = returnValue["EntidadeCodigo3"].ToString();
                    string entidadeCodigo4 = returnValue["EntidadeCodigo4"].ToString();
                    string entidadeCodigo5 = returnValue["EntidadeCodigo5"].ToString();
                    string entidadeCodigo6 = returnValue["EntidadeCodigo6"].ToString();
                    string umNumeradorId = returnValue["UnidadeMedidaNumeradorId"].ToString();
                    string umDenominadorId = returnValue["UnidadeMedidaDenominadorId"].ToString();
                    int? unidadeMedidaNumeradorId = string.IsNullOrEmpty(umNumeradorId) ? (int?)null : Convert.ToInt32(umNumeradorId);
                    int? unidadeMedidaDenominadorId = string.IsNullOrEmpty(umDenominadorId) ? (int?)null : Convert.ToInt32(umDenominadorId);

                    EntradaHelper entry = new EntradaHelper(id, tipoValorId, simboloId, grandeza
                        , entidadeCodigo1, entidadeCodigo2, entidadeCodigo3
                        , entidadeCodigo4, entidadeCodigo5, entidadeCodigo6
                        , unidadeMedidaNumeradorId, unidadeMedidaDenominadorId);

                    entries.Add(entry);
                }
            }
            return entries;
        }
        public void pr_VCM_EntradaEdit(List<Entrada> entradas)
        {
            using (var context = new VCMContext())
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                DataTable dt = GetDatatableEntrada(entradas);

                command.CommandText = "pr_VCM_EntradaEdit";
                command.Parameters.Add(new SqlParameter("@Entradas", SqlDbType.Structured) { Value = dt });

                command.CommandType = CommandType.StoredProcedure;

                context.Database.OpenConnection();
                command.CommandTimeout = 999999;
                var returnValue = command.ExecuteReader();
            }
        }

        private static DataTable GetDatatableFromSimbols(List<Simbolo> simbols)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(Int32));
            foreach (Simbolo oneSimbol in simbols)
            {
                DataRow dataRow = dt.NewRow();
                dataRow["Id"] = oneSimbol.Id;
                dt.Rows.Add(dataRow);
            }
            return dt;
        }

        private static DataTable GetDatatableEntrada(List<Entrada> entrada)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(Int32));
            dt.Columns.Add("CenarioId", typeof(Int32));
            dt.Columns.Add("SimboloId", typeof(Int32));
            dt.Columns.Add("TipoValorId", typeof(Int32));
            dt.Columns.Add("Grandeza", typeof(decimal));
            dt.Columns.Add("EntidadeCodigo1", typeof(string));
            dt.Columns.Add("EntidadeCodigo2", typeof(string));
            dt.Columns.Add("EntidadeCodigo3", typeof(string));
            dt.Columns.Add("EntidadeCodigo4", typeof(string));
            dt.Columns.Add("EntidadeCodigo5", typeof(string));
            dt.Columns.Add("EntidadeCodigo6", typeof(string));

            foreach (Entrada oneEntrada in entrada)
            {
                DataRow dataRow = dt.NewRow();
                dataRow["Id"] = oneEntrada.Id;
                dataRow["CenarioId"] = oneEntrada.CenarioId;
                dataRow["SimboloId"] = oneEntrada.SimboloId;
                dataRow["TipoValorId"] = oneEntrada.TipoValorId;
                dataRow["Grandeza"] = oneEntrada.Grandeza;
                dataRow["EntidadeCodigo1"] = oneEntrada.EntidadeCodigo1;
                dataRow["EntidadeCodigo2"] = oneEntrada.EntidadeCodigo2;
                dataRow["EntidadeCodigo3"] = oneEntrada.EntidadeCodigo3;
                dataRow["EntidadeCodigo4"] = oneEntrada.EntidadeCodigo4;
                dataRow["EntidadeCodigo5"] = oneEntrada.EntidadeCodigo5;
                dataRow["EntidadeCodigo6"] = oneEntrada.EntidadeCodigo6;
                dt.Rows.Add(dataRow);
            }
            return dt;
        }

        #endregion
        #region Teste
        public List<Projeto> DapperProjetoList()
        {
            List<Projeto> projetos = new List<Projeto>();
            using (var context = new VCMContext())
            using (IDbConnection conn = context.Database.GetDbConnection())
            {
                string sQuery = "Select * from Projeto";
                //conn.Open();
                var result = conn.Query<Projeto>(sQuery);
                projetos = result.ToList();
            }
            return projetos;
        }

        public List<Cenario> DapperCenarioOneToMaanyList()
        {
            List<Cenario> cenarios = new List<Cenario>();


            string sQuery = "Select * from Cenario c inner join Topologia t on c.TopologiaId = t.Id";

            using (var context = new VCMContext())
            using (IDbConnection conn = context.Database.GetDbConnection())
            {
                cenarios = conn.Query<Cenario, Topologia, Cenario>(
               sQuery,
               (invoice, invoiceDetail) =>
               {
                   invoice.Topologia = invoiceDetail;
                   return invoice;
               },
                splitOn: "TopologiaId").Distinct().ToList();
            }
            return cenarios;
        }

        public List<EntidadeSimbolo> EntidadeSimbolo()
        {
            throw new NotImplementedException();
        }



        public void pr_VCM_EntradaEdit()
        {

        }

        #endregion

    }
}
