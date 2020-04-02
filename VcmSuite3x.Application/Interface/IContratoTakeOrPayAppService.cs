using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VcmSuite3x.Application.Interface
{
    public interface IContratoTakeOrPayAppService
    {
        string FindNewCodebyId(int tipoEntidade, int topologiaId);

    }
}
