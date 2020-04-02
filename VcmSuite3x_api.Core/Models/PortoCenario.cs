using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class PortoCenario
    {
        public int NoId { get; set; }
        public int CenarioId { get; set; }
        public int TipoArmazenamentoId { get; set; }
        public bool CustoVariavelPorFaixa { get; set; }
        public int SlotCritico { get; set; }
        public bool IncluirCalculoImpostos { get; set; }

        public Cenario Cenario { get; set; }
        public No No { get; set; }
        public TipoArmazenamento TipoArmazenamento { get; set; }
    }
}
