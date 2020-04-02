using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VcmSuite3x.Application.Interface;
using VcmSuite3x_api.Business;
using VcmSuite3x_api.Core.Models;
using VcmSuite3x_api.Extensions;
using VcmSuite3x_api.Models;

namespace VcmSuite3x_api.Controllers
{
    [Route("api/[controller]/")/*, Authorize*/]
    public class NoDrawingController : Controller
    {
        private readonly INoDrawingAppService _noDrawingBO;


        public NoDrawingController(INoDrawingAppService noDrawingBO)
        {
            _noDrawingBO = noDrawingBO;
        }

        #region Add
        [HttpPost, Route("Save")]
        public IActionResult Post([FromBody]RequestNoDrawing model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return new BadRequestObjectResult(ModelState.GenerateValidation());

                if (model.Key <= 0)
                {
                    int noId = 0;
                    string codigo = string.Empty;

                    // Legado sempre passando Conector = false;
                    _noDrawingBO.Insert(4, model.FluxogramaId, ref noId, ref codigo, model.Categoria, false, model.CoordenadaX, model.CoordenadaY);

                    model.Key = noId;
                    model.Code = codigo;

                    BaseViewModel<RequestNoDrawing> baseObj = new BaseViewModel<RequestNoDrawing>(model, "No Drawing Saved Successfully!", "");
                    return Ok(baseObj);

                }
                else
                {
                    _noDrawingBO.Update(model.FluxogramaId, model.Key, model.CoordenadaX, model.CoordenadaY);

                    BaseViewModel<RequestNoDrawing> baseObj = new BaseViewModel<RequestNoDrawing>(model, "No Drawing Updated Successfully!", "");
                    return Ok(baseObj);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }


        }
        #endregion


    }
}