using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VcmSuite3x_api.Core.Models;

namespace VcmSuite3x_api.Models
{
    public class ResponseDrawing
    {
        public string Code { get; set; }
        //public int Width { get; set; }
        //public int Height { get; set; }
        public int Portas { get; set; }
        public int DiagramaId { get; set; }
        public string Categoria { get; set; }
        public int Key { get; set; }

        public float CoordenadaX { get; set; }
        public float CoordenadaY { get; set; }


        public ResponseDrawing(Drawing drawing)
        {

            this.Code = drawing.Code;
            this.Portas = drawing.Portas;
            this.Key = drawing.Key;
            this.DiagramaId = drawing.DiagramaId;
            this.Categoria = drawing.Categoria;
            this.CoordenadaX = drawing.CoordenadaX;
            this.CoordenadaY = drawing.CoordenadaY;
        }
    }
}
