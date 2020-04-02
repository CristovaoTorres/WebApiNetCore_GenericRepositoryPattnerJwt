using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VcmSuite3x_api.Models
{
    public class RequestProdutoSave
    {
        /// <summary>
        /// Id do Projeto (passar null se inclusão)
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Nome do Projeto
        /// </summary>
        [Required, StringLength(63)]
        public string Codigo { get; set; }

        /// <summary>
        /// Descrição do Produto
        /// </summary>
        [StringLength(150)]
        public string Descricao { get; set; }


        /// <summary>
        /// Id da Topologia
        /// </summary>
        [Required]
        public int TopologiaId { get; set; }

        /// <summary>
        /// jeto (?)
        /// </summary>
        [Required]
        public int TipoEntidadeId { get; set; }

        /// <summary>
        /// Unidade de Medida relacionado ao Produto
        /// </summary>
        [Required]
        public int UnidadeMedidaId { get; set; }



    }
}
