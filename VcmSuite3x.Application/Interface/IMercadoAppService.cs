using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VcmSuite3x.Application.ViewModel;
using VcmSuite3x_api.Core.Models;

namespace VcmSuite3x.Application.Interface
{
    public interface IMercadoAppService
    {
        MercadoViewModel Find(int topologiaId, int noId, IMapper _mapper);
        MercadoCenario MercadoCenarioFindByCodigo(string codigo, int cenarioId);
        MercadoCenario MercadoCenarioFind(int elementoId, int cenarioId);
    }
}
