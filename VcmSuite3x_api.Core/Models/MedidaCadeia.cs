using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class MedidaCadeia
    {
        public int UnidadeMedidaId { get; set; }
        public int CadeiaId { get; set; }

        public Cadeia Cadeia { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }
    }
}
