using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VcmSuite3x_api.Core.Models;
using VcmSuite3x_api.Core.Repository;
using VcmSuite3x_api.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using VcmSuite3x_api.Extensions;

namespace VcmSuite3x_api.Controllers
{

    [Route("api/[controller]/")/*, Authorize*/]
    public class UnidadeMedidaController : Controller
    {


        private readonly IMapper _mapper;
        private readonly UnitOfWork unitOfw = new UnitOfWork();

        public UnidadeMedidaController(IMapper mapper)
        {
            _mapper = mapper;
        }


        #region Save
        [Route("Save")]
        [HttpPost]
        public IActionResult Post([FromBody]RequestUnidadeMedidaSave unidadeMedida)
        {
            try
            {
                if (!ModelState.IsValid)
                    return new BadRequestObjectResult(ModelState.GenerateValidation());


                if (unitOfw.TipoUnidadeRepository.Count(y => y.Id == unidadeMedida.TipoUnidadeId) == 0)
                {
                    BaseViewModel<string> notFound = new BaseViewModel<string>("Tipo Unidade Not Found!");
                    return NotFound(notFound);
                }

                if (unitOfw.UnidadeMedidaRepository.Count(y => y.Nome == unidadeMedida.Nome && y.Id != unidadeMedida.Id) > 0)
                {
                    BaseViewModel<string> already = new BaseViewModel<string>("Nome Already!");
                    return BadRequest(already);
                }

                UnidadeMedida tobeSave = _mapper.Map<UnidadeMedida>(unidadeMedida);

                if (!unidadeMedida.Id.HasValue || unidadeMedida.Id == 0)
                    unitOfw.UnidadeMedidaRepository.Insert(tobeSave);

                else
                {
                    if (unitOfw.UnidadeMedidaRepository.Count(y => y.Id == unidadeMedida.Id) == 0)
                        return NotFound();

                    unitOfw.UnidadeMedidaRepository.Update(tobeSave);
                }
                unidadeMedida.Id = tobeSave.Id;


                BaseViewModel<RequestUnidadeMedidaSave> baseObj = new BaseViewModel<RequestUnidadeMedidaSave>(unidadeMedida, "Tipo Unidade Saved Successfully!", "");
                return Ok(baseObj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        #endregion

        #region List
        [Route("List/{TipoUnidadeId}"), HttpGet]
        public IActionResult List(int TipoUnidadeId)
        {
            try
            {

                if (unitOfw.TipoUnidadeRepository.Count(y => y.Id == TipoUnidadeId) == 0)
                {
                    BaseViewModel<string> notFound = new BaseViewModel<string>("Tipo Unidade Not Found!");
                    return NotFound(notFound);
                }


                List<UnidadeMedida> model = unitOfw.UnidadeMedidaRepository.GetAll(y => y.TipoUnidadeId == TipoUnidadeId).ToList();

                BaseViewModel<List<UnidadeMedida>> baseObj = new BaseViewModel<List<UnidadeMedida>>(model, "Unidade Medida Retrieved Successfully!", "");
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

        #region Detalhes
        [Route("Detail/{id}"), HttpGet]
        public IActionResult Get(int id)
        {
            try
            {
                UnidadeMedida unidadeMedida = unitOfw.UnidadeMedidaRepository.Get(y => y.Id == id).FirstOrDefault();

                if (unidadeMedida == null)
                {
                    BaseViewModel<string> notFound = new BaseViewModel<string>("Unidade Medida Not Found!");
                    return NotFound(notFound);
                }

                BaseViewModel<UnidadeMedidaResponse> baseObj = new BaseViewModel<UnidadeMedidaResponse>(_mapper.Map<UnidadeMedidaResponse>(unidadeMedida), "Topologia Retrieved Successfully!", "");
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
                UnidadeMedida unidadeMedida = unitOfw.UnidadeMedidaRepository.Get(y => y.Id == id).FirstOrDefault();

                if (unidadeMedida == null)
                {
                    BaseViewModel<string> notFound = new BaseViewModel<string>("Unidade Medida Not Found!");
                    return NotFound(notFound);
                }

                unitOfw.UnidadeMedidaRepository.Delete(unidadeMedida);

                BaseViewModel<string> baseObj = new BaseViewModel<string>("Unidade Medida Deleted Successfully!");
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