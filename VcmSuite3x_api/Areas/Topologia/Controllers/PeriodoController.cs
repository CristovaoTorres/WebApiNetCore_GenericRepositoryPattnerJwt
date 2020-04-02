using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VcmSuite3x.Application.Interface;
using VcmSuite3x.Application.ViewModel;
using VcmSuite3x_api.Core.Interface;
using VcmSuite3x_api.Core.Models;
using VcmSuite3x_api.Extensions;
using VcmSuite3x_api.Models;

namespace VcmSuite3x_api.Areas.Topologia.Controllers
{
    [Route("api/[controller]/")/*, Authorize*/]
    public class PeriodoController : Controller
    {


        #region Properties

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfw;
        private readonly IPeriodoAppService _periodoBO;
        public PeriodoController(IUnitOfWork unitOfWork, IPeriodoAppService periodoBO, IMapper mapper)
        {
            _unitOfw = unitOfWork;
            _periodoBO = periodoBO;
            _mapper = mapper;
        }

        #endregion

        #region Save
        [Route("Save"), HttpPost]
        public IActionResult Post([FromBody]RequestPeriodoSave model)
        {
            try
            {

                if (!ModelState.IsValid)
                    return new BadRequestObjectResult(ModelState.GenerateValidation());

                if (!model.Id.HasValue || model.Id == 0)
                {
                    List<Periodo> periodoList = _periodoBO.InsertMultiplePeriodos(model.Quantidade, model.Descricao, model.TopologiaId);


                    List<PeriodoViewModel> retorno = _mapper.Map<List<PeriodoViewModel>>(periodoList);

                    BaseViewModel<List<PeriodoViewModel>> baseObj = new BaseViewModel<List<PeriodoViewModel>>(retorno, "Periodo Saved Successfully!", "");

                    return Ok(baseObj);
                }
                else
                {
                    if (_unitOfw.PeriodoRepository.Count(y => y.Id == model.Id) == 0)
                    {
                        BaseViewModel<string> notFound = new BaseViewModel<string>("Periodo Not Found!", false);
                        return NotFound(notFound);
                    }

                    if (_unitOfw.PeriodoRepository.Count(y => y.Codigo == model.Codigo && y.TopologiaId == model.TopologiaId && y.Id != model.Id) > 0)
                    {
                        BaseViewModel<string> already = new BaseViewModel<string>("Código Already!", false);
                        return BadRequest(already);
                    }

                    Periodo tobeSave = _unitOfw.PeriodoRepository.Get(y => y.Id == model.Id).FirstOrDefault();
                    tobeSave.Codigo = model.Codigo;
                    tobeSave.Descricao = model.Descricao;

                    bool retorno = _unitOfw.ValoresUpdate((int)model.Id, model.TopologiaId, model.Codigo, tobeSave.TipoEntidadeId);

                    if (retorno)
                        _unitOfw.PeriodoRepository.Update(tobeSave);

                    PeriodoViewModel saved = _mapper.Map<PeriodoViewModel>(tobeSave);

                    BaseViewModel<PeriodoViewModel> baseObj = new BaseViewModel<PeriodoViewModel>(saved, "Periodo Saved Successfully!", "");
                    return Ok(baseObj);
                }

            }
            catch (Exception ex)
            {
                BaseViewModel<Exception> msg = new BaseViewModel<Exception>(ex, null, "");
                return BadRequest(msg);
            }
        }
        #endregion

        #region Get
        [Route("Detail/{id}"), HttpGet]
        public IActionResult Get(int id)
        {
            try
            {
                PeriodoViewModel retorno = _mapper.Map<PeriodoViewModel>(_unitOfw.PeriodoRepository.Get(y => y.Id == id).FirstOrDefault());

                if (retorno == null)
                {
                    BaseViewModel<string> notFound = new BaseViewModel<string>("Periodo Not Found!");
                    return NotFound(notFound);
                }

                BaseViewModel<PeriodoViewModel> baseObj = new BaseViewModel<PeriodoViewModel>(retorno, "Periodo Retrieved Successfully!", "");
                return Ok(baseObj);

            }
            catch (Exception ex)
            {
                throw;
            }

        }
        #endregion

        #region List
        [Route("List/{topologiaId}"), HttpGet]
        public IActionResult List(int topologiaId)
        {
            try
            {
                List<PeriodoViewModel> retorno = _mapper.Map<List<PeriodoViewModel>>(_unitOfw.PeriodoRepository.Get(y => y.TopologiaId == topologiaId).ToList());


                BaseViewModel<List<PeriodoViewModel>> baseObj = new BaseViewModel<List<PeriodoViewModel>>(retorno, "Periodo Retrieved Successfully!", "");
                return Ok(baseObj);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region Delete
        [Route("Delete/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                Periodo periodo = _unitOfw.PeriodoRepository.Get(y => y.Id == id).FirstOrDefault();

                if (periodo == null)
                {
                    BaseViewModel<string> notFound = new BaseViewModel<string>("Periodo Not Found!");
                    return NotFound(notFound);
                }

                _periodoBO.Delete(id);

                BaseViewModel<string> baseObj = new BaseViewModel<string>("Periodo Deleted Successfully!");
                return Ok(baseObj);
            }
            catch (Exception ex)
            {
                throw;
            }


        }
        #endregion


    }
}