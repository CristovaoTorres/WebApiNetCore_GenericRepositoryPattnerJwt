using System;
using System.Collections.Generic;
using System.Text;
using VcmSuite3x.Application.ViewModel;
using VcmSuite3x_api.Core.Models;

namespace VcmSuite3x.Application.Interface
{
    public interface IProjetoAppService
    {
        ProjetoViewModel Register(ProjetoViewModel model);
        Projeto Update(ProjetoViewModel model);
        List<string> Validate(List<int> ListUnidadeMedidaId);
        object List();
        void Delete(Projeto model);
        ProjetoViewModel Get(int idProjeto);

    }
}
