using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using VcmSuite3x.Application.Interface;
using VcmSuite3x.Application.ViewModel;
using VcmSuite3x_api.Business;
using VcmSuite3x_api.Core.Interface;
using VcmSuite3x_api.Core.Models;
using VcmSuite3x_api.Core.Repository;
using VcmSuite3x_api.Models;

namespace VcmSuite3x_api.Controllers
{
    [Route("api/")/*, Authorize*/]
    public class TopologiaController : Controller
    {
        #region Properties
        private readonly IUnitOfWork _unitOfw;
        private readonly ITopologiaAppService _topologiaAppService;
        private readonly IMapper _mapper;

        public TopologiaController(IUnitOfWork unitOfw, ITopologiaAppService topologiaAppService, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfw = unitOfw;
            _topologiaAppService = topologiaAppService;
        }

        #endregion

        [Route("Projetos/{idProjeto}/[controller]"), HttpGet]
        public IActionResult List(int idProjeto)
        {
            try
            {

                //para Incluir as Propriedades basta passar Topologia;MedidaProjeto;etc
                List<Topologia> model = _unitOfw.TopologiaRepository.Get(y => y.ProjetoId == idProjeto).ToList();

                if (model == null)
                {
                    BaseViewModel<string> notFound = new BaseViewModel<string>("Projeto Not Found!");
                    return NotFound(notFound);
                }
                List<TopologiaViewModel> retorno = _mapper.Map<List<TopologiaViewModel>>(model);

                BaseViewModel<List<TopologiaViewModel>> baseObj = new BaseViewModel<List<TopologiaViewModel>>(retorno, "Topologia Retrieved Successfully!", "");
                return Ok(baseObj);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [Route("Projetos/{idProjeto}/[controller]"), HttpPost, HttpPut]
        public IActionResult Post([FromBody]TopologiaViewModel model, int idProjeto)
        {
            try
            {
                model.ProjetoId = idProjeto;

                if (_unitOfw.ProjetoRepository.Count(y => y.Id == idProjeto) == 0)
                {
                    BaseViewModel<string> notFound = new BaseViewModel<string>("Projeto Not Found!");
                    return Ok(notFound);
                }
                if (_unitOfw.TopologiaRepository.Count(y => y.Nome == model.Nome && y.Id != model.Id) > 0)
                {
                    BaseViewModel<string> already = new BaseViewModel<string>("Nome ja existe!");
                    return Ok(already);
                }
                if (model.Id > 0)
                    _topologiaAppService.Update(model);

                else
                    _topologiaAppService.Save(model);

                BaseViewModel<TopologiaViewModel> baseObj = new BaseViewModel<TopologiaViewModel>(model, "Topologia Saved Successfully!", "");
                return Ok(baseObj);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [Route("Projetos/{idProjeto}/[controller]/{id}"), HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                Topologia model = _unitOfw.TopologiaRepository.GetWithIncludeAll(y => y.Id == id);

                if (model == null)
                {
                    BaseViewModel<string> notFound = new BaseViewModel<string>("Topologia Not Found!");
                    return Ok(notFound);
                }

                _unitOfw.TopologiaRepository.Delete(model);

                BaseViewModel<string> baseObj = new BaseViewModel<string>("Topologia Deleted Successfully!");
                return Ok(baseObj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("Projetos/{idProjeto}/[controller]/{id}"), HttpGet]
        public IActionResult Get(int id)
        {
            try
            {
                var retorno = _topologiaAppService.Get(id);
                BaseViewModel<Topologia> baseObj = new BaseViewModel<Topologia>(retorno, "Topologia Retrieved Successfully!", "");
                return Ok(baseObj);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}