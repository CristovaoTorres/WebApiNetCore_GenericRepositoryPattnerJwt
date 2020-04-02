using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class TipoValor
    {
        public TipoValor()
        {
            Entrada = new HashSet<Entrada>();
            Resultado = new HashSet<Resultado>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Entrada> Entrada { get; set; }
        public ICollection<Resultado> Resultado { get; set; }
    }
}
