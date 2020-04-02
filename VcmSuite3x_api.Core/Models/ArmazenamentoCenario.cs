using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class ArmazenamentoCenario
    {
        public int NoId { get; set; }
        public int CenarioId { get; set; }
        public int TipoArmazenamentoId { get; set; }
        public bool IncluirCalculoImpostos { get; set; }
        public decimal Capex { get; set; }
        public bool ComFaixa { get; set; }

        public Cenario Cenario { get; set; }
        public No No { get; set; }
        public TipoArmazenamento TipoArmazenamento { get; set; }
    }
}
