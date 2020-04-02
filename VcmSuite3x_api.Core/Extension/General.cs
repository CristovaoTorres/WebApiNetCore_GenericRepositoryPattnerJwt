using System;
using System.Collections.Generic;
using System.Text;

namespace VcmSuite3x_api.Core.Extension
{
    public static class GeneralExtension
    {
        /// <summary>
        ///Converte valor considerando-se os fatores de conversão de entrada e saída para valores compostos.
        /// </summary>
        /// <param name="value">Valor para conversão.</param>
        /// <param name="factorNumeratorInput">Fator da unidade de medida no numerador.</param>
        /// <param name="factorDenominatorInput">Fator da unidade de medida no denominador.</param>
        /// <param name="factorNumeratorOutput">Fator da unidade de medida do numerador desejado como retorno.</param>
        /// <param name="factorDenominatorOutput">Fator da unidade de medida do denominador desejado como retorno.</param>
        /// <returns>Retorna o valor para a conversão aplicada.</returns>
        public static Decimal Convert(this Decimal value,
                                      Decimal factorNumeratorInput,
                                      Decimal factorDenominatorInput,
                                      Decimal factorNumeratorOutput,
                                      Decimal factorDenominatorOutput)
        {
            return Convert(value, factorNumeratorInput, factorNumeratorOutput) / Convert(1, factorDenominatorInput, factorDenominatorOutput);
        }

        /// <summary>
        /// Converte valor considerando-se os fatores de conversão de entrada e saída.
        /// </summary>
        /// <param name="value">Valor para conversão.</param>
        /// <param name="factorInput">Fator de conversão de entrada.</param>
        /// <param name="factoroutpOutput">Fator de conversão de saída.</param>
        /// <returns>Retorna o valor para a conversão aplicada.</returns>
        public static Decimal Convert(this Decimal value,
                                      Decimal factorInput,
                                      Decimal factoroutpOutput)
        {
            return value * factoroutpOutput / factorInput;
        }
    }
}
