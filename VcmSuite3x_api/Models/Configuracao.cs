using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VcmSuite3x_api.Models
{
    public class Configuracao
    {
        /// <summary>
        /// Código de corrente para configuração.
        /// </summary>
        public String Corrente { get; set; }

        /// <summary>
        /// Código de nó para configuração.
        /// </summary>
        public String Elemento { get; set; }

        /// <summary>
        /// Código de produto para configuração.
        /// </summary>
        public String Produto { get; set; }

        /// <summary>
        /// Identificador do Tipo de Entidade.
        /// </summary>
        public Int32 TipoEntidadeId { get; set; }
    }
}
