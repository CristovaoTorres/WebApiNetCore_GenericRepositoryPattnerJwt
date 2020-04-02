using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class FamiliaContrato
    {
        public int FamiliaId { get; set; }
        public int ContratoId { get; set; }

        public Contrato Contrato { get; set; }
        public Familia Familia { get; set; }
    }
}
