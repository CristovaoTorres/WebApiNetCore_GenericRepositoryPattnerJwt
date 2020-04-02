using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class Entrada
    {
        public int Id { get; set; }
        public int CenarioId { get; set; }
        public int TipoValorId { get; set; }
        public int SimboloId { get; set; }
        public decimal Grandeza { get; set; }
        public string EntidadeCodigo1 { get; set; }
        public string EntidadeCodigo2 { get; set; }
        public string EntidadeCodigo3 { get; set; }
        public string EntidadeCodigo4 { get; set; }
        public string EntidadeCodigo5 { get; set; }
        public string EntidadeCodigo6 { get; set; }
        public string EntidadesCodigos { get; set; }

        public Cenario Cenario { get; set; }
        public Simbolo Simbolo { get; set; }
        public TipoValor TipoValor { get; set; }
    }
}
