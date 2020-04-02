using System;
using System.Collections.Generic;
using System.Text;

namespace VcmSuite3x.Application.Model
{
   public  class EntradaRequest
    {

        public EntradaRequest()
        {
            this.FatorConversaoNumerador = 1;
            this.FatorConversaoDenominador = 1;
        }

        private Dictionary<String, Int32> agrupamento = new Dictionary<String, Int32>();

        public Dictionary<String, Int32> Agrupamento
        {
            get { return this.agrupamento; }
            set { this.agrupamento = value; }
        }

        public int Id { get; set; }
        public int CenarioId { get; set; }
        public int TipoValorId { get; set; }
        public int SimboloId { get; set; }
        public decimal? Grandeza { get; set; }
        public string EntidadeCodigo1 { get; set; }
        public string EntidadeCodigo2 { get; set; }

        public string EntidadeCodigo3 { get; set; }
        public string EntidadeCodigo4 { get; set; }
        public string EntidadeCodigo5 { get; set; }
        public string EntidadeCodigo6 { get; set; }


        public decimal GrandezaApresentacao { get; set; }

        /// <summary>
        /// Representa o fator de conversão para ser utilizado na transformação
        /// da unidade de armazenamento para a unidade de apresentação.
        /// </summary>
        public decimal FatorConversaoNumerador { get; set; }

        /// <summary>
        /// Representa o fator de conversão para ser utilizado na transformação
        /// da unidade de armazenamento para a unidade de apresentação.
        /// </summary>
        public decimal FatorConversaoDenominador { get; set; }


        /// <summary>
        /// Representação da unidade de medida do valor.
        /// </summary>
        public string Representacao { get; set; }

        /// <summary>
        /// Representa a unidade de medida presente no numerador deste resultado.
        /// </summary>
        public int? UnidadeMedidaNumeradorId { get; set; }

        /// <summary>
        /// Representa a unidade de medida presente no denominador deste resultado.
        /// </summary>
        public int? UnidadeMedidaDenominadorId { get; set; }

        public Decimal? ValorAtual { get; set; }
    }
}
