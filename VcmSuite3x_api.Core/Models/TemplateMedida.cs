using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class TemplateMedida
    {
        public int CadeiaId { get; set; }
        public int TipoUnidadeId { get; set; }

        public Cadeia Cadeia { get; set; }
        public TipoUnidade TipoUnidade { get; set; }
    }
}
