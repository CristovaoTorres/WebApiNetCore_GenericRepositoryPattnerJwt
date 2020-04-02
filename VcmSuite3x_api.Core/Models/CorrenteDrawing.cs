using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class CorrenteDrawing
    {
        public int CorrenteId { get; set; }
        public int FluxogramaId { get; set; }
        public int PortaEntradaId { get; set; }
        public int PortaSaidaId { get; set; }

        public Corrente Corrente { get; set; }
        public FluxogramaDrawing Fluxograma { get; set; }
        public PortaDrawing PortaEntrada { get; set; }
        public PortaDrawing PortaSaida { get; set; }
    }
}
