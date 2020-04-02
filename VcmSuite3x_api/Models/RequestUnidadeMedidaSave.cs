using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VcmSuite3x_api.Models
{
    public class RequestUnidadeMedidaSave
    {
        public int? Id { get; set; }

        [Required, StringLength(20)]
        public string Nome { get; set; }

        [Required, StringLength(30)]
        public string Representacao { get; set; }

        [Required]
        public decimal FatorConversao { get; set; }

        [Required]
        public int TipoUnidadeId { get; set; }

    }
}
