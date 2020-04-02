using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VcmSuite3x.Application.Interface;
using VcmSuite3x_api.Business;
using VcmSuite3x_api.Core.Interface;
using VcmSuite3x_api.Core.Models;
using VcmSuite3x_api.Core.Repository;
using VcmSuite3x_api.Models;
using appViewModel = VcmSuite3x.Application.ViewModel;

namespace VcmSuite3x_api.Areas.Topologia.Controllers
{
    [Route("api/[controller]/")/*, Authorize*/]
    public class NoController : Controller
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly INoAppService _noApp;
        private readonly IUnitOfWork _unitOfw;

        public NoController(IMapper mapper, INoAppService bo, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _noApp = bo;
            _unitOfw = unitOfWork;
        }
        #endregion

        #region Get
        //[Route("Get")]
        [HttpGet]
        public IActionResult Get(int id, int topologiaId)
        {
            try
            {
                BaseViewModel<appViewModel.NoViewModel> baseObj = new BaseViewModel<appViewModel.NoViewModel>(_noApp.Create(id, topologiaId, _mapper), "No Retrieved Successfully!", "");
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