using System;
using System.Collections.Generic;
using System.Text;
using VcmSuite3x.Application.ViewModel;
using VcmSuite3x_api.Core.Models;

namespace VcmSuite3x.Application.Interface
{
    public interface ITopologiaAppService
    {
        void Save(TopologiaViewModel topogia);
        void Update(TopologiaViewModel model);
        Topologia Get(int id);
    }
}
