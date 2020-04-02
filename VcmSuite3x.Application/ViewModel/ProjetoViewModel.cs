using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VcmSuite3x.Application.ViewModel
{
    public class ProjetoViewModel
    {
        public ProjetoViewModel()
        {
            this.UnidadeMedidas = new List<UnidadeMedidaHelper>();

        }

        public List<UnidadeMedidaHelper> UnidadeMedidas
        {
            get; set;
        }

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
    public class UnidadeMedidaHelper
    {
        public string Nome { get; set; }
        public List<SelectListItem> Items { get; set; }
    }

}
