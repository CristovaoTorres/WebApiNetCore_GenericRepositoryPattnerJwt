using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VcmSuite3x_api.Core.Models
{
    public partial class TipoUnidade
    {
        public TipoUnidade()
        {
            Desconto = new HashSet<Desconto>();
            SimboloTipoUnidadeDenominador = new HashSet<Simbolo>();
            SimboloTipoUnidadeNumerador = new HashSet<Simbolo>();
            TemplateMedida = new HashSet<TemplateMedida>();
            TipoProduto = new HashSet<TipoProduto>();
            UnidadeMedida = new HashSet<UnidadeMedida>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Desconto> Desconto { get; set; }
        public ICollection<Simbolo> SimboloTipoUnidadeDenominador { get; set; }
        public ICollection<Simbolo> SimboloTipoUnidadeNumerador { get; set; }
        public ICollection<TemplateMedida> TemplateMedida { get; set; }
        public ICollection<TipoProduto> TipoProduto { get; set; }
        public ICollection<UnidadeMedida> UnidadeMedida { get; set; }
    }
}
