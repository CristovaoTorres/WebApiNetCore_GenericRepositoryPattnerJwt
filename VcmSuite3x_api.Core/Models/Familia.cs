using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class Familia
    {
        public Familia()
        {
            CorrenteFamilia = new HashSet<CorrenteFamilia>();
            FamiliaContrato = new HashSet<FamiliaContrato>();
            NoFamilia = new HashSet<NoFamilia>();
            ProdutoFamilia = new HashSet<ProdutoFamilia>();
        }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public int TipoEntidadeId { get; set; }
        public int TopologiaId { get; set; }
        public int TipoProdutoId { get; set; }

        public TipoEntidade TipoEntidade { get; set; }
        public TipoProduto TipoProduto { get; set; }
        public Topologia Topologia { get; set; }
        public ICollection<CorrenteFamilia> CorrenteFamilia { get; set; }
        public ICollection<FamiliaContrato> FamiliaContrato { get; set; }
        public ICollection<NoFamilia> NoFamilia { get; set; }
        public ICollection<ProdutoFamilia> ProdutoFamilia { get; set; }
    }
}
