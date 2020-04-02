using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class AgendaOtimizacao
    {
        public int CenarioId { get; set; }
        public int AgendaId { get; set; }
        public int Sequencia { get; set; }

        public Agenda Agenda { get; set; }
        public Cenario Cenario { get; set; }
    }
}
