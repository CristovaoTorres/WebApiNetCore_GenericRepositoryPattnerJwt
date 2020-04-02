using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class CorrenteCenarioLimite
    {
        public int CorrenteId { get; set; }
        public int CenarioId { get; set; }
        public bool LimiteMinimoProduto { get; set; }
        public bool? LimiteMinimoProdutoTotal { get; set; }
        public bool LimiteMinimoProdutoSemiContinuo { get; set; }
        public bool LimiteMaximoProduto { get; set; }
        public bool? LimiteMaximoProdutoTotal { get; set; }
        public bool NumeroMinimoVagoesProduto { get; set; }
        public bool NumeroMaximoVagoesProduto { get; set; }
        public bool CapacidadeMinimaVagaoProduto { get; set; }
        public bool CapacidadeMaximaVagaoProduto { get; set; }
        public bool LimiteMinimoFamilia { get; set; }
        public bool? LimiteMinimoFamiliaTotal { get; set; }
        public bool LimiteMinimoFamiliaSemiContinuo { get; set; }
        public bool LimiteMaximoFamilia { get; set; }
        public bool? LimiteMaximoFamiliaTotal { get; set; }
        public bool NumeroMinimoVagoesFamilia { get; set; }
        public bool NumeroMaximoVagoesFamilia { get; set; }
        public bool CapacidadeMinimaVagaoFamilia { get; set; }
        public bool CapacidadeMaximaVagaoFamilia { get; set; }

        public Cenario Cenario { get; set; }
        public Corrente Corrente { get; set; }
    }
}
