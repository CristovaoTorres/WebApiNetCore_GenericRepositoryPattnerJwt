using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VcmSuite3x.Application.Extensions;
using VcmSuite3x.Application.Model;
using VcmSuite3x_api.Core.Models;
using VcmSuite3x_api.Core.Repository;

namespace VcmSuite3x.Application.Util
{
    /// <summary>
    /// Extensões para <see cref="EntradaRequest"/>.
    /// </summary>

    public static class ValorExtension
    {
        private static readonly UnitOfWork _unitOfw = new UnitOfWork();

        private static readonly Int32 _tipoValorUsuario = GetTipoUnidadeUsuario();
        private static UnidadeMedida _unidadeMedidaNumerador, _unidadeMedidaDenominador;

        /// <summary>
        /// Ajusta o valor da propriedade <see cref="EntradaRequest.Grandeza"/> de acordo com as unidades de medida correspondentes.
        /// </summary>
        /// <remarks>
        /// O objetivo é transformar o valor de apresentação utilizando a unidade de medida de armazenamento.
        /// </remarks>
        public static void AdjustFromUI(this EntradaRequest valor)
        {
            if (!valor.GrandezaApresentacao.Equals(0m))
            {
                valor.TipoValorId = _tipoValorUsuario;

                UnidadeMedida unidadeMedidaNumerador = GetUnidadeMedida(valor.UnidadeMedidaNumeradorId, ref _unidadeMedidaNumerador);
                if (unidadeMedidaNumerador == null)
                {
                    valor.Grandeza = valor.GrandezaApresentacao;
                }
                else
                {
                    UnidadeMedida unidadeMedidaDenominador = GetUnidadeMedida(valor.UnidadeMedidaDenominadorId, ref _unidadeMedidaDenominador);
                    if (unidadeMedidaDenominador == null)
                    {
                        valor.Grandeza = valor.GrandezaApresentacao.Convert(unidadeMedidaNumerador.FatorConversao, valor.FatorConversaoDenominador);
                    }
                    else
                    {
                        valor.Grandeza = valor.GrandezaApresentacao.Convert
                            (
                                unidadeMedidaNumerador.FatorConversao,
                                unidadeMedidaDenominador.FatorConversao,
                                valor.FatorConversaoNumerador,
                                valor.FatorConversaoDenominador
                            );
                    }
                }
            }
            else
            {
                valor.Grandeza = 0m;
            }
        }
        internal static void AdjustFromUI(this EntradaRequest valor, Decimal grandeza)
        {
            valor.GrandezaApresentacao = grandeza;
            valor.AdjustFromUI();
        }
        /// <summary>
        /// Ajusta o valor da propriedade <see cref="EntradaRequest.GrandezaApresentacao"/> de acordo com as unidades de medida correspondentes.
        /// </summary>
        /// <remarks>
        /// O objetivo é transformar o valor (na unidade de armazenamento) utilizando a unidade de medida desejada para apreentação.
        /// </remarks>
        public static void AdjustToUI(this EntradaRequest valor)
        {
            UnidadeMedida unidadeMedidaNumerador = GetUnidadeMedida(valor.UnidadeMedidaNumeradorId, ref _unidadeMedidaNumerador);
            UnidadeMedida unidadeMedidaDenominador = GetUnidadeMedida(valor.UnidadeMedidaDenominadorId, ref _unidadeMedidaDenominador);

            Decimal grandeza = (valor.Grandeza.HasValue ? valor.Grandeza.Value : 0m);

            // Converte de SI para unidade usada na apresentação.
            if (!valor.Grandeza.Equals(0m))
            {
                if (unidadeMedidaNumerador == null)
                {
                    valor.GrandezaApresentacao = grandeza;
                }
                else
                {
                    if (unidadeMedidaDenominador == null)
                    {
                        valor.GrandezaApresentacao = grandeza.Convert(valor.FatorConversaoNumerador, unidadeMedidaNumerador.FatorConversao);
                    }
                    else
                    {
                        valor.GrandezaApresentacao = grandeza.Convert
                            (
                                valor.FatorConversaoNumerador,
                                valor.FatorConversaoDenominador,
                                unidadeMedidaNumerador.FatorConversao,
                                unidadeMedidaDenominador.FatorConversao
                            );
                    }
                }
            }
            else
            {
                valor.GrandezaApresentacao = 0m;
            }

            // Formata representação do valor.
            StringBuilder sb = new StringBuilder();
            if (unidadeMedidaNumerador != null)
            {
                sb.Append(unidadeMedidaNumerador.Representacao);

                if (!(unidadeMedidaDenominador == null || string.IsNullOrEmpty(unidadeMedidaDenominador.Representacao)))
                {
                    if (sb.Length > 0)
                    {
                        // Já foi acrescentada representação de unidade do numerador.
                        sb.Append("/");
                    }
                    sb.Append(unidadeMedidaDenominador.Representacao);
                }
            }
            valor.Representacao = sb.ToString();
        }

        private static UnidadeMedida GetUnidadeMedida(Int32? unidadeMedidaId, ref UnidadeMedida unidadeAtual)
        {
            if (unidadeMedidaId.HasValue)
            {
                Int32 unidadeId = unidadeMedidaId.Value;
                if (unidadeAtual == null || unidadeAtual.Id != unidadeId)
                {
                    // Unidade de medida diferente da última usada. Neste caso faz a consulta para obter a atual.
                    unidadeAtual = _unitOfw.UnidadeMedidaRepository.Get(y => y.Id == unidadeId).FirstOrDefault();
                }

                return unidadeAtual;
            }

            return null;
        }
        private static Int32 GetTipoUnidadeUsuario()
        {
            TipoValor tipo = _unitOfw.TipoValorRepository.Get(y => y.Nome == "Usuario").FirstOrDefault();
            if (tipo != null)
            {
                return tipo.Id;
            }
            return 0;
        }
    }
}
