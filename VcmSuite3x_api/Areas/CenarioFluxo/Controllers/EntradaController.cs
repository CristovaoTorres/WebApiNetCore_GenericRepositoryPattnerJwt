using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VcmSuite3x.Application.Interface;
using VcmSuite3x_api.Models;

namespace VcmSuite3x_api.Areas.CenarioFluxo.Controllers
{
    [Route("api/[controller]/")/*, Authorize*/]
    public class EntradaController : Controller
    {
        private readonly IEntradaAppService _entrada;

        public EntradaController(IEntradaAppService entradaAppService)
        {
            _entrada = entradaAppService;
        }
        [HttpPost]
        public IActionResult Post(string data, string no)
        {
            _entrada.Update(data, no);

            BaseViewModel<RequestCenarioSave> baseObj = new BaseViewModel<RequestCenarioSave>(new RequestCenarioSave(), "Cenario Saved Successfully!", "");
            return Ok(baseObj);
        }
    }
}