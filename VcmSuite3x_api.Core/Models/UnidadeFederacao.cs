using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class UnidadeFederacao
    {
        public UnidadeFederacao()
        {
            Estado = new HashSet<Estado>();
        }

        public string Sigla { get; set; }
        public string Nome { get; set; }

        public ICollection<Estado> Estado { get; set; }
    }
}
