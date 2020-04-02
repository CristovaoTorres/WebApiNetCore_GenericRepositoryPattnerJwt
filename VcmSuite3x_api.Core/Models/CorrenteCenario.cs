using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class CorrenteCenario
    {
        public int CorrenteId { get; set; }
        public int CenarioId { get; set; }
        public int LeadTime { get; set; }
        public int? ContratoTakeOrPayId { get; set; }
        public int TipoLimiteCorrenteId { get; set; }

        public Cenario Cenario { get; set; }
        public Corrente Corrente { get; set; }
        public TipoLimiteCorrente TipoLimiteCorrente { get; set; }
    }
}
