using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VcmSuite3x.Application.Interface;
using VcmSuite3x_api.Core.Interface;
using VcmSuite3x_api.Models;

namespace VcmSuite3x_api.Areas.Cenario.Controllers
{
    [Route("api/[controller]/")/*, Authorize*/]
    public class FluxogramaController : Controller
    {

        private readonly ICorrenteDrawingAppService _corrente;
        private readonly INoDrawingAppService _noDrawing;

        public FluxogramaController(ICorrenteDrawingAppService corrente, INoDrawingAppService noDrawing)
        {
            _corrente = corrente;
            _noDrawing = noDrawing;
        }


        #region Get
        [Route("Detail/{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            try
            {
                BaseViewModel<string> baseObj = new BaseViewModel<string>("FluxoGrama!");
                return Ok(baseObj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        #endregion



        #region Get
        [Route("Delete"), HttpDelete]
        public IActionResult Delete([FromBody]List<DiagramPartModel> model)
        {
            try
            {

                if (model == null)
                {
                    throw new ArgumentException("Não foi selecionado elementos para deleção.");
                }
                else
                {
                    if (model.Count == 1)
                    {
                        DiagramPartModel diagramPart = model[0];
                        if (diagramPart.Category.Equals(/*DiagramLinkModel.CorrenteCategory*/ "S", StringComparison.CurrentCultureIgnoreCase))
                            _corrente.Delete(diagramPart.Id);

                        else
                            _noDrawing.Delete(diagramPart.Id, diagramPart.DiagramId);
                    }
                    else if (model.Count > 1)
                    {
                        //Collection<NoDrawing> nodes = new Collection<NoDrawing>
                        //    (
                        //        diagramParts.Where(p => !String.IsNullOrWhiteSpace(p.Category))
                        //        .Select(node => new NoDrawing() { Id = node.Key, FluxogramaId = node.DiagramId }).ToList()
                        //    );
                        //if (nodes.Count > 0)
                        //{
                        //    var repository = new NoDrawingRepository();
                        //    repository.Delete(nodes);
                        //}
                        //else
                        //{
                        //    throw new ArgumentException("Seleção inválida de elementos para deleção.");
                        //}
                    }
                }
                BaseViewModel<string> baseObj = new BaseViewModel<string>("FluxoGrama Deleted Successfully!");
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