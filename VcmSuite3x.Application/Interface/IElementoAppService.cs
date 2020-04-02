using System;
using System.Collections.Generic;
using System.Text;

namespace VcmSuite3x.Application.Interface
{
    public interface IElementoAppService
    {
        object Get(int elementoId, int cenarioId, string tipoElemento);
    }
}
