using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class ConjuntoEntidade
    {
        public int TipoConjuntoId { get; set; }
        public int TipoEntidadeId { get; set; }

        public TipoEntidade TipoConjunto { get; set; }
        public TipoEntidade TipoEntidade { get; set; }
    }
}
