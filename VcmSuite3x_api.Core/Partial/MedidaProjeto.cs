using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VcmSuite3x_api.Core.Models
{
    public partial class MedidaProjeto
    {
        [NotMapped()]
        public int TopologiaID { get; set; }

        [NotMapped()]
        public int TipoUnidadeId { get; set; }
    }
}
