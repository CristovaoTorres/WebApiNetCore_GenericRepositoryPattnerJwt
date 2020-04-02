using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class Propriedade
    {
        public Propriedade()
        {
            PropriedadeAgrupamentoDependente = new HashSet<PropriedadeAgrupamento>();
            PropriedadeAgrupamentoPai = new HashSet<PropriedadeAgrupamento>();
            PropriedadeProduto = new HashSet<PropriedadeProduto>();
            PropriedadeTopologia = new HashSet<PropriedadeTopologia>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Predefinido { get; set; }
        public int CadeiaId { get; set; }
        public int UnidadeMedidaId { get; set; }
        public int? TipoPropriedadeId { get; set; }

        public Cadeia Cadeia { get; set; }
        public TipoPropriedade TipoPropriedade { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }
        public ICollection<PropriedadeAgrupamento> PropriedadeAgrupamentoDependente { get; set; }
        public ICollection<PropriedadeAgrupamento> PropriedadeAgrupamentoPai { get; set; }
        public ICollection<PropriedadeProduto> PropriedadeProduto { get; set; }
        public ICollection<PropriedadeTopologia> PropriedadeTopologia { get; set; }
    }
}
