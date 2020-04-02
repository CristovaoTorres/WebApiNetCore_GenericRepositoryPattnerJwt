using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class PeriodoCenario
    {
        public int CenarioId { get; set; }
        public int PeriodoId { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }

        public Cenario Cenario { get; set; }
        public Periodo Periodo { get; set; }
    }
}
