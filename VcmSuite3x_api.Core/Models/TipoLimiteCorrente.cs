using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class TipoLimiteCorrente
    {
        public TipoLimiteCorrente()
        {
            CorrenteCenario = new HashSet<CorrenteCenario>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<CorrenteCenario> CorrenteCenario { get; set; }
    }
}
