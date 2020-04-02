using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VcmSuite3x_api.Core.Interface;
using VcmSuite3x_api.Core.Models;
using VcmSuite3x_api.Extensions;
using VcmSuite3x_api.Models;

namespace VcmSuite3x_api.Areas.Topologia.Controllers
{
    [Route("api/[controller]/")/*, Authorize*/]
    public class ContratoTakeOrPayController : Controller
    {

        private readonly IUnitOfWork _unitOfw;
        private readonly IMapper _mapper;

        public ContratoTakeOrPayController(IMapper mapper, IUnitOfWork unitOfw)
        {
            _unitOfw = unitOfw;
            _mapper = mapper;
        }

        #region Save
        [HttpPost, Route("Save")]
        public IActionResult Post([FromBody]RequestContratoTakeOrplay model)
        {
            try
            {

                if (!ModelState.IsValid)
                    return new BadRequestObjectResult(ModelState.GenerateValidation());

                if (_unitOfw.TopologiaRepository.Count(y => y.Id == model.TopologiaId) == 0)
                {
                    BaseViewModel<string> notFound = new BaseViewModel<string>("Topologia Not Found!");
                    return NotFound(notFound);
                }

                if (_unitOfw.TipoEntidadeRepository.Count(y => y.Id == model.TopologiaId) == 0)
                {
                    BaseViewModel<string> notFound = new BaseViewModel<string>("Tipo Entidade Not Found!");
                    return NotFound(notFound);
                }

                Contrato tobeSave = _mapper.Map<Contrato>(model);

                if (!model.Id.HasValue || model.Id == 0)
                {
                    tobeSave.Codigo = !string.IsNullOrEmpty(tobeSave.Codigo) ? tobeSave.Codigo : _unitOfw.Fn_find_NovoCodigoById(model.TipoEntidadeId, model.TopologiaId);
                    _unitOfw.ContratoRepository.Insert(tobeSave);
                    model.Id = tobeSave.Id;
                }

                else
                {
                    if (_unitOfw.ContratoRepository.Count(y => y.Id == model.Id) == 0)
                    {
                        BaseViewModel<string> already = new BaseViewModel<string>("Not Found!");
                        return NotFound(already);
                    }
                    _unitOfw.ContratoRepository.Update(tobeSave);
                }


                BaseViewModel<RequestContratoTakeOrplay> baseObj = new BaseViewModel<RequestContratoTakeOrplay>(model, "Contrato Take or Play Saved Successfully!", "");
                return Ok(baseObj);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Detail
        [Route("Detail/{id}"), HttpGet]
        public IActionResult Get(int id)
        {
            try
            {
                Contrato contrato = _unitOfw.ContratoRepository.Get(y => y.Id == id).FirstOrDefault();

                if (contrato == null)
                {
                    BaseViewModel<string> notFound = new BaseViewModel<string>("Contrato Not Found!");
                    return NotFound(notFound);
                }

                BaseViewModel<RequestContratoTakeOrplay> baseObj = new BaseViewModel<RequestContratoTakeOrplay>(_mapper.Map<RequestContratoTakeOrplay>(contrato), "Contrato Retrieved Successfully!", "");
                return Ok(baseObj);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region List
        [HttpGet, Route("List")]
        public IActionResult List(int topologiaId)
        {
            try
            {

                if (_unitOfw.TopologiaRepository.Count(y => y.Id == topologiaId) == 0)
                {
                    BaseViewModel<string> notFound = new BaseViewModel<string>("Topologia Not Found!");
                    return NotFound(notFound);
                }

                List<Contrato> contratoList = _unitOfw.ContratoRepository.Get(y => y.TopologiaId == topologiaId, null, "ProdutoContrato,TipoProduto").ToList();

                List<ResponseContrato> model = _mapper.Map<List<ResponseContrato>>(contratoList);

                //TODO: Trocar isso depois
                foreach (var oneContratoList in contratoList)
                {
                    if (oneContratoList.TipoProduto != null)
                        model.Where(y => y.Id == oneContratoList.Id).FirstOrDefault().TipoProdutoNome = oneContratoList.TipoProduto.Nome;
                }


                BaseViewModel<List<ResponseContrato>> baseObj = new BaseViewModel<List<ResponseContrato>>(model, "Contrato Take or Play  Successfully!", "");
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

                Contrato contrato = _unitOfw.ContratoRepository.Get(y => y.Id == id).FirstOrDefault();

                if (contrato == null)
                {
                    BaseViewModel<string> notFound = new BaseViewModel<string>("Contrato Not Found!");
                    return NotFound(notFound);
                }

                _unitOfw.ContratoRepository.Delete(contrato);

                BaseViewModel<string> baseObj = new BaseViewModel<string>("Contrato Take or Pay Deleted Successfully!");
                return Ok(baseObj);
            }
            catch (Exception ex)
            {
                BaseViewModel<Exception> baseObj = new BaseViewModel<Exception>(ex, false);
                return BadRequest(baseObj);
            }
        }
        #endregion


    }
}