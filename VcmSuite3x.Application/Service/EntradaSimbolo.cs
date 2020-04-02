using FastMember;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VcmSuite3x.Application.Interface;
using VcmSuite3x.Application.Util;
using VcmSuite3x_api.Core.Helper;
using VcmSuite3x_api.Core.Interface;
using VcmSuite3x_api.Core.Models;
using static VcmSuite3x.Application.Util.Enum;

namespace VcmSuite3x.Application.Service
{
    public class EntradaSimbolo : IEntradaSimbolo
    {
        private readonly ISimboloService _simboloService;
        private readonly IUnitOfWork _unitOfWork;
        public EntradaSimbolo(ISimboloService simboloService, IUnitOfWork unitOfWork)
        {
            _simboloService = simboloService;
            _unitOfWork = unitOfWork;
        }
        public EntradaSimbolo()
        {

        }

        public EntradaSimbolo GetSimbolo(int scenarioId, string codigo, EEntryBySymbolType entryBySymbolType)
        {
            EntradaSimbolo entradaSimbolo = new EntradaSimbolo();
            switch (entryBySymbolType)
            {
                case EEntryBySymbolType.UF_ProductCost: SetPreferences(2, 3, new string[] { "CusMP" }, new string[] { "Unidade", "Produto", "Período", "Custo" }); break;
                case EEntryBySymbolType.UA_InitialVolume: SetPreferences(2, 2, new string[] { "VolIni" }, new string[] { "Unidade", "Produto", "Volume Inicial" }); break;
                case EEntryBySymbolType.UA_AgrupedVolume: SetPreferences(2, 2, new string[] { "VolMinT", "VolMaxT" }, new string[] { "Unidade", "Período", "Volume Mínimo", "Volume Máximo" }); break;
                case EEntryBySymbolType.UA_VariableCost: SetPreferences(2, 3, new string[] { "valor", "cFin", "cusArm", "cusSeg" }, new string[] { "Unidade", "Produto", "Período", "Valor do produto<br/>em Estoque", "Custo Financeiro", "Custo de<br/>Armazenagem", "Custo do Seguro" }); break;
                case EEntryBySymbolType.UA_FixedCost: SetPreferences(2, 2, new string[] { "CfxoUA" }, new string[] { "Unidade", "Período", "Custo Fixo" }); break;
                case EEntryBySymbolType.UA_Handling: SetPreferences(2, 3, new string[] { "hIn", "hOut" }, new string[] { "Unidade", "Produto", "Período", "Custo de Handling<br/>no Recebimento", "Custo de Handling<br/>na Expedição" }); break;
                case EEntryBySymbolType.UA_Retention: SetPreferences(2, 3, new string[] { "pde" }, new string[] { "Unidade", "Produto", "Período", "Retenção" }); break;
                case EEntryBySymbolType.UA_EntryLimit: SetPreferences(0, 0, new string[] { }, new string[] { }); break;
                case EEntryBySymbolType.UA_ExitLimit: SetPreferences(0, 0, new string[] { }, new string[] { }); break;
                case EEntryBySymbolType.MC_DemandaProduto: SetPreferences(2, 3, new string[] { "DemMin", "DemMax" }, new string[] { "Unidade", "Produto", "Período", "Demanda Mínima", "Demanda Máxima" }); break;
                default: SetPreferences(0, 0, new string[] { "" }, new string[] { "" }); break;
            }

            entradaSimbolo.DimensionStart = this.DimensionStart;
            entradaSimbolo.DimensionSize = this.DimensionSize;
            entradaSimbolo.SymbolCodes = this.SymbolCodes;
            entradaSimbolo.ColumnNames = this.ColumnNames;


            entradaSimbolo.Symbols = _simboloService.GetSimbolsByCodeList(this.SymbolCodesList);

            Simbolo symbolOne = entradaSimbolo.Symbols.FirstOrDefault(); /* wired */
            NoCenarioSimbolo scenarioSymbol = _unitOfWork.NoCenarioSimboloRepository.Get(y => y.No.Codigo == codigo && y.CenarioId == scenarioId && y.SimboloId == symbolOne.Id).FirstOrDefault();

            bool scenarioSymbolNotNull = scenarioSymbol != null;

            entradaSimbolo.Detailed = scenarioSymbolNotNull ? scenarioSymbol.Detalhado.GetValueOrDefault(true) : symbolOne.Preferences.Detailed;
            entradaSimbolo.TypeEntry = scenarioSymbolNotNull ? scenarioSymbol.TipoEntrada.GetValueOrDefault(0) : symbolOne.Preferences.TypeEntry;
            entradaSimbolo.TypeDetail = scenarioSymbolNotNull ? scenarioSymbol.TipoDetalhe.GetValueOrDefault(0) : symbolOne.Preferences.TypeDetail;
            entradaSimbolo.ExactValue = scenarioSymbolNotNull ? scenarioSymbol.ValorExato.GetValueOrDefault(false) : symbolOne.Preferences.ExactValue;


            entradaSimbolo.Entries = _unitOfWork.GetValuesFromProcedure(scenarioId, codigo, entradaSimbolo.Symbols, entradaSimbolo.TypeEntry,
                                                                        entradaSimbolo.Detailed, entradaSimbolo.ExactValue)
                                                                        .Select(s => new EntradaItem(s)).ToList();
            this.Symbols = entradaSimbolo.Symbols;
            this.Entries = entradaSimbolo.Entries;

            entradaSimbolo.EntriesProcessed = ProcessedEntries();

            return entradaSimbolo;
        }

        #region Properties
        [JsonIgnore]
        public string[] SymbolCodes { get; set; }
        [JsonIgnore]
        public List<string> SymbolCodesList { get { return this.SymbolCodes.ToList(); } }
        [JsonIgnore]
        public List<Simbolo> Symbols { get; set; }

        public string Locale { get; set; }

        public int DimensionStart { get; set; }
        public int DimensionSize { get; set; }
        public string[] ColumnNames { get; set; }
        [JsonIgnore]
        public List<string> ColumnNamesList { get { return this.ColumnNames.ToList(); } }

        public bool Detailed { get; set; }
        public int TypeDetail { get; set; }
        public int TypeEntry { get; set; }
        public bool ExactValue { get; set; }

        [JsonIgnore]
        public List<EntradaItem> Entries { get; set; }

        public List<dynamic> EntriesProcessed { get; set; }
        #endregion

        #region Methods Helpers
        public void SetPreferences(int dimensionStart, int dimensionSize, string[] symbolCodes, string[] columns)
        {
            this.DimensionStart = dimensionStart;
            this.DimensionSize = dimensionSize;
            this.SymbolCodes = symbolCodes;
            this.ColumnNames = columns;
        }

        public List<dynamic> ProcessedEntries()
        {

            List<dynamic> list = new List<dynamic>();
            try
            {
                int row = 0;
                int simboloId = 0;
                bool firstLooping = true;
                int columnEntrada = -1;
                string simboloCodigo = "";

                foreach (EntradaItem entrada in this.Entries)
                {
                    if (entrada.SimboloId != simboloId)
                    {
                        row = 0;
                        firstLooping = (simboloId == 0);
                        simboloId = entrada.SimboloId;

                        simboloCodigo = this.Symbols.Where(s => s.Id == simboloId).FirstOrDefault().Codigo;
                        columnEntrada = Array.FindIndex(this.SymbolCodes, t => t.Equals(simboloCodigo, StringComparison.InvariantCultureIgnoreCase));
                    }

                    if (firstLooping)
                    {
                        Dictionary<String, Object> items = new Dictionary<String, Object>();

                        var rowInfo = ObjectAccessor.Create(entrada);
                        for (int i = 0; i < this.DimensionSize; i++)
                        {
                            string entidade = "EntidadeCodigo" + (i + 1);
                            items.Add(entidade, rowInfo[entidade]);
                        }

                        for (int i = 0; i < this.Symbols.Count(); i++)
                        {
                            string entidade = "Entrada" + i;
                            items.Add(entidade, null);
                        }

                        list.Add(items);
                    }

                    list[row]["Entrada" + (columnEntrada)] = entrada;

                    row++;
                }

            }
            catch (Exception e)
            {

                throw e;
            }

            return list;
        }
        #endregion
    }

    public class EntradaItem
    {
        public EntradaItem() { }
        public EntradaItem(EntradaHelper entry)
        {
            this.Id = entry.Id;
            this.ScenarioId = entry.ScenarioId;
            this.TipoValorId = entry.TipoValorId;
            this.SimboloId = entry.SimboloId;
            this.Grandeza = entry.Grandeza;
            this.EntidadeCodigo1 = entry.EntidadeCodigo1;
            this.EntidadeCodigo2 = entry.EntidadeCodigo2;
            this.EntidadeCodigo3 = entry.EntidadeCodigo3;
            this.EntidadeCodigo4 = entry.EntidadeCodigo4;
            this.EntidadeCodigo5 = entry.EntidadeCodigo5;
            this.EntidadeCodigo6 = entry.EntidadeCodigo6;
            this.UnidadeMedidaNumeradorId = entry.UnidadeMedidaNumeradorId;
            this.UnidadeMedidaDenominadorId = entry.UnidadeMedidaDenominadorId;
            this.FatorConversaoDenominador = entry.FatorConversaoDenominador;
            this.FatorConversaoNumerador = entry.FatorConversaoNumerador;
            this.GrandezaApresentacao = entry.GrandezaApresentacao;
            this.Representacao = entry.Representacao;

        }

        public int Id { get; set; }
        public int ScenarioId { get; set; }

        public int TipoValorId { get; set; }
        public int SimboloId { get; set; }
        public decimal? Grandeza { get; set; }
        public string EntidadeCodigo1 { get; set; }
        public string EntidadeCodigo2 { get; set; }
        public string EntidadeCodigo3 { get; set; }
        public string EntidadeCodigo4 { get; set; }
        public string EntidadeCodigo5 { get; set; }
        public string EntidadeCodigo6 { get; set; }
        public int? UnidadeMedidaNumeradorId { get; set; }
        public int? UnidadeMedidaDenominadorId { get; set; }


        public decimal FatorConversaoDenominador { get; set; }
        public decimal FatorConversaoNumerador { get; set; }

        public decimal GrandezaApresentacao { get; set; }

        public string Representacao { get; set; }
    }

}

