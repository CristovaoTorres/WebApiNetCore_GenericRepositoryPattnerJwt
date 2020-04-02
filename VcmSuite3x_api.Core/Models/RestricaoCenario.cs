using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class RestricaoCenario
    {
        public int RestricaoId { get; set; }
        public int CenarioId { get; set; }
        public int PeriodoId { get; set; }

        public Cenario Cenario { get; set; }
        public Periodo Periodo { get; set; }
        public Restricao Restricao { get; set; }
    }
}
