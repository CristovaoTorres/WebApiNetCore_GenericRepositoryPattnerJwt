using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class NoDrawing
    {
        public NoDrawing()
        {
            PortaDrawing = new HashSet<PortaDrawing>();
        }

        public int NoId { get; set; }
        public int FluxogramaId { get; set; }
        public float CoordenadaX { get; set; }
        public float CoordenadaY { get; set; }
        public bool Conector { get; set; }

        public FluxogramaDrawing Fluxograma { get; set; }
        public No No { get; set; }
        public ICollection<PortaDrawing> PortaDrawing { get; set; }
    }
}
