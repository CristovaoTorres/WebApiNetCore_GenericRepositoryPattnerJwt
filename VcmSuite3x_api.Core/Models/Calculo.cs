using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class Calculo
    {
        public Calculo()
        {
            CalculoHistorico = new HashSet<CalculoHistorico>();
            Resultado = new HashSet<Resultado>();
        }

        public int Id { get; set; }
        public int CenarioId { get; set; }
        public bool Inativo { get; set; }
        public bool Agendado { get; set; }

        public Cenario Cenario { get; set; }
        public ICollection<CalculoHistorico> CalculoHistorico { get; set; }
        public ICollection<Resultado> Resultado { get; set; }
    }
}
