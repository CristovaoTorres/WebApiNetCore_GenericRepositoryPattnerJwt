using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class Contrato
    {
        public Contrato()
        {
            Corrente = new HashSet<Corrente>();
            FamiliaContrato = new HashSet<FamiliaContrato>();
            MercadoContrato = new HashSet<MercadoContrato>();
            ProdutoContrato = new HashSet<ProdutoContrato>();
        }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public int TipoEntidadeId { get; set; }
        public int TopologiaId { get; set; }
        public int? TipoProdutoId { get; set; }

        public TipoEntidade TipoEntidade { get; set; }
        public TipoProduto TipoProduto { get; set; }
        public Topologia Topologia { get; set; }
        public ICollection<Corrente> Corrente { get; set; }
        public ICollection<FamiliaContrato> FamiliaContrato { get; set; }
        public ICollection<MercadoContrato> MercadoContrato { get; set; }
        public ICollection<ProdutoContrato> ProdutoContrato { get; set; }
    }
}
