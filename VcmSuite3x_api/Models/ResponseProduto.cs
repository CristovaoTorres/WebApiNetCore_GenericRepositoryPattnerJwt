using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using VcmSuite3x_api.Core.Models;

namespace VcmSuite3x_api.Models
{
    public class ResponseProduto
    {
        public int Id { get; set; }



        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public int TipoEntidadeId { get; set; }
        public int TopologiaId { get; set; }
        public int UnidadeMedidaId { get; set; }

        [JsonIgnore]
        public TipoEntidade TipoEntidade { get; set; }

        public List<UnidadeMedidaHelper> UnidadesMedida { get; set; }

        private string _tipoProdutoNome;
        public string TipoProdutoNome
        {
            get
            {
                return this.TipoEntidade != null ? this.TipoEntidade.Nome : "";
            }

            set { _tipoProdutoNome = value; }
        }

    }
}
