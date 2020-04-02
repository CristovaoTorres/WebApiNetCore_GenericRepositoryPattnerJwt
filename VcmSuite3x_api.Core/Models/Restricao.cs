using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class Restricao
    {
        public Restricao()
        {
            RestricaoCenario = new HashSet<RestricaoCenario>();
            RestricaoCorrente = new HashSet<RestricaoCorrente>();
            RestricaoNo = new HashSet<RestricaoNo>();
        }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public int TipoEntidadeId { get; set; }
        public int TopologiaId { get; set; }
        public int TipoRestricaoId { get; set; }
        public int TipoProdutoId { get; set; }

        public TipoEntidade TipoEntidade { get; set; }
        public TipoProduto TipoProduto { get; set; }
        public TipoRestricao TipoRestricao { get; set; }
        public Topologia Topologia { get; set; }
        public ICollection<RestricaoCenario> RestricaoCenario { get; set; }
        public ICollection<RestricaoCorrente> RestricaoCorrente { get; set; }
        public ICollection<RestricaoNo> RestricaoNo { get; set; }
    }
}
