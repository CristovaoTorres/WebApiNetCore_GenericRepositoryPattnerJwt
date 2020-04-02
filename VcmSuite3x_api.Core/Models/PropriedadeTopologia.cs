using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class PropriedadeTopologia
    {
        public int Id { get; set; }
        public int PropriedadeId { get; set; }
        public int TopologiaId { get; set; }

        public Propriedade Propriedade { get; set; }
        public Topologia Topologia { get; set; }
    }
}
