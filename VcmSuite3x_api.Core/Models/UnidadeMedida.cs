using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class UnidadeMedida
    {
        public UnidadeMedida()
        {
            MedidaCadeia = new HashSet<MedidaCadeia>();
            MedidaProjeto = new HashSet<MedidaProjeto>();
            Produto = new HashSet<Produto>();
            Propriedade = new HashSet<Propriedade>();
            ResultadoUnidadeMedidaDenominador = new HashSet<Resultado>();
            ResultadoUnidadeMedidaNumerador = new HashSet<Resultado>();
            UnidadeCompostaDenominador = new HashSet<UnidadeComposta>();
            UnidadeCompostaNumerador = new HashSet<UnidadeComposta>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Representacao { get; set; }
        public decimal FatorConversao { get; set; }
        public int TipoUnidadeId { get; set; }

        public TipoUnidade TipoUnidade { get; set; }
        public ICollection<MedidaCadeia> MedidaCadeia { get; set; }
        public ICollection<MedidaProjeto> MedidaProjeto { get; set; }
        public ICollection<Produto> Produto { get; set; }
        public ICollection<Propriedade> Propriedade { get; set; }
        public ICollection<Resultado> ResultadoUnidadeMedidaDenominador { get; set; }
        public ICollection<Resultado> ResultadoUnidadeMedidaNumerador { get; set; }
        public ICollection<UnidadeComposta> UnidadeCompostaDenominador { get; set; }
        public ICollection<UnidadeComposta> UnidadeCompostaNumerador { get; set; }
    }
}
