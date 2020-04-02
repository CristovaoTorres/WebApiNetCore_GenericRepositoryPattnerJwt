using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class NoProduto
    {
        public int? NoId { get; set; }
        public int ProdutoId { get; set; }

        public No No { get; set; }
        public Produto Produto { get; set; }
    }
}
