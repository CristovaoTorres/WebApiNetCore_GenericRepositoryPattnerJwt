using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class PropriedadeProduto
    {
        public int PropriedadeId { get; set; }
        public int ProdutoId { get; set; }

        public Produto Produto { get; set; }
        public Propriedade Propriedade { get; set; }
    }
}
