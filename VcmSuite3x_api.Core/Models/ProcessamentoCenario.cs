using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class ProcessamentoCenario
    {
        public int NoId { get; set; }
        public int CenarioId { get; set; }
        public bool ConsumoEnergiaEletrica { get; set; }
        public bool ConsumoVapor { get; set; }
        public bool IncluirCalculoImpostos { get; set; }

        public Cenario Cenario { get; set; }
        public No No { get; set; }
    }
}
