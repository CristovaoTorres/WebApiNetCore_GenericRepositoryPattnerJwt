using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class UnidadeComposta
    {
        public int Id { get; set; }
        public int NumeradorId { get; set; }
        public int DenominadorId { get; set; }

        public UnidadeMedida Denominador { get; set; }
        public UnidadeMedida Numerador { get; set; }
    }
}
