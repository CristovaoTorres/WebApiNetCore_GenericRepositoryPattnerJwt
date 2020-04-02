using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VcmSuite3x_api.Core.Models
{
    public partial class CorrenteDrawing
    {
        [NotMapped]
        public string Code { get; set; }

        [NotMapped]
        public int PortaEntradaIndex { get; set; }

        [NotMapped]
        public int PortaSaidaIndex { get; set; }
    }
}
