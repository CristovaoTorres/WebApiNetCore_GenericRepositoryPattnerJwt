using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class TipoArmazenamento
    {
        public TipoArmazenamento()
        {
            ArmazenamentoCenario = new HashSet<ArmazenamentoCenario>();
            PortoCenario = new HashSet<PortoCenario>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<ArmazenamentoCenario> ArmazenamentoCenario { get; set; }
        public ICollection<PortoCenario> PortoCenario { get; set; }
    }
}
