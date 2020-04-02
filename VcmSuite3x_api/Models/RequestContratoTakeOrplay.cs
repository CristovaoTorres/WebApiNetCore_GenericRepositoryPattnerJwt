using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VcmSuite3x_api.Models
{
    public class RequestContratoTakeOrplay
    {

        public int? Id { get; set; }

        [Required, StringLength(63)]
        public string Codigo { get; set; }
        [StringLength(63)]
        public string Descricao { get; set; }
        [Required]
        public int TipoEntidadeId { get; set; }
        [Required]
        public int TopologiaId { get; set; }

    }
}
