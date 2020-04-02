using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class DiagramaCenario
    {
        public int NoId { get; set; }
        public int CenarioId { get; set; }
        public int? ValvulaRemoidoId { get; set; }
        public int? ValvulaFareloId { get; set; }
        public int? ConjuntoId { get; set; }
        public int? TransportadorFareloId { get; set; }
        public int? TransportadorRemoidoId { get; set; }

        public Cenario Cenario { get; set; }
        public Conjunto Conjunto { get; set; }
        public No No { get; set; }
        public Corrente TransportadorFarelo { get; set; }
        public Corrente TransportadorRemoido { get; set; }
        public Valvula ValvulaFarelo { get; set; }
        public Valvula ValvulaRemoido { get; set; }
    }
}
