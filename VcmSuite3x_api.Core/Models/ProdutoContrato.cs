using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class ProdutoContrato
    {
        public int ProdutoId { get; set; }
        public int ContratoId { get; set; }

        public Contrato Contrato { get; set; }
        public Produto Produto { get; set; }
    }
}
