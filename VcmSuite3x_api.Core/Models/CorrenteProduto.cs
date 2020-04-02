using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class CorrenteProduto
    {
        public int CorrenteId { get; set; }
        public int ProdutoId { get; set; }

        public Corrente Corrente { get; set; }
        public Produto Produto { get; set; }
    }
}
