using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class RestricaoNo
    {
        public int RestricaoId { get; set; }
        public int NoId { get; set; }

        public No No { get; set; }
        public Restricao Restricao { get; set; }
    }
}
