using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VcmSuite3x_api.Models
{
    public class UnidadeMedidaHelper
    {

        public string Value { get; set; }
        public bool Selected { get; set; }
        public string Text { get; set; }


        public UnidadeMedidaHelper(int idUnidade, int idUnidadeMedidaProdutoSelectd, string Nome)
        {
            this.Value = idUnidade.ToString();
            this.Selected = idUnidadeMedidaProdutoSelectd == idUnidade;
            this.Text = Nome;
        }
    }
}
