using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VcmSuite3x_api.Core.Models
{
    public partial class No
    {


        //public string Descricao { get; set; }
        //public string Codigo { get; set; }
        //public int Id { get; set; }
        //public int TipoEntidadeId { get; set; }
        //public int TopologiaId { get; set; }

        [NotMapped]
        public bool IsConector { get; set; }

        [NotMapped]
        public bool IsFornecimento { get; set; }
        //public string Nota { get; set; }

    }
}
