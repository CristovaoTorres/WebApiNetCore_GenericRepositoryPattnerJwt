using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class Limite
    {
        public int Id { get; set; }
        public int TipoLimiteId { get; set; }
        public bool SemiContinuo { get; set; }
        public bool Total { get; set; }
        public int DadoCenarioId { get; set; }
        public int TipoEntidadeId { get; set; }
        public int CenarioId { get; set; }

        public Cenario Cenario { get; set; }
        public TipoEntidade TipoEntidade { get; set; }
        public TipoLimite TipoLimite { get; set; }
    }
}
