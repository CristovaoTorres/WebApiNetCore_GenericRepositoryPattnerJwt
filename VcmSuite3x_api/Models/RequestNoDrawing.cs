using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VcmSuite3x_api.Models
{
    public class RequestNoDrawing
    {

        public string Categoria { get; set; }
        public int Portas { get; set; }

        [Required]
        public int FluxogramaId { get; set; }

        public float CoordenadaX { get; set; }
        public float CoordenadaY { get; set; }

        public string Code { get; set; }

        public int Key { get; set; }
    }
}
