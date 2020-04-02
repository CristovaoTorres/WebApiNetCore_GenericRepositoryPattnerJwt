using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using VcmSuite3x.Application.Model;
using VcmSuite3x.Application.Service;
using VcmSuite3x.Application.Util;

namespace VcmSuite3x.Application.Interface
{
    public interface ICenarioFluxoAppService
    {
        void Post(string model);
        EntradaSimbolo EntradaSimbolo(int cenarioId, string codigo, EEntryBySymbolType type);
        void SaveEntrada(List<EntradaRequest> entradas);
    }
}
