using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class Valvula
    {
        public Valvula()
        {
            DiagramaCenarioValvulaFarelo = new HashSet<DiagramaCenario>();
            DiagramaCenarioValvulaRemoido = new HashSet<DiagramaCenario>();
        }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public int TipoEntidadeId { get; set; }
        public int TopologiaId { get; set; }
        public int? ConjuntoId { get; set; }

        public Conjunto Conjunto { get; set; }
        public TipoEntidade TipoEntidade { get; set; }
        public Topologia Topologia { get; set; }
        public ICollection<DiagramaCenario> DiagramaCenarioValvulaFarelo { get; set; }
        public ICollection<DiagramaCenario> DiagramaCenarioValvulaRemoido { get; set; }
    }
}
