using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class Simbolo
    {
        public Simbolo()
        {
            CorrenteCenarioSimbolo = new HashSet<CorrenteCenarioSimbolo>();
            EntidadeSimbolo = new HashSet<EntidadeSimbolo>();
            Entrada = new HashSet<Entrada>();
            NoCenarioSimbolo = new HashSet<NoCenarioSimbolo>();
            ProdutoCenarioSimbolo = new HashSet<ProdutoCenarioSimbolo>();
            Resultado = new HashSet<Resultado>();
        }

        public int Id { get; set; }
        public int CadeiaId { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int? TipoUnidadeNumeradorId { get; set; }
        public int? TipoUnidadeDenominadorId { get; set; }
        public bool? DadoEntrada { get; set; }
        public int Tipo { get; set; }
        public decimal? Default { get; set; }

        public Cadeia Cadeia { get; set; }
        public TipoUnidade TipoUnidadeDenominador { get; set; }
        public TipoUnidade TipoUnidadeNumerador { get; set; }
        public ICollection<CorrenteCenarioSimbolo> CorrenteCenarioSimbolo { get; set; }
        public ICollection<EntidadeSimbolo> EntidadeSimbolo { get; set; }
        public ICollection<Entrada> Entrada { get; set; }
        public ICollection<NoCenarioSimbolo> NoCenarioSimbolo { get; set; }
        public ICollection<ProdutoCenarioSimbolo> ProdutoCenarioSimbolo { get; set; }
        public ICollection<Resultado> Resultado { get; set; }
    }
}
