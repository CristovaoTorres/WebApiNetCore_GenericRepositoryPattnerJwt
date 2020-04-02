using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class LabelPadraoTopologia
    {
        public int Id { get; set; }
        public int TopologiaId { get; set; }
        public int LabelGuiid { get; set; }
        public bool Visivel { get; set; }
        public int TipoEntidadeId { get; set; }

        public TipoEntidade TipoEntidade { get; set; }
        public Topologia Topologia { get; set; }
    }
}
