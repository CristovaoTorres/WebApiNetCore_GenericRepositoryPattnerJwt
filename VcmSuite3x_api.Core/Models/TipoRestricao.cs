using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class TipoRestricao
    {
        public TipoRestricao()
        {
            Restricao = new HashSet<Restricao>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Restricao> Restricao { get; set; }
    }
}
