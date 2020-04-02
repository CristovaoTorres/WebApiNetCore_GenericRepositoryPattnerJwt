using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class CalculoHistorico
    {
        public int CalculoId { get; set; }
        public int SituacaoCalculoId { get; set; }
        public DateTime Data { get; set; }
        public string Nota { get; set; }

        public Calculo Calculo { get; set; }
        public SituacaoCalculo SituacaoCalculo { get; set; }
    }
}
