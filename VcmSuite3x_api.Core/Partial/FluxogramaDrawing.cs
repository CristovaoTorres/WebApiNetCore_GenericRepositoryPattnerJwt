using System;
using System.Collections.Generic;
using System.Text;

namespace VcmSuite3x_api.Core.Models
{
    public partial class FluxogramaDrawing
    {
        public FluxogramaDrawing(int topologiaId, float coordenadaX, float coordenadaY, float escala)
        {
            this.TopologiaId = topologiaId;
            this.Nome = "FLUXOGRAMA1";
            this.CoordenadaX = coordenadaX;
            this.CoordenadaY = coordenadaY;
            this.Escala = escala;


        }

    }
}
