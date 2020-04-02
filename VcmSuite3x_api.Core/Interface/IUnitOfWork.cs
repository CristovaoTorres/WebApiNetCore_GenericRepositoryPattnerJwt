using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VcmSuite3x_api.Core.Helper;
using VcmSuite3x_api.Core.Models;
using static VcmSuite3x_api.Core.Repository.UnitOfWork;

namespace VcmSuite3x_api.Core.Interface
{
    public interface IUnitOfWork
    {
        IGenericRepository<Topologia> TopologiaRepository { get; }
        IGenericRepository<TipoUnidade> TipoUnidadeRepository { get; }
        IGenericRepository<Produto> ProdutoRepository { get; }
        IGenericRepository<UnidadeMedida> UnidadeMedidaRepository { get; }
        IGenericRepository<No> NoRepository { get; }
        IGenericRepository<Contrato> ContratoRepository { get; }
        IGenericRepository<TipoEntidade> TipoEntidadeRepository { get; }
        IGenericRepository<CorrenteProduto> CorrenteProdutoRepository { get; }
        IGenericRepository<NoDrawing> NoDrawingRepository { get; }
        IGenericRepository<FluxogramaDrawing> FluxogramaDrawingRepository { get; }
        IGenericRepository<PortaDrawing> PortaDrawingRepository { get; }
        IGenericRepository<CorrenteDrawing> CorrenteDrawingRepository { get; }
        IGenericRepository<NoProduto> NoProdutoRepository { get; }
        IGenericRepository<Corrente> CorrenteRepository { get; }
        IGenericRepository<TipoProduto> TipoProdutoRepository { get; }
        IGenericRepository<Familia> FamiliaRepository { get; }
        IGenericRepository<NoFamilia> NoFamiliaRepository { get; }
        IGenericRepository<ProdutoFamilia> ProdutoFamiliaRepository { get; }
        IGenericRepository<ProdutoContrato> ProdutoContratoRepository { get; }
        IGenericRepository<FamiliaContrato> FamiliaContratoRepository { get; }
        IGenericRepository<Projeto> ProjetoRepository { get; }
        IGenericRepository<MedidaProjeto> MedidaProjetoRepository { get; }
        IGenericRepository<TemplateMedida> TemplateMedidaRepository { get; }
        IGenericRepository<ElementoTipoProduto> ElementoTipoProdutoRepository { get; }
        IGenericRepository<TipoValor> TipoValorRepository { get; }
        IGenericRepository<Cadeia> CadeiaRepository { get; }
        IGenericRepository<Cenario> CenarioRepository { get; }
        IGenericRepository<TipoPropriedade> TipoPropriedadeRepository { get; }
        IGenericRepository<Propriedade> PropriedadeRepository { get; }
        IGenericRepository<Simbolo> SimboloRepository { get; }
        IGenericRepository<Entrada> EntradaRepository { get; }
        IGenericRepository<PropriedadeTopologia> PropriedadeTopologiaRepository { get; }
        IGenericRepository<Periodo> PeriodoRepository { get; }
        IGenericRepository<PeriodoAgregadoItem> PeriodoAgregadoItemRepository { get; }
        IGenericRepository<PeriodoCenario> PeriodoCenarioRepository { get; }
        IGenericRepository<DiagramaCenario> DiagramaCenarioRepository { get; }
        IGenericRepository<CorrenteCenario> CorrenteCenarioRepository { get; }
        IGenericRepository<CorrenteCenarioLimite> CorrenteCenarioLimiteRepository { get; }
        IGenericRepository<CorrenteCenarioSimbolo> CorrenteCenarioSimboloRepository { get; }
        IGenericRepository<NoCenarioLimite> NoCenarioLimiteRepository { get; }
        IGenericRepository<NoCenarioSimbolo> NoCenarioSimboloRepository { get; }
        IGenericRepository<ArmazenamentoCenario> ArmazenamentoCenarioRepository { get; }
        IGenericRepository<TipoArmazenamento> TipoArmazenamentoRepository { get; }
        IGenericRepository<DivisorCenario> DivisorCenarioRepository { get; }
        IGenericRepository<FornecimentoCenario> FornecimentoCenarioRepository { get; }
        IGenericRepository<MercadoCenario> MercadoCenarioRepository { get; }
        IGenericRepository<ProcessamentoCenario> ProcessamentoCenarioRepository { get; }
        IGenericRepository<UnificadorCenario> UnificadorCenarioRepository { get; }
        IGenericRepository<PortoCenario> PortoCenarioRepository { get; }
        IGenericRepository<Blend> BlendRepository { get; }
        IGenericRepository<EntidadeSimbolo> EntidadeSimboloRepository { get; }
        IGenericRepository<Entidade> EntidadeRepository { get; }
        IGenericRepository<Estado> EstadoRepository { get; }
        IGenericRepository<MercadoContrato> MercadoContratoRepository { get; }
        IGenericRepository<NoCenarioFaixaCustoFixo> NoCenarioFaixaCustoFixoRepository { get; }
        IGenericRepository<FaixaCustoFixo> FaixaCustoFixoRepository { get; }
        IGenericRepository<TipoDemanda> TipoDemandaRepository { get; }


        bool pr_ValoresClear(int id, int tipoEntidadeId, int topologiaId, string codigoRaiz);
        string Fn_find_NovoCodigoById(int tipoEntidadeId, int topologiaId);
        string Fn_get_CodigoByTipoEntidadeId(int tipoEntidadeid, int topologiaId, string prefixo);
        bool LocalizacaoExiste(string localizazao, int topologiaId);
        bool CreateEntrada(int cenarioId, int tipovalorId, int cadeiaId);
        bool ValoresUpdate(int id, int topologiaId, string codigo, int tipoEntidadeId);
        List<Produto> GetProdutoNo(Int32 noId);
        List<EntidadeSimbolo> EntidadeSimbolo();
        //bool pr_NoUpdate(int id, string codigo, string descricao, int tipoEntidadeId, int topologiaId, string localizacao, string nota, List<KeyValuePair<int, int>> produtosExcluidos);
        bool pr_VCM_NoUpdate(int id, string codigo, string descricao, int tipoEntidadeId, int topologiaId, string localizacao, string nota);
        bool pr_VCM_NoProdutosUpdate(int id, string codigo, string descricao, int tipoEntidadeId, int topologiaId, string localizacao, string nota, int[] posted);

        List<EntradaHelper> GetValuesFromProcedure(int scenarioId, string code, List<Simbolo> simbols, int entityType, bool detailed, bool exactValue);
        void pr_VCM_EntradaEdit(List<Entrada> entradas);

    }
}
