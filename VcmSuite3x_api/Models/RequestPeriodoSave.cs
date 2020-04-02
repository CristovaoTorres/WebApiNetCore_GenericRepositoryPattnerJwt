using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VcmSuite3x_api.Models
{
    public class RequestPeriodoSave
    {

        public int? Id { get; set; }

        [StringLength(150), Required]
        public string Descricao { get; set; }

        [Required]
        public int TopologiaId { get; set; }

        public int Quantidade { get; set; }

        [StringLength(63), Required]
        public string Codigo { get; set; }
    }
}
