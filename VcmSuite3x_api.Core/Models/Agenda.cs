using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class Agenda
    {
        public Agenda()
        {
            AgendaOtimizacao = new HashSet<AgendaOtimizacao>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public bool Ativo { get; set; }
        public string Nota { get; set; }

        public ICollection<AgendaOtimizacao> AgendaOtimizacao { get; set; }
    }
}
