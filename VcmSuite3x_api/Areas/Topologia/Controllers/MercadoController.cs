using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VcmSuite3x.Application.Interface;
using VcmSuite3x.Application.ViewModel;
using VcmSuite3x_api.Core.Interface;
using modelApi = VcmSuite3x_api.Models;

namespace VcmSuite3x_api.Areas.Topologia.Controllers
{
    [Route("api/[controller]/")/*, Authorize*/]
    public class MercadoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly INoAppService _noApp;
        private readonly IMercadoAppService _mercadoApp;
        private readonly IUnitOfWork _unitOfw;

        public MercadoController(IMapper mapper, INoAppService appService, IMercadoAppService mercadoApp, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _noApp = appService;
            _unitOfw = unitOfWork;
            _mercadoApp = mercadoApp;
        }


        #region Get
        [HttpGet("Get")]
        public IActionResult Get(int noId, int topologiaId)
        {
            try
            {
                modelApi.BaseViewModel<MercadoViewModel> baseObj = new modelApi.BaseViewModel<MercadoViewModel>(_mercadoApp.Find(topologiaId, noId, _mapper), "No Retrieved Successfully!", "");
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