using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VcmSuite3x_api.Core.Models
{
   public partial class Contrato
    {

        [NotMapped]
        public string TipoEntidadeNome { get; set; }

        [NotMapped]
        public string TipoProdutoNome { get; set; }

    }
}
