using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class TipoLimite
    {
        public TipoLimite()
        {
            Limite = new HashSet<Limite>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Limite> Limite { get; set; }
    }
}
