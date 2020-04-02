using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class ProdutoCenarioSimbolo
    {
        public int ProdutoId { get; set; }
        public int CenarioId { get; set; }
        public int SimboloId { get; set; }
        public bool Detalhado { get; set; }
        public bool EmUso { get; set; }

        public Cenario Cenario { get; set; }
        public Produto Produto { get; set; }
        public Simbolo Simbolo { get; set; }
    }
}
