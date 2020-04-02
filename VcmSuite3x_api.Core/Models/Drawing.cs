using System;
using System.Collections.Generic;
using System.Text;

namespace VcmSuite3x_api.Core.Models
{
    public class Drawing
    {
        public string Code { get; set; }
        public int Portas { get; set; }
        public int DiagramaId { get; set; }
        public string Categoria { get; set; }
        public int Key { get; set; }

        public float CoordenadaX { get; set; }
        public float CoordenadaY { get; set; }
    }
}
