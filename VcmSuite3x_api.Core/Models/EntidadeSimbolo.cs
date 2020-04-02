using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class EntidadeSimbolo
    {
        public int SimboloId { get; set; }
        public int TipoEntidadeId { get; set; }
        public byte Dimensao { get; set; }
        public bool UnidadeNumerador { get; set; }
        public bool UnidadeDenominador { get; set; }

        public Simbolo Simbolo { get; set; }
        public TipoEntidade TipoEntidade { get; set; }
    }
}
