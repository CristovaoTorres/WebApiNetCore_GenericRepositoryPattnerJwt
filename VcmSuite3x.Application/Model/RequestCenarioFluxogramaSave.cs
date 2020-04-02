using System;
using System.Collections.Generic;
using System.Text;
using VcmSuite3x_api.Core.Models;

namespace VcmSuite3x.Application.Model
{
    public class RequestCenarioFluxogramaSave
    {

        public int NoId { get; set; }
        public int CenarioId { get; set; }
        public bool Suprimento { get; set; }
        public bool SuprimentoAgregado { get; set; }
        public bool SuprimentoSemiContinuo { get; set; }
        public bool SuprimentoAgregadoSemiContinuo { get; set; }
        public bool? CapacidadePoroes { get; set; }
        public bool IncluirCalculoImpostos { get; set; }
    }

    public class RequestCenarioArmazenamentoSave
    {
        public int NoId { get; set; }
        public int CenarioId { get; set; }
        public int TipoArmazenamentoId { get; set; }
        public bool IncluirCalculoImpostos { get; set; }
        public int Capex { get; set; }
        public bool ComFaixa { get; set; }
    }


    public class RequestCenarioProcessamentoSave
    {
        public int NoId { get; set; }
        public int CenarioId { get; set; }
        public bool IncluirCalculoImpostos { get; set; }
        public bool ConsumoEnergiaEletrica { get; set; }
        public bool ConsumoVapor { get; set; }
    }
}
