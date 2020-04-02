using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class Conjunto
    {
        public Conjunto()
        {
            ConjuntoFarinha = new HashSet<ConjuntoFarinha>();
            ConjuntoProduto = new HashSet<ConjuntoProduto>();
            DiagramaCenario = new HashSet<DiagramaCenario>();
            No = new HashSet<No>();
            PeriodoAgregado = new HashSet<PeriodoAgregado>();
            Regiao = new HashSet<Regiao>();
            Silo = new HashSet<Silo>();
            Valvula = new HashSet<Valvula>();
        }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public int TipoEntidadeId { get; set; }
        public int TopologiaId { get; set; }

        public TipoEntidade TipoEntidade { get; set; }
        public Topologia Topologia { get; set; }
        public ICollection<ConjuntoFarinha> ConjuntoFarinha { get; set; }
        public ICollection<ConjuntoProduto> ConjuntoProduto { get; set; }
        public ICollection<DiagramaCenario> DiagramaCenario { get; set; }
        public ICollection<No> No { get; set; }
        public ICollection<PeriodoAgregado> PeriodoAgregado { get; set; }
        public ICollection<Regiao> Regiao { get; set; }
        public ICollection<Silo> Silo { get; set; }
        public ICollection<Valvula> Valvula { get; set; }
    }
}
