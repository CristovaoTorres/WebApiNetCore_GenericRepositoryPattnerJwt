using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class Topologia
    {
        public Topologia()
        {
            Blend = new HashSet<Blend>();
            Cenario = new HashSet<Cenario>();
            Conjunto = new HashSet<Conjunto>();
            ConjuntoFarinha = new HashSet<ConjuntoFarinha>();
            Contrato = new HashSet<Contrato>();
            Corrente = new HashSet<Corrente>();
            Desconto = new HashSet<Desconto>();
            Estado = new HashSet<Estado>();
            FaixaCustoFixo = new HashSet<FaixaCustoFixo>();
            FaixaDesconto = new HashSet<FaixaDesconto>();
            Familia = new HashSet<Familia>();
            FluxogramaDrawing = new HashSet<FluxogramaDrawing>();
            LabelPadraoTopologia = new HashSet<LabelPadraoTopologia>();
            No = new HashSet<No>();
            Pais = new HashSet<Pais>();
            Periodo = new HashSet<Periodo>();
            PeriodoAgregado = new HashSet<PeriodoAgregado>();
            PrecoBase = new HashSet<PrecoBase>();
            Produto = new HashSet<Produto>();
            PropriedadeTopologia = new HashSet<PropriedadeTopologia>();
            Regiao = new HashSet<Regiao>();
            Restricao = new HashSet<Restricao>();
            Silo = new HashSet<Silo>();
            Valvula = new HashSet<Valvula>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int ProjetoId { get; set; }

        public Projeto Projeto { get; set; }
        public ICollection<Blend> Blend { get; set; }
        public ICollection<Cenario> Cenario { get; set; }
        public ICollection<Conjunto> Conjunto { get; set; }
        public ICollection<ConjuntoFarinha> ConjuntoFarinha { get; set; }
        public ICollection<Contrato> Contrato { get; set; }
        public ICollection<Corrente> Corrente { get; set; }
        public ICollection<Desconto> Desconto { get; set; }
        public ICollection<Estado> Estado { get; set; }
        public ICollection<FaixaCustoFixo> FaixaCustoFixo { get; set; }
        public ICollection<FaixaDesconto> FaixaDesconto { get; set; }
        public ICollection<Familia> Familia { get; set; }
        public ICollection<FluxogramaDrawing> FluxogramaDrawing { get; set; }
        public ICollection<LabelPadraoTopologia> LabelPadraoTopologia { get; set; }
        public ICollection<No> No { get; set; }
        public ICollection<Pais> Pais { get; set; }
        public ICollection<Periodo> Periodo { get; set; }
        public ICollection<PeriodoAgregado> PeriodoAgregado { get; set; }
        public ICollection<PrecoBase> PrecoBase { get; set; }
        public ICollection<Produto> Produto { get; set; }
        public ICollection<PropriedadeTopologia> PropriedadeTopologia { get; set; }
        public ICollection<Regiao> Regiao { get; set; }
        public ICollection<Restricao> Restricao { get; set; }
        public ICollection<Silo> Silo { get; set; }
        public ICollection<Valvula> Valvula { get; set; }
    }
}
