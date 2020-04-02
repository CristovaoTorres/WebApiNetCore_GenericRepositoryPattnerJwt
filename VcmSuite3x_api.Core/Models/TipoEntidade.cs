using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class TipoEntidade
    {
        public TipoEntidade()
        {
            Blend = new HashSet<Blend>();
            Conjunto = new HashSet<Conjunto>();
            ConjuntoEntidadeTipoConjunto = new HashSet<ConjuntoEntidade>();
            ConjuntoEntidadeTipoEntidade = new HashSet<ConjuntoEntidade>();
            ConjuntoFarinha = new HashSet<ConjuntoFarinha>();
            Contrato = new HashSet<Contrato>();
            Corrente = new HashSet<Corrente>();
            Desconto = new HashSet<Desconto>();
            ElementoTipoProduto = new HashSet<ElementoTipoProduto>();
            EntidadeSimbolo = new HashSet<EntidadeSimbolo>();
            Estado = new HashSet<Estado>();
            FaixaCustoFixo = new HashSet<FaixaCustoFixo>();
            FaixaDesconto = new HashSet<FaixaDesconto>();
            Familia = new HashSet<Familia>();
            LabelPadraoTopologia = new HashSet<LabelPadraoTopologia>();
            Limite = new HashSet<Limite>();
            No = new HashSet<No>();
            Pais = new HashSet<Pais>();
            Periodo = new HashSet<Periodo>();
            PeriodoAgregado = new HashSet<PeriodoAgregado>();
            PrecoBase = new HashSet<PrecoBase>();
            Produto = new HashSet<Produto>();
            Regiao = new HashSet<Regiao>();
            Restricao = new HashSet<Restricao>();
            Silo = new HashSet<Silo>();
            Valvula = new HashSet<Valvula>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Prefixo { get; set; }

        public TipoProduto TipoProduto { get; set; }
        public ICollection<Blend> Blend { get; set; }
        public ICollection<Conjunto> Conjunto { get; set; }
        public ICollection<ConjuntoEntidade> ConjuntoEntidadeTipoConjunto { get; set; }
        public ICollection<ConjuntoEntidade> ConjuntoEntidadeTipoEntidade { get; set; }
        public ICollection<ConjuntoFarinha> ConjuntoFarinha { get; set; }
        public ICollection<Contrato> Contrato { get; set; }
        public ICollection<Corrente> Corrente { get; set; }
        public ICollection<Desconto> Desconto { get; set; }
        public ICollection<ElementoTipoProduto> ElementoTipoProduto { get; set; }
        public ICollection<EntidadeSimbolo> EntidadeSimbolo { get; set; }
        public ICollection<Estado> Estado { get; set; }
        public ICollection<FaixaCustoFixo> FaixaCustoFixo { get; set; }
        public ICollection<FaixaDesconto> FaixaDesconto { get; set; }
        public ICollection<Familia> Familia { get; set; }
        public ICollection<LabelPadraoTopologia> LabelPadraoTopologia { get; set; }
        public ICollection<Limite> Limite { get; set; }
        public ICollection<No> No { get; set; }
        public ICollection<Pais> Pais { get; set; }
        public ICollection<Periodo> Periodo { get; set; }
        public ICollection<PeriodoAgregado> PeriodoAgregado { get; set; }
        public ICollection<PrecoBase> PrecoBase { get; set; }
        public ICollection<Produto> Produto { get; set; }
        public ICollection<Regiao> Regiao { get; set; }
        public ICollection<Restricao> Restricao { get; set; }
        public ICollection<Silo> Silo { get; set; }
        public ICollection<Valvula> Valvula { get; set; }
    }
}
