using System;
using System.Collections.Generic;
using System.Text;

namespace VcmSuite3x.Application.ViewModel
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
