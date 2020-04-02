using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class ConjuntoProduto
    {
        public int ConjuntoId { get; set; }
        public int ProdutoId { get; set; }

        public Conjunto Conjunto { get; set; }
        public Produto Produto { get; set; }
    }
}
