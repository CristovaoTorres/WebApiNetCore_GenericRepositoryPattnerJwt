using System;
using System.Collections.Generic;
using System.Text;
using VcmSuite3x_api.Core.Models;

namespace VcmSuite3x.Application.Interface
{
    public interface ISimboloService
    {
        List<Simbolo> GetSimbolsByCodeList(List<string> codeList);
        Simbolo Find(string nome);
        Simbolo Find(int ind);
    }
}
