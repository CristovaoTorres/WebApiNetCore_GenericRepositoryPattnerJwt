using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class ConjuntoFarinha
    {
        public ConjuntoFarinha()
        {
            ConjuntoFarinhaProduto = new HashSet<ConjuntoFarinhaProduto>();
        }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public int TipoEntidadeId { get; set; }
        public int TopologiaId { get; set; }
        public int? ConjuntoId { get; set; }

        public Conjunto Conjunto { get; set; }
        public TipoEntidade TipoEntidade { get; set; }
        public Topologia Topologia { get; set; }
        public ICollection<ConjuntoFarinhaProduto> ConjuntoFarinhaProduto { get; set; }
    }
}
