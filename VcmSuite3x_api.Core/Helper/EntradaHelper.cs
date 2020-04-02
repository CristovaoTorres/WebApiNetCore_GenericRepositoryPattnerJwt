using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VcmSuite3x_api.Core.Extension;
using VcmSuite3x_api.Core.Interface;
using VcmSuite3x_api.Core.Models;
using VcmSuite3x_api.Core.Repository;

namespace VcmSuite3x_api.Core.Helper
{
    public class EntradaHelper
    {
        private readonly IUnitOfWork _unitOfWork;
        public EntradaHelper()
        {
            _unitOfWork = new UnitOfWork();
        }



        public UnidadeMedida UnidadeMedidaNumerador { get; set; }
        public UnidadeMedida UnidadeMedidaDenominador { get; set; }

        public int ScenarioId { get; set; }
        public decimal FatorConversaoDenominador { get { return 1; } }
        public decimal FatorConversaoNumerador { get { return 1; } }

        public decimal GrandezaApresentacao
        {
            get
            {
                decimal grandezaApresentacao = 0m;
                Decimal grandeza = this.Grandeza.HasValue ? this.Grandeza.Value : 0m;

                if (!grandeza.Equals(0m))
                {
                    if (this.UnidadeMedidaNumerador == null)
                    {
                        grandezaApresentacao = grandeza;
                    }
                    else
                    {
                        if (this.UnidadeMedidaDenominador == null)
                        {
                            grandezaApresentacao = grandeza.Convert(this.FatorConversaoNumerador, this.UnidadeMedidaNumerador.FatorConversao);
                        }
                        else
                        {
                            grandezaApresentacao = grandeza.Convert
                                (
                                    this.FatorConversaoNumerador,
                                    this.FatorConversaoDenominador,
                                    this.UnidadeMedidaNumerador.FatorConversao,
                                    this.UnidadeMedidaDenominador.FatorConversao
                                );
                        }
                    }
                }
                else
                {
                    grandezaApresentacao = 0m;
                }

                return grandezaApresentacao;
            }
        }

        public string Representacao
        {
            get
            {
                // Formata representação do valor.
                StringBuilder sb = new StringBuilder();
                if (this.UnidadeMedidaNumerador != null)
                {
                    sb.Append(this.UnidadeMedidaNumerador.Representacao);

                    if (!(this.UnidadeMedidaDenominador == null || string.IsNullOrEmpty(this.UnidadeMedidaDenominador.Representacao)))
                    {
                        if (sb.Length > 0)
                        {
                            // Já foi acrescentada representação de unidade do numerador.
                            sb.Append("/");
                        }
                        sb.Append(this.UnidadeMedidaDenominador.Representacao);
                    }
                }

                return sb.ToString();
            }
        }

        public EntradaHelper(int id, int tipoValorId, int simboloId, decimal grandeza
                        , string entidadeCodigo1, string entidadeCodigo2, string entidadeCodigo3
                        , string entidadeCodigo4, string entidadeCodigo5, string entidadeCodigo6
                        , int? unidadeMedidaNumeradorId, int? unidadeMedidaDenominadorId)
        {
            this.Id = id;
            this.Grandeza = grandeza;
            this.SimboloId = simboloId;
            this.TipoValorId = tipoValorId;
            this.EntidadeCodigo1 = entidadeCodigo1;
            this.EntidadeCodigo2 = entidadeCodigo2;
            this.EntidadeCodigo3 = entidadeCodigo3;
            this.EntidadeCodigo4 = entidadeCodigo4;
            this.EntidadeCodigo5 = entidadeCodigo5;
            this.EntidadeCodigo6 = entidadeCodigo6;
            this.UnidadeMedidaNumeradorId = unidadeMedidaNumeradorId;
            this.UnidadeMedidaDenominadorId = unidadeMedidaDenominadorId;

            _unitOfWork = new UnitOfWork();

            this.UnidadeMedidaNumerador = _unitOfWork.UnidadeMedidaRepository.Get(y => y.Id == unidadeMedidaNumeradorId).FirstOrDefault();
            this.UnidadeMedidaDenominador = _unitOfWork.UnidadeMedidaRepository.Get(y => y.Id == unidadeMedidaDenominadorId).FirstOrDefault();

        }

        public int Id { get; set; }
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
    }
}

