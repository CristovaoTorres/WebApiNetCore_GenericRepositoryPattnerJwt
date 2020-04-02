using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class CoresAddIn
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public short Cor { get; set; }
        public bool Negrito { get; set; }
    }
}
