using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VcmSuite3x_api.Models
{
    public class UnidadeMedidaResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Representacao { get; set; }
        public decimal FatorConversao { get; set; }
        public int TipoUnidadeId { get; set; }
    }
}
