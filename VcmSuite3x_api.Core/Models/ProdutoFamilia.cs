using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class ProdutoFamilia
    {
        public int ProdutoId { get; set; }
        public int FamiliaId { get; set; }

        public Familia Familia { get; set; }
        public Produto Produto { get; set; }
    }
}
