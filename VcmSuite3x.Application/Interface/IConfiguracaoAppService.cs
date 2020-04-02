using System;
using System.Collections.Generic;
using System.Text;
using VcmSuite3x.Application.Service;

namespace VcmSuite3x.Application.Interface
{
    public interface IConfiguracaoAppService
    {
        ConfiguracaoRequest Find();
    }
}
