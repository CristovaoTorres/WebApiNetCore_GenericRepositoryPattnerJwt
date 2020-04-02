using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class CorrenteCenarioSimbolo
    {
        public int CorrenteId { get; set; }
        public int CenarioId { get; set; }
        public int SimboloId { get; set; }
        public bool? Detalhado { get; set; }
        public bool? ValorExato { get; set; }
        public int TipoEntrada { get; set; }
        public int? TipoDetalhe { get; set; }

        public Cenario Cenario { get; set; }
        public Corrente Corrente { get; set; }
        public Simbolo Simbolo { get; set; }
    }
}
