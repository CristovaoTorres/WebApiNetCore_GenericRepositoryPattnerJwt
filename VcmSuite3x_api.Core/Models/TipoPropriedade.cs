using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class TipoPropriedade
    {
        public TipoPropriedade()
        {
            Propriedade = new HashSet<Propriedade>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Propriedade> Propriedade { get; set; }
    }
}
