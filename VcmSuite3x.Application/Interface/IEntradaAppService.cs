using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using VcmSuite3x.Application.Model;
using VcmSuite3x.Application.Service;
using VcmSuite3x_api.Core.Models;

namespace VcmSuite3x.Application.Interface
{
   public  interface IEntradaAppService
    {
         Boolean Validate(Collection<EntradaRequest> entradas);
        void Update(string data, string no);

        List<EntradaRequest> Select(int id, Collection<Simbolo> simbolos,string codigoRaiz, ConfiguracaoRequest configuracao);
    }
}
