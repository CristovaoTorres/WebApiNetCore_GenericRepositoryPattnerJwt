using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VcmSuite3x.Application.ViewModel;
using VcmSuite3x_api.Core.Interface;
using VcmSuite3x_api.Core.Models;
using VcmSuite3x_api.Core.Repository;
using VcmSuite3x_api.Models;

namespace VcmSuite3x_api.Controllers
{
    [Route("api/")/*, Authorize*/]
    public class CenarioController : Controller
    {

        #region Properties
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CenarioController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        #endregion

        [Route("Projetos/{idProjeto}/Topologias/{idTopologia}/[controller]"), HttpPost]
        public IActionResult Post([FromBody]CenarioViewModel cenarioSave)
        {
            try
            {
                if (_unitOfWork.TopologiaRepository.Count(y => y.Id == cenarioSave.TopologiaId) == 0)
                {
                    BaseViewModel<string> notFound = new BaseViewModel<string>("Topologia Not Found!");
                    return Ok(notFound);
                }

                if (_unitOfWork.CenarioRepository.Count(y => y.Nome == cenarioSave.Nome && y.Id != cenarioSave.Id && y.TopologiaId != cenarioSave.TopologiaId) > 0)
                {
                    BaseViewModel<string> already = new BaseViewModel<string>("Nome já existe!");
                    return Ok(already);
                }



                Cenario tobeSave = _mapper.Map<Cenario>(cenarioSave);

                //Alterar Cenario
                if (cenarioSave.Id == 0)
                    _unitOfWork.CenarioRepository.Insert(tobeSave);

                //Novo Cenario
                else
                {
                    if (_unitOfWork.CenarioRepository.Count(y => y.Id == cenarioSave.Id) == 0)
                        return Ok();

                    _unitOfWork.CenarioRepository.Update(tobeSave);
                }
                cenarioSave.Id = tobeSave.Id;

                BaseViewModel<CenarioViewModel> baseObj = new BaseViewModel<CenarioViewModel>(cenarioSave, "Cenario Saved Successfully!", "");
                return Ok(baseObj);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [Route("Projetos/{idProjeto}/Topologias/{idTopologia}/[controller]/{id}"), HttpDelete]
        public IActionResult Delete(int idTopologia, int id)
        {
            try
            {
                Cenario cenario = _unitOfWork.CenarioRepository.Get(y => y.Id == id && y.TopologiaId == idTopologia).FirstOrDefault();

                if (cenario == null)
                {
                    BaseViewModel<string> notFound = new BaseViewModel<string>("Cenario Not Found!");
                    return Ok(notFound);
                }

                _unitOfWork.CenarioRepository.Delete(cenario);

                BaseViewModel<string> baseObj = new BaseViewModel<string>("Cenario Deleted Successfully!");
                return Ok(baseObj);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [Route("Projetos/{idProjeto}/Topologias/{idTopologia}/[controller]/{id}"), HttpGet]
        public IActionResult Get(int idProjeto, int idTopologia, int id)
        {
            try
            {
                Cenario cenario = _unitOfWork.CenarioRepository.Get(y => y.Id == id && y.TopologiaId == idTopologia && y.Topologia.ProjetoId == idProjeto).FirstOrDefault();

                if (cenario == null)
                {
                    BaseViewModel<string> notFound = new BaseViewModel<string>("Cenario Not Found!");
                    return Ok(notFound);
                }

                BaseViewModel<CenarioViewModel> baseObj = new BaseViewModel<CenarioViewModel>(_mapper.Map<CenarioViewModel>(cenario), "Cenario Retrieved Successfully!", "");
                return Ok(baseObj);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [Route("Projetos/{idProjeto}/Topologias/{idTopologia}/[controller]/"), HttpGet]
        public IActionResult List(int idProjeto, int idTopologia)
        {
            try
            {
                List<Cenario> cenario = _unitOfWork.CenarioRepository.Get(y => y.TopologiaId == idTopologia && y.Topologia.ProjetoId == idProjeto).ToList();

                if (cenario == null)
                {
                    BaseViewModel<string> notFound = new BaseViewModel<string>("Topologia Not Found!");
                    return Ok(notFound);
                }
                BaseViewModel<List<CenarioViewModel>> baseObj = new BaseViewModel<List<CenarioViewModel>>(_mapper.Map<List<CenarioViewModel>>(cenario), "Cenario Retrieved Successfully!", "");
                return Ok(baseObj);
            }
            catch (Exception ex)
            {

                throw;
            }


        }


    }
}