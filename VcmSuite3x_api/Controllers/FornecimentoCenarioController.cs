using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VcmSuite3x_api.Core.Interface;
using VcmSuite3x_api.Core.Models;
using VcmSuite3x_api.Core.Repository;
using VcmSuite3x_api.Extensions;
using VcmSuite3x_api.Models;

namespace VcmSuite3x_api.Controllers
{
    [Route("api/[controller]/")/*, Authorize*/]
    public class FornecimentoCenarioController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfw;

        public FornecimentoCenarioController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfw = unitOfWork;
            _mapper = mapper;
        }

        #region Save
        [Route("Save")]
        [HttpPost]
        public IActionResult Post([FromBody]FornecimentoCenarioSave model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return new BadRequestObjectResult(ModelState.GenerateValidation());

                //TODO: fazer de um jeito mais generico a validação das FK
                if (_unitOfw.CenarioRepository.Count(p => p.Id == model.CenarioId) == 0)
                {
                    BaseViewModel<string> notFound = new BaseViewModel<string>("Cenario Not Found!");
                    return NotFound(notFound);
                }

                if (_unitOfw.NoRepository.Count(p => p.Id == model.NoId) == 0)
                {
                    BaseViewModel<string> notFound = new BaseViewModel<string>("No Not Found!");
                    return NotFound(notFound);
                }
                FornecimentoCenario tobeSave = _mapper.Map<FornecimentoCenario>(model);

                if (_unitOfw.FornecimentoCenarioRepository.Count(y => y.NoId == model.NoId && y.CenarioId == model.CenarioId) == 0)
                    _unitOfw.FornecimentoCenarioRepository.Insert(tobeSave);

                else
                    _unitOfw.FornecimentoCenarioRepository.Update(tobeSave);

                BaseViewModel<FornecimentoCenarioSave> baseObj = new BaseViewModel<FornecimentoCenarioSave>(model, "Fornecimento Cenario Saved Successfully!", "");
                return Ok(baseObj);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Get
        [Route("Detail/{cenarioId}/{noId}"), HttpGet]
        public IActionResult Get(int cenarioId, int noId)
        {
            try
            {

                FornecimentoCenarioSave retorno = _mapper.Map<FornecimentoCenarioSave>(_unitOfw.FornecimentoCenarioRepository.Get(y => y.NoId == noId &&
                                                                                                                                  y.CenarioId == cenarioId).FirstOrDefault());
                if (retorno == null)
                {
                    BaseViewModel<string> notFound = new BaseViewModel<string>("Fornecimento Cenario Not Found!");
                    return NotFound(notFound);
                }

                BaseViewModel<FornecimentoCenarioSave> baseObj = new BaseViewModel<FornecimentoCenarioSave>(retorno, "Fornecimento Cenario Retrieved Successfully!", "");
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