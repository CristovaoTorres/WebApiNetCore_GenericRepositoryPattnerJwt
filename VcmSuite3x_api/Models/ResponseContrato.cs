using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VcmSuite3x_api.Models
{
    public class ResponseContrato
    {

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public int TipoEntidadeId { get; set; }
        public int TopologiaId { get; set; }
        public int? TipoProdutoId { get; set; }

        public string TipoEntidadeNome { get; set; }
        public string TipoProdutoNome { get; set; }

    }
}
