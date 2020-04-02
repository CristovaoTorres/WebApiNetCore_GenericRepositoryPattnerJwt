using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class NoFamilia
    {
        public int NoId { get; set; }
        public int FamiliaId { get; set; }

        public Familia Familia { get; set; }
        public No No { get; set; }
    }
}
