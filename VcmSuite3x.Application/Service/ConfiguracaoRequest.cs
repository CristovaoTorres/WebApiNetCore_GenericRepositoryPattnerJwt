using System;
using System.Collections.Generic;
using System.Text;

namespace VcmSuite3x.Application.Service
{
   public class ConfiguracaoRequest
    {
        public int CenarioId { get; set; }
        public int SimboloId { get; set; }

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
