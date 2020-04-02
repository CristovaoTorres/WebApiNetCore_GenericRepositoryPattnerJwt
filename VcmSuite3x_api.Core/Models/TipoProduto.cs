using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class TipoProduto
    {
        public TipoProduto()
        {
            Contrato = new HashSet<Contrato>();
            ElementoTipoProduto = new HashSet<ElementoTipoProduto>();
            Familia = new HashSet<Familia>();
            Restricao = new HashSet<Restricao>();
        }

        public int Id { get; set; }
        public int TipoUnidadeId { get; set; }
        public string Nome { get; set; }

        public TipoEntidade IdNavigation { get; set; }
        public TipoUnidade TipoUnidade { get; set; }
        public ICollection<Contrato> Contrato { get; set; }
        public ICollection<ElementoTipoProduto> ElementoTipoProduto { get; set; }
        public ICollection<Familia> Familia { get; set; }
        public ICollection<Restricao> Restricao { get; set; }
    }
}
