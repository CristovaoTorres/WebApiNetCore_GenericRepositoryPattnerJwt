using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class ConjuntoFarinhaProduto
    {
        public int ProdutoId { get; set; }
        public int ConjuntoFarinhaId { get; set; }

        public ConjuntoFarinha ConjuntoFarinha { get; set; }
        public Produto Produto { get; set; }
    }
}
