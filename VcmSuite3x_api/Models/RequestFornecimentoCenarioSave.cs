using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VcmSuite3x_api.Models
{
    public class FornecimentoCenarioSave
    {

      
        /// <summary>
        /// Id do Cenário
        /// </summary>
        [Required]
        public int CenarioId { get; set; }


        /// <summary>
        /// Id do Cenário
        /// </summary>
        public int? NoId { get; set; }


        /// <summary>
        /// Com Suprimento?
        /// </summary>
        [Required]
        public bool Suprimento { get; set; }


        /// <summary>
        /// Com Suprimento Agregado?
        /// </summary>
        [Required]
        public bool SuprimentoAgregado { get; set; }

        /// <summary>
        /// Com Suprimento Semicontinuo?
        /// </summary>
        [Required]
        public bool SuprimentoSemiContinuo { get; set; }


        /// <summary>
        /// Com Suprimento Agregado Semicontinuo?
        /// </summary>
        [Required]
        public bool SuprimentoAgregadoSemiContinuo { get; set; }

        /// <summary>
        /// Com Capacidade de Porão?
        /// </summary>
        public bool? CapacidadePoroes { get; set; }


        /// <summary>
        /// Incluir Impostos?
        /// </summary>
        [Required]
        public bool IncluirCalculoImpostos { get; set; }












    }
}
