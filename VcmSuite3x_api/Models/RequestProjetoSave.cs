using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VcmSuite3x_api.Models
{
    public class RequestProjetoSave
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

        /// <summary>
        /// Descrição do Projeto
        /// </summary>
        [Required]
        [StringLength(255)]
        public string Nota { get; set; }

        /// <summary>
        /// Cadeia do Projeto (?)
        /// </summary>
        public int CadeiaId { get; set; }

        /// <summary>
        /// Lista de Unidades de Medidas Padrão do Projeto
        /// </summary>
        public List<int> UnidadeMedidaId { get; set; }



    }
}
