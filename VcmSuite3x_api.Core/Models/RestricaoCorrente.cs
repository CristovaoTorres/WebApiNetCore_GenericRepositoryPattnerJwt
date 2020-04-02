using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class RestricaoCorrente
    {
        public int RestricaoId { get; set; }
        public int CorrenteId { get; set; }

        public Corrente Corrente { get; set; }
        public Restricao Restricao { get; set; }
    }
}
