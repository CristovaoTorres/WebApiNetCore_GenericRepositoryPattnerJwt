using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class TipoDemanda
    {
        public TipoDemanda()
        {
            MercadoCenario = new HashSet<MercadoCenario>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<MercadoCenario> MercadoCenario { get; set; }
    }
}
