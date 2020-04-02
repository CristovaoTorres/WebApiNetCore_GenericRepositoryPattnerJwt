using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class Produto
    {
        public Produto()
        {
            ConjuntoFarinhaProduto = new HashSet<ConjuntoFarinhaProduto>();
            ConjuntoProduto = new HashSet<ConjuntoProduto>();
            CorrenteProduto = new HashSet<CorrenteProduto>();
            NoProduto = new HashSet<NoProduto>();
            ProdutoCenarioSimbolo = new HashSet<ProdutoCenarioSimbolo>();
            ProdutoContrato = new HashSet<ProdutoContrato>();
            ProdutoFamilia = new HashSet<ProdutoFamilia>();
            PropriedadeProduto = new HashSet<PropriedadeProduto>();
        }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public int TipoEntidadeId { get; set; }
        public int TopologiaId { get; set; }
        public int UnidadeMedidaId { get; set; }

        public TipoEntidade TipoEntidade { get; set; }
        public Topologia Topologia { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }
        public ICollection<ConjuntoFarinhaProduto> ConjuntoFarinhaProduto { get; set; }
        public ICollection<ConjuntoProduto> ConjuntoProduto { get; set; }
        public ICollection<CorrenteProduto> CorrenteProduto { get; set; }
        public ICollection<NoProduto> NoProduto { get; set; }
        public ICollection<ProdutoCenarioSimbolo> ProdutoCenarioSimbolo { get; set; }
        public ICollection<ProdutoContrato> ProdutoContrato { get; set; }
        public ICollection<ProdutoFamilia> ProdutoFamilia { get; set; }
        public ICollection<PropriedadeProduto> PropriedadeProduto { get; set; }
    }
}
