using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class NoCenarioLimite
    {
        public int NoId { get; set; }
        public int CenarioId { get; set; }
        public bool LimiteMinimoEntrada { get; set; }
        public bool? LimiteMinimoEntradaTotal { get; set; }
        public bool LimiteMinimoEntradaSemiContinuo { get; set; }
        public bool LimiteMaximoEntrada { get; set; }
        public bool? LimiteMaximoEntradaTotal { get; set; }
        public bool LimiteMinimoSaida { get; set; }
        public bool? LimiteMinimoSaidaTotal { get; set; }
        public bool LimiteMinimoSaidaSemiContinuo { get; set; }
        public bool LimiteMaximoSaida { get; set; }
        public bool? LimiteMaximoSaidaTotal { get; set; }

        public Cenario Cenario { get; set; }
        public No No { get; set; }
    }
}
