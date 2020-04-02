using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VcmSuite3x.Application.ViewModel
{
    public class TopologiaViewModel
    {
        /// <summary>
        /// Id do Projeto (passar null se inclusão)
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Nome da Topologia
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }


        /// <summary>
        /// Id do Projeto
        /// </summary>
        public int ProjetoId { get; set; }

        public int CenarioId { get; set; }
        public int FluxogramaId { get; set; }
    }
}
