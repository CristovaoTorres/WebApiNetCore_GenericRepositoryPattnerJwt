using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VcmSuite3x_api.Core.Models
{
    public partial class EntidadeSimbolo
    {
        [NotMapped]
        public int TopologiaId { get; set; }

        [NotMapped]
        public string Codigo { get; set; }
    }
}
