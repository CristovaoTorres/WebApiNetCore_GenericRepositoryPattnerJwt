using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class FornecimentoCenario
    {
        public int NoId { get; set; }
        public int CenarioId { get; set; }
        public bool Suprimento { get; set; }
        public bool SuprimentoAgregado { get; set; }
        public bool SuprimentoSemiContinuo { get; set; }
        public bool SuprimentoAgregadoSemiContinuo { get; set; }
        public bool? CapacidadePoroes { get; set; }
        public bool IncluirCalculoImpostos { get; set; }

        public Cenario Cenario { get; set; }
        public No No { get; set; }
    }
}
