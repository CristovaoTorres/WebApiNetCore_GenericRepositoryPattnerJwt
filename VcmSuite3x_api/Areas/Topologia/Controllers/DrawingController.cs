using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VcmSuite3x.Application.Interface;
using VcmSuite3x_api.Core.Interface;
using VcmSuite3x_api.Core.Models;
using VcmSuite3x_api.Models;
using static VcmSuite3x_api.Core.Repository.UnitOfWork;
using VcmSuite3x.Application.ViewModel;
using VcmSuite3x_api.Core;

namespace VcmSuite3x_api.Areas.Topologia.Controllers
{
    [Route("api/[controller]/")/*, Authorize*/]
    public class DrawingController : Controller
    {
        private readonly IDrawingAppService _drawingAppService;

        public DrawingController(IDrawingAppService drawingAppService)
        {
            _drawingAppService = drawingAppService;
        }

        #region Cenario
        [Route("Cenario/{idTopologia}/{fluxogramaId}"), HttpGet]
        public IActionResult Cenario(int idTopologia, int fluxogramaId)
        {
            try
            {
                var graphLinksModel = _drawingAppService.CreateFluxograma(fluxogramaId, idTopologia, FluxogramaTipo.Cenario);

                if (graphLinksModel.NodeDataArray.Count == 0)
                {
                    BaseViewModel<string> noResult = new BaseViewModel<string>("No results");
                    return Ok(noResult);
                }
                BaseViewModel<GraphLinksModel> baseObj = new BaseViewModel<GraphLinksModel>(graphLinksModel, "Drawing retrived Successfully!", "");
                return Ok(baseObj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        #endregion
        #region Cenario
        [Route("Topologia/{idTopologia}/{fluxogramaId}"), HttpGet]
        public IActionResult Topologia(int idTopologia, int fluxogramaId)
        {
            try
            {
                var graphLinksModel = _drawingAppService.CreateFluxograma(fluxogramaId, idTopologia, FluxogramaTipo.Cenario);

                if (graphLinksModel.NodeDataArray.Count == 0)
                {
                    BaseViewModel<string> noResult = new BaseViewModel<string>("No results");
                    return Ok(noResult);
                }

                BaseViewModel<GraphLinksModel> baseObj = new BaseViewModel<GraphLinksModel>(graphLinksModel, "Drawing retrived Successfully!", "");
                return Ok(baseObj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        #endregion
    }
}