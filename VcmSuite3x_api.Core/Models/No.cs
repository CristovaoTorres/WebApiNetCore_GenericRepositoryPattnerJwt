using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class No
    {
        public No()
        {
            ArmazenamentoCenario = new HashSet<ArmazenamentoCenario>();
            CorrenteEntrada = new HashSet<Corrente>();
            CorrenteSaida = new HashSet<Corrente>();
            DiagramaCenario = new HashSet<DiagramaCenario>();
            DivisorCenario = new HashSet<DivisorCenario>();
            FornecimentoCenario = new HashSet<FornecimentoCenario>();
            MercadoCenario = new HashSet<MercadoCenario>();
            MercadoContrato = new HashSet<MercadoContrato>();
            NoCenarioFaixaCustoFixo = new HashSet<NoCenarioFaixaCustoFixo>();
            NoCenarioLimite = new HashSet<NoCenarioLimite>();
            NoCenarioSimbolo = new HashSet<NoCenarioSimbolo>();
            NoDrawing = new HashSet<NoDrawing>();
            NoFamilia = new HashSet<NoFamilia>();
            NoProduto = new HashSet<NoProduto>();
            PortoCenario = new HashSet<PortoCenario>();
            ProcessamentoCenario = new HashSet<ProcessamentoCenario>();
            RestricaoNo = new HashSet<RestricaoNo>();
            UnificadorCenario = new HashSet<UnificadorCenario>();
        }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public int TipoEntidadeId { get; set; }
        public int TopologiaId { get; set; }
        public string Localizacao { get; set; }
        public int? ConjuntoId { get; set; }
        public string Nota { get; set; }
        public byte? Entradas { get; set; }
        public byte? Saidas { get; set; }

        public Conjunto Conjunto { get; set; }
        public TipoEntidade TipoEntidade { get; set; }
        public Topologia Topologia { get; set; }
        public ICollection<ArmazenamentoCenario> ArmazenamentoCenario { get; set; }
        public ICollection<Corrente> CorrenteEntrada { get; set; }
        public ICollection<Corrente> CorrenteSaida { get; set; }
        public ICollection<DiagramaCenario> DiagramaCenario { get; set; }
        public ICollection<DivisorCenario> DivisorCenario { get; set; }
        public ICollection<FornecimentoCenario> FornecimentoCenario { get; set; }
        public ICollection<MercadoCenario> MercadoCenario { get; set; }
        public ICollection<MercadoContrato> MercadoContrato { get; set; }
        public ICollection<NoCenarioFaixaCustoFixo> NoCenarioFaixaCustoFixo { get; set; }
        public ICollection<NoCenarioLimite> NoCenarioLimite { get; set; }
        public ICollection<NoCenarioSimbolo> NoCenarioSimbolo { get; set; }
        public ICollection<NoDrawing> NoDrawing { get; set; }
        public ICollection<NoFamilia> NoFamilia { get; set; }
        public ICollection<NoProduto> NoProduto { get; set; }
        public ICollection<PortoCenario> PortoCenario { get; set; }
        public ICollection<ProcessamentoCenario> ProcessamentoCenario { get; set; }
        public ICollection<RestricaoNo> RestricaoNo { get; set; }
        public ICollection<UnificadorCenario> UnificadorCenario { get; set; }
    }
}
