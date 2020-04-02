using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class Resultado
    {
        public int Id { get; set; }
        public int CalculoId { get; set; }
        public int TipoValorId { get; set; }
        public int SimboloId { get; set; }
        public decimal Grandeza { get; set; }
        public double? Marginal { get; set; }
        public string EntidadeCodigo1 { get; set; }
        public string EntidadeCodigo2 { get; set; }
        public string EntidadeCodigo3 { get; set; }
        public string EntidadeCodigo4 { get; set; }
        public string EntidadeCodigo5 { get; set; }
        public string EntidadeCodigo6 { get; set; }
        public int? UnidadeMedidaNumeradorId { get; set; }
        public int? UnidadeMedidaDenominadorId { get; set; }

        public Calculo Calculo { get; set; }
        public Simbolo Simbolo { get; set; }
        public TipoValor TipoValor { get; set; }
        public UnidadeMedida UnidadeMedidaDenominador { get; set; }
        public UnidadeMedida UnidadeMedidaNumerador { get; set; }
    }
}
