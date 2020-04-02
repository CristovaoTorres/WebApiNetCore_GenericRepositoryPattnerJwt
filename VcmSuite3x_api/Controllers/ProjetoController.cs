using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VcmSuite3x.Application.Interface;
using VcmSuite3x.Application.ViewModel;
using VcmSuite3x_api.Business;
using VcmSuite3x_api.Core.Models;
using VcmSuite3x_api.Core.Repository;
using VcmSuite3x_api.Extensions;
using VcmSuite3x_api.Models;

namespace VcmSuite3x_api.Controllers
{
    [Route("api/[controller]/")/*, Authorize*/]
    public class ProjetoController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IProjetoAppService _projetoService;
        private readonly UnitOfWork unitOfw = new UnitOfWork();
        public ProjetoController(IMapper mapper, IProjetoAppService projeto)
        {
            _mapper = mapper;
            _projetoService = projeto;

        }

        #region List
        [HttpGet]
        public IActionResult List()
        {
            try
            {
                var projetos = _projetoService.List();

                BaseViewModel<object> baseObj = new BaseViewModel<object>(projetos, "Projeto Retrieved Successfully!", "");
                return Ok(baseObj);
            }
            catch (Exception ex)
            {

                Guid guid = Guid.NewGuid();
                return BadRequest();
                throw;
            }


        }
        #endregion

        #region Save
        [HttpPost]
        public IActionResult Post([FromBody]ProjetoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return new BadRequestObjectResult(ModelState.GenerateValidation());

                #region Validacoes

                if (unitOfw.CadeiaRepository.Count(y => y.Id == model.CadeiaId) == 0)
                {
                    BaseViewModel<string> notFound = new BaseViewModel<string>("Cadeia Not Found!");
                    return NotFound(notFound);
                }
                var erros = _projetoService.Validate(model.UnidadeMedidaId);
                if (erros.Count > 0)
                    return Ok(erros);

                #endregion

                var projeto = _projetoService.Register(model);

                BaseViewModel<ProjetoViewModel> baseObj = new BaseViewModel<ProjetoViewModel>(projeto, "Projeto Saved Successfully!", "");
                return Ok(baseObj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }



        [HttpPut]
        public IActionResult Put([FromBody]ProjetoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return new BadRequestObjectResult(ModelState.GenerateValidation());


                if (unitOfw.CadeiaRepository.Count(y => y.Id == model.CadeiaId) == 0)
                {
                    BaseViewModel<string> notFound = new BaseViewModel<string>("Cadeia Not Found!");
                    return Ok(notFound);
                }
                var erros = _projetoService.Validate(model.UnidadeMedidaId);
                if (erros.Count > 0)
                    return Ok(erros);


                var projeto = _projetoService.Update(model);

                if (projeto == null)
                    return Ok("Projeto not found!");
                //var projeto = unitOfw.ProjetoRepository.Update(model);

                BaseViewModel<object> baseObj = new BaseViewModel<object>(projeto, "Projeto Saved Successfully!", "");
                return Ok(baseObj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }


        #endregion

        #region Delete
        [Route("{id}"), HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                Projeto projeto = unitOfw.ProjetoRepository.GetWithIncludeAll(y => y.Id == id);

                if (projeto == null)
                {
                    BaseViewModel<string> notFound = new BaseViewModel<string>("Projeto Not Found!");
                    return Ok(notFound);
                }
                unitOfw.ProjetoRepository.Delete(projeto);

                BaseViewModel<string> baseObj = new BaseViewModel<string>("Projeto Deleted Successfully!");
                return Ok(baseObj);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region Get
        [Route("{id}"), HttpGet]
        public IActionResult Get(int id)
        {
            try
            {
                ProjetoViewModel model = _projetoService.Get(id);

                if (model == null)
                {
                    BaseViewModel<string> notFound = new BaseViewModel<string>("Projeto Not Found!");
                    return Ok(notFound);
                }

                BaseViewModel<ProjetoViewModel> baseObj = new BaseViewModel<ProjetoViewModel>(model, "Projeto Retrieved Successfully!", "");
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