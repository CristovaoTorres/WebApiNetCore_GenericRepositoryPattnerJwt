using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class Cenario
    {
        public Cenario()
        {
            AgendaOtimizacao = new HashSet<AgendaOtimizacao>();
            ArmazenamentoCenario = new HashSet<ArmazenamentoCenario>();
            Calculo = new HashSet<Calculo>();
            CorrenteCenario = new HashSet<CorrenteCenario>();
            CorrenteCenarioLimite = new HashSet<CorrenteCenarioLimite>();
            CorrenteCenarioSimbolo = new HashSet<CorrenteCenarioSimbolo>();
            DiagramaCenario = new HashSet<DiagramaCenario>();
            DivisorCenario = new HashSet<DivisorCenario>();
            Entrada = new HashSet<Entrada>();
            FornecimentoCenario = new HashSet<FornecimentoCenario>();
            Limite = new HashSet<Limite>();
            MercadoCenario = new HashSet<MercadoCenario>();
            NoCenarioFaixaCustoFixo = new HashSet<NoCenarioFaixaCustoFixo>();
            NoCenarioLimite = new HashSet<NoCenarioLimite>();
            NoCenarioSimbolo = new HashSet<NoCenarioSimbolo>();
            PeriodoCenario = new HashSet<PeriodoCenario>();
            PortoCenario = new HashSet<PortoCenario>();
            ProcessamentoCenario = new HashSet<ProcessamentoCenario>();
            ProdutoCenarioSimbolo = new HashSet<ProdutoCenarioSimbolo>();
            RestricaoCenario = new HashSet<RestricaoCenario>();
            UnificadorCenario = new HashSet<UnificadorCenario>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int TopologiaId { get; set; }

        public Topologia Topologia { get; set; }
        public ICollection<AgendaOtimizacao> AgendaOtimizacao { get; set; }
        public ICollection<ArmazenamentoCenario> ArmazenamentoCenario { get; set; }
        public ICollection<Calculo> Calculo { get; set; }
        public ICollection<CorrenteCenario> CorrenteCenario { get; set; }
        public ICollection<CorrenteCenarioLimite> CorrenteCenarioLimite { get; set; }
        public ICollection<CorrenteCenarioSimbolo> CorrenteCenarioSimbolo { get; set; }
        public ICollection<DiagramaCenario> DiagramaCenario { get; set; }
        public ICollection<DivisorCenario> DivisorCenario { get; set; }
        public ICollection<Entrada> Entrada { get; set; }
        public ICollection<FornecimentoCenario> FornecimentoCenario { get; set; }
        public ICollection<Limite> Limite { get; set; }
        public ICollection<MercadoCenario> MercadoCenario { get; set; }
        public ICollection<NoCenarioFaixaCustoFixo> NoCenarioFaixaCustoFixo { get; set; }
        public ICollection<NoCenarioLimite> NoCenarioLimite { get; set; }
        public ICollection<NoCenarioSimbolo> NoCenarioSimbolo { get; set; }
        public ICollection<PeriodoCenario> PeriodoCenario { get; set; }
        public ICollection<PortoCenario> PortoCenario { get; set; }
        public ICollection<ProcessamentoCenario> ProcessamentoCenario { get; set; }
        public ICollection<ProdutoCenarioSimbolo> ProdutoCenarioSimbolo { get; set; }
        public ICollection<RestricaoCenario> RestricaoCenario { get; set; }
        public ICollection<UnificadorCenario> UnificadorCenario { get; set; }
    }
}
