using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class FluxogramaDrawing
    {
        public FluxogramaDrawing()
        {
            CorrenteDrawing = new HashSet<CorrenteDrawing>();
            NoDrawing = new HashSet<NoDrawing>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int TopologiaId { get; set; }
        public float CoordenadaX { get; set; }
        public float CoordenadaY { get; set; }
        public float Escala { get; set; }

        public Topologia Topologia { get; set; }
        public ICollection<CorrenteDrawing> CorrenteDrawing { get; set; }
        public ICollection<NoDrawing> NoDrawing { get; set; }
    }
}
