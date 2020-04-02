using System;
using System.Collections.Generic;
using System.Text;

namespace VcmSuite3x.Application.Interface
{
    public interface ICorrenteDrawingAppService
    {
        int Register(out string code, int portaEntradaIndex, int portaEntradaId, int portaSaidaIndex, int portaSaidaId, int fluxogramaId);
        bool Delete(int correnteId);
    }
}
