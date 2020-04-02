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
    public class TipoUnidadeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfw;

        public TipoUnidadeController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfw = unitOfWork;
        }

        #region Tipo Save
        [Route("Save")]
        [HttpPost]
        public IActionResult Post([FromBody]RequestTipoUnidadeSave model)
        {
            try
            {

                if (!ModelState.IsValid)
                    return new BadRequestObjectResult(ModelState.GenerateValidation());


                if (_unitOfw.TipoUnidadeRepository.Count(y => y.Nome == model.Nome && y.Id != model.Id) > 0)
                {
                    BaseViewModel<string> already = new BaseViewModel<string>("Nome Already!");
                    return BadRequest(already);
                }

                TipoUnidade tobeSave = _mapper.Map<TipoUnidade>(model);

                if (!model.Id.HasValue || model.Id == 0)
                {
                    _unitOfw.TipoUnidadeRepository.Insert(tobeSave);
                    model.Id = tobeSave.Id;
                }
                else
                {
                    if (_unitOfw.TipoUnidadeRepository.Count(y => y.Id == model.Id) == 0)
                    {
                        BaseViewModel<string> notFound = new BaseViewModel<string>("Produto Not Found!");
                        return NotFound(notFound);
                    }

                    _unitOfw.TipoUnidadeRepository.Update(tobeSave);
                }

                BaseViewModel<RequestTipoUnidadeSave> baseObj = new BaseViewModel<RequestTipoUnidadeSave>(model, "Tipo Unidade Saved Successfully!", "");
                return Ok(baseObj);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Tipo Unidade Delete
        [Route("Delete/{id}"), HttpDelete]
        public IActionResult Delete(int id)
        {

            try
            {

                TipoUnidade tipoUnidade = _unitOfw.TipoUnidadeRepository.GetWithIncludeAll(y => y.Id == id);


                if (tipoUnidade == null)
                {
                    BaseViewModel<string> notFound = new BaseViewModel<string>("Tipo Unidade Not Found!");
                    return NotFound(notFound);
                }

                _unitOfw.TipoUnidadeRepository.Delete(tipoUnidade);


                BaseViewModel<string> baseObj = new BaseViewModel<string>("Tipo Unidade Deleted Successfully!");
                return Ok(baseObj);
            }
            catch (Exception ex)
            {
                BaseViewModel<string> baseObj = new BaseViewModel<string>("Não é possivel excluir, existem dependencias no Projeto");
                return BadRequest(baseObj); ;
            }
        }
        #endregion

        #region List
        [Route("List"), HttpGet]
        public IActionResult List()
        {
            try
            {
                List<TipoUnidade> model = _unitOfw.TipoUnidadeRepository.GetAll().ToList();

                List<ResponseTipoUnidadeList> retorno = _mapper.Map<List<ResponseTipoUnidadeList>>(model);

                BaseViewModel<List<ResponseTipoUnidadeList>> baseObj = new BaseViewModel<List<ResponseTipoUnidadeList>>(retorno, "Tipo Unidade Retrieved Successfully!", "");
                return Ok(baseObj);
            }
            catch (Exception ex)
            {
                Guid guid = Guid.NewGuid();
                BaseViewModel<string> baseObj = new BaseViewModel<string>(ex, guid, "");
                return BadRequest(baseObj);
                throw;
            }


        }
        #endregion

        #region Detalhes
        [Route("Detail/{id}"), HttpGet]
        public IActionResult Get(int id)
        {
            try
            {
                TipoUnidade tipoUnidade = _unitOfw.TipoUnidadeRepository.GetQuery(y => y.Id == id, "UnidadeMedida");

                if (tipoUnidade == null)
                {
                    BaseViewModel<string> notFound = new BaseViewModel<string>("Tipo Unidade Not Found!");
                    return NotFound(notFound);
                }


                TipoUnidadeResponse retorno = _mapper.Map<TipoUnidadeResponse>(tipoUnidade);
                BaseViewModel<TipoUnidadeResponse> baseObj = new BaseViewModel<TipoUnidadeResponse>(retorno, "Topologia Retrieved Successfully!", "");
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