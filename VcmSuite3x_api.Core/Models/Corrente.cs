using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class Corrente
    {
        public Corrente()
        {
            CorrenteCenario = new HashSet<CorrenteCenario>();
            CorrenteCenarioLimite = new HashSet<CorrenteCenarioLimite>();
            CorrenteCenarioSimbolo = new HashSet<CorrenteCenarioSimbolo>();
            CorrenteDrawing = new HashSet<CorrenteDrawing>();
            CorrenteFamilia = new HashSet<CorrenteFamilia>();
            CorrenteProduto = new HashSet<CorrenteProduto>();
            DiagramaCenarioTransportadorFarelo = new HashSet<DiagramaCenario>();
            DiagramaCenarioTransportadorRemoido = new HashSet<DiagramaCenario>();
            RestricaoCorrente = new HashSet<RestricaoCorrente>();
        }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public int TipoEntidadeId { get; set; }
        public int TopologiaId { get; set; }
        public int? ModalId { get; set; }
        public string Nota { get; set; }
        public int EntradaId { get; set; }
        public int SaidaId { get; set; }
        public int? ContratoTakeOrPayId { get; set; }
        public int? DescontoId { get; set; }
        public bool ContabilizaVolume { get; set; }

        public Contrato ContratoTakeOrPay { get; set; }
        public Desconto Desconto { get; set; }
        public No Entrada { get; set; }
        public Modal Modal { get; set; }
        public No Saida { get; set; }
        public TipoEntidade TipoEntidade { get; set; }
        public Topologia Topologia { get; set; }
        public ICollection<CorrenteCenario> CorrenteCenario { get; set; }
        public ICollection<CorrenteCenarioLimite> CorrenteCenarioLimite { get; set; }
        public ICollection<CorrenteCenarioSimbolo> CorrenteCenarioSimbolo { get; set; }
        public ICollection<CorrenteDrawing> CorrenteDrawing { get; set; }
        public ICollection<CorrenteFamilia> CorrenteFamilia { get; set; }
        public ICollection<CorrenteProduto> CorrenteProduto { get; set; }
        public ICollection<DiagramaCenario> DiagramaCenarioTransportadorFarelo { get; set; }
        public ICollection<DiagramaCenario> DiagramaCenarioTransportadorRemoido { get; set; }
        public ICollection<RestricaoCorrente> RestricaoCorrente { get; set; }
    }
}
