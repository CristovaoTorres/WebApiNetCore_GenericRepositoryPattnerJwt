using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class PropriedadeAgrupamento
    {
        public int PaiId { get; set; }
        public int DependenteId { get; set; }

        public Propriedade Dependente { get; set; }
        public Propriedade Pai { get; set; }
    }
}
