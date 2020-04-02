using System;
using System.Collections.Generic;
using System.Text;

namespace VcmSuite3x.Application.Extensions
{
    public static class GrandezaExtensions
    {

        public static Decimal Convert(this Decimal value,
                                      Decimal factorNumeratorInput,
                                      Decimal factorDenominatorInput,
                                      Decimal factorNumeratorOutput,
                                      Decimal factorDenominatorOutput)
        {
            return Convert(value, factorNumeratorInput, factorNumeratorOutput) / Convert(1, factorDenominatorInput, factorDenominatorOutput);
        }

        public static Decimal Convert(this Decimal value,
                                     Decimal factorInput,
                                     Decimal factoroutpOutput)
        {
            return value * factoroutpOutput / factorInput;
        }

    }
}
