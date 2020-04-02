using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class MercadoCenario
    {
        public int NoId { get; set; }
        public int CenarioId { get; set; }
        public int TipoDemandaId { get; set; }
        public int? PrecoBaseId { get; set; }
        public bool DemandaAgregada { get; set; }
        public bool DemandaSemiContinuaProduto { get; set; }
        public bool DemandaSemiContinuaFamilia { get; set; }
        public bool DemandaSemiContinuaAgregado { get; set; }
        public bool IncluirCalculoImpostos { get; set; }

        public Cenario Cenario { get; set; }
        public No No { get; set; }
        public PrecoBase PrecoBase { get; set; }
        public TipoDemanda TipoDemanda { get; set; }
    }
}
