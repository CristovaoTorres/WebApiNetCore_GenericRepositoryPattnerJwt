using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class PeriodoAgregadoItem
    {
        public int PeriodoAgregadoId { get; set; }
        public int PeriodoId { get; set; }

        public Periodo Periodo { get; set; }
        public PeriodoAgregado PeriodoAgregado { get; set; }
    }
}
