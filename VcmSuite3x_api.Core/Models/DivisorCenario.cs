using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class DivisorCenario
    {
        public int NoId { get; set; }
        public int CenarioId { get; set; }
        public int TipoDivisorId { get; set; }

        public Cenario Cenario { get; set; }
        public No No { get; set; }
        public TipoDivisor TipoDivisor { get; set; }
    }
}
