using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class MercadoContrato
    {
        public int MercadoId { get; set; }
        public int ContratoId { get; set; }

        public Contrato Contrato { get; set; }
        public No Mercado { get; set; }
    }
}
