using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VcmSuite3x_api.Core.Models;

namespace VcmSuite3x_api.Models
{
    public class TipoUnidadeResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public List<UnidadeMedidaResponse> UnidadeMedida { get; set; }
    }
}
