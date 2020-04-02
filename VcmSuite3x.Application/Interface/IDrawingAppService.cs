using System;
using System.Collections.Generic;
using System.Text;
using VcmSuite3x.Application.Model;
using VcmSuite3x.Application.ViewModel;
using VcmSuite3x_api.Core;
using VcmSuite3x_api.Core.Models;
using static VcmSuite3x_api.Core.Repository.UnitOfWork;

namespace VcmSuite3x.Application.Interface
{
    public interface IDrawingAppService
    {
        List<string> Validate(FluxogramaTipo tipoFluxograma, int topologiaId);
        GraphLinksModel CreateFluxograma(int fluxogramaId, int topologia, FluxogramaTipo tipoFluxograma);
        List<Drawing> pr_VCM_NoDrawingSelect(Int32 fluxogramaId);
        List<DiagramaLinkModel> pr_VCM_CorrenteDrawingSelect(Int32 fluxogramaId);
    }
}
