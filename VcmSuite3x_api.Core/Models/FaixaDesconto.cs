using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class FaixaDesconto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public int TipoEntidadeId { get; set; }
        public int TopologiaId { get; set; }
        public int DescontoId { get; set; }

        public Desconto Desconto { get; set; }
        public TipoEntidade TipoEntidade { get; set; }
        public Topologia Topologia { get; set; }
    }
}
