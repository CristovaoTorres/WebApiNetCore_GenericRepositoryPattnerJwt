using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class TipoDivisor
    {
        public TipoDivisor()
        {
            DivisorCenario = new HashSet<DivisorCenario>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<DivisorCenario> DivisorCenario { get; set; }
    }
}
