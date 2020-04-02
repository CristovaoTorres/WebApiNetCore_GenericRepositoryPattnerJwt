using System;
using System.Collections.Generic;
using System.Text;
using VcmSuite3x.Application.Service;
using VcmSuite3x.Application.Util;
using static VcmSuite3x.Application.Util.Enum;

namespace VcmSuite3x.Application.Interface
{
    public interface IEntradaSimbolo
    {
        EntradaSimbolo GetSimbolo(int scenarioId, string codigo, EEntryBySymbolType entryBySymbolType);
    }
}
