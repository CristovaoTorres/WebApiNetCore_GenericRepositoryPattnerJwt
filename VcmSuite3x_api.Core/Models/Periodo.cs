using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class Periodo
    {
        public Periodo()
        {
            PeriodoAgregadoItem = new HashSet<PeriodoAgregadoItem>();
            PeriodoCenario = new HashSet<PeriodoCenario>();
            RestricaoCenario = new HashSet<RestricaoCenario>();
        }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public int TipoEntidadeId { get; set; }
        public int TopologiaId { get; set; }

        public TipoEntidade TipoEntidade { get; set; }
        public Topologia Topologia { get; set; }
        public ICollection<PeriodoAgregadoItem> PeriodoAgregadoItem { get; set; }
        public ICollection<PeriodoCenario> PeriodoCenario { get; set; }
        public ICollection<RestricaoCenario> RestricaoCenario { get; set; }
    }
}
