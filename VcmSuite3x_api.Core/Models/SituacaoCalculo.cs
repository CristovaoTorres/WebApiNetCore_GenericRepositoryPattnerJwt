using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class SituacaoCalculo
    {
        public SituacaoCalculo()
        {
            CalculoHistorico = new HashSet<CalculoHistorico>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public bool EstadoFinal { get; set; }

        public ICollection<CalculoHistorico> CalculoHistorico { get; set; }
    }
}
