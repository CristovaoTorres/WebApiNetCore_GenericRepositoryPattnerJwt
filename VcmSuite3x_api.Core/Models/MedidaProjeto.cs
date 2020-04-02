using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class MedidaProjeto
    {
        public int UnidadeMedidaId { get; set; }
        public int ProjetoId { get; set; }

        public Projeto Projeto { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }
    }
}
