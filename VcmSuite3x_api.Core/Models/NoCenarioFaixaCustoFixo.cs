using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class NoCenarioFaixaCustoFixo
    {
        public int NoId { get; set; }
        public int CenarioId { get; set; }
        public int FaixaId { get; set; }

        public Cenario Cenario { get; set; }
        public FaixaCustoFixo Faixa { get; set; }
        public No No { get; set; }
    }
}
