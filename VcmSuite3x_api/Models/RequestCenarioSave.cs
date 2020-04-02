using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VcmSuite3x_api.Models
{
    public class RequestCenarioSave
    {
        /// <summary>
        /// Id do Projeto (passar null se inclusão)
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Nome do Projeto
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        public int TopologiaId { get; set; }

    }
}
