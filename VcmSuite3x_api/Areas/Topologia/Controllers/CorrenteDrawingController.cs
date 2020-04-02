using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VcmSuite3x.Application.Interface;
using VcmSuite3x_api.Business;
using VcmSuite3x_api.Core;
using VcmSuite3x_api.Core.Interface;
using VcmSuite3x_api.Core.Models;
using VcmSuite3x_api.Core.Repository;
using VcmSuite3x_api.Models;

namespace VcmSuite3x_api.Controllers
{
    [Route("api/[controller]/")/*, Authorize*/]
    public class CorrenteDrawingController : Controller
    {
        private readonly ICorrenteDrawingAppService _correnteDrawingAppService;

        public CorrenteDrawingController(ICorrenteDrawingAppService correnteDrawingAppService)
        {
            _correnteDrawingAppService = correnteDrawingAppService;
        }

        [HttpPost]
        public IActionResult Post([FromBody]DiagramLinkModel model)
        {
            try
            {
                if (Enum.TryParse<PortSpot>(model.FromPort, true, out PortSpot portaEntradaSpot) && Enum.TryParse<PortSpot>(model.ToPort, true, out PortSpot portaSaidaSpot))
                {
                    model.Id = _correnteDrawingAppService.Register(out string code, (Int32)portaEntradaSpot, model.From,
                                                         (Int32)portaSaidaSpot, model.To, model.DiagramId);

                    model.Code = code;
                    //model.Color = Common.ModalColor.Silver.ToString();

                    BaseViewModel<DiagramLinkModel> baseObj = new BaseViewModel<DiagramLinkModel>(model, "Corrente Saved Successfully!", "");
                    return Ok(baseObj);
                }
                else
                {
                    BaseViewModel<DiagramLinkModel> baseObj = new BaseViewModel<DiagramLinkModel>(model, "Corrente Fail", "");
                    return Ok(baseObj);
                }
            }
            catch (Exception ex)
            {
                BaseViewModel<string> baseObj = new BaseViewModel<string>(ex.Message);
                return BadRequest(baseObj);
            }
        }
    }
}