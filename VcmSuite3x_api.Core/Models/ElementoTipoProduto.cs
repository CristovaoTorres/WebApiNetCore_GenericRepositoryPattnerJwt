using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class ElementoTipoProduto
    {
        public int TipoEntidadeId { get; set; }
        public int TipoProdutoId { get; set; }

        public TipoEntidade TipoEntidade { get; set; }
        public TipoProduto TipoProduto { get; set; }
    }
}
