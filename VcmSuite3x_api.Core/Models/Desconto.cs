using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class Desconto
    {
        public Desconto()
        {
            Corrente = new HashSet<Corrente>();
            FaixaDesconto = new HashSet<FaixaDesconto>();
        }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public int TipoEntidadeId { get; set; }
        public int TopologiaId { get; set; }
        public int ModalId { get; set; }
        public int TipoUnidadeId { get; set; }

        public Modal Modal { get; set; }
        public TipoEntidade TipoEntidade { get; set; }
        public TipoUnidade TipoUnidade { get; set; }
        public Topologia Topologia { get; set; }
        public ICollection<Corrente> Corrente { get; set; }
        public ICollection<FaixaDesconto> FaixaDesconto { get; set; }
    }
}
