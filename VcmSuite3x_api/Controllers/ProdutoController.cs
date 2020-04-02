using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VcmSuite3x.Application.Interface;
using VcmSuite3x_api.Core.Interface;
using VcmSuite3x_api.Core.Models;
using VcmSuite3x_api.Extensions;
using VcmSuite3x_api.Models;
using static VcmSuite3x_api.Extensions.ExtensionsMethod;

namespace VcmSuite3x_api.Controllers
{
    [Route("api/[controller]")/*, Authorize*/]
    public class ProdutoController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfw;
        private readonly IProdutoAppService _produto;


        public ProdutoController(IMapper mapper, IUnitOfWork unitOfw, IProdutoAppService produtoAppService)
        {
            _mapper = mapper;
            _unitOfw = unitOfw;
            _produto = produtoAppService;



        }

        #region Save
        [Route("Save")]
        [HttpPost]
        public IActionResult Post([FromBody]RequestProdutoSave model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return new BadRequestObjectResult(ModelState.GenerateValidation());

                //TODO: fazer de um jeito mais generico a validação das FK
                if (_unitOfw.TopologiaRepository.Count(y => y.Id == model.TopologiaId) == 0)
                {
                    BaseViewModel<string> notFound = new BaseViewModel<string>("Topologia Not Found!");
                    return NotFound(notFound);
                }

                if (_unitOfw.UnidadeMedidaRepository.Count(y => y.Id == model.UnidadeMedidaId) == 0)
                {
                    BaseViewModel<string> notFound = new BaseViewModel<string>("Unidade de Medida Not Found!");
                    return NotFound(notFound);
                }

                if (_unitOfw.ProdutoRepository.Count(y => y.Descricao == model.Descricao && y.Id != model.Id) > 0)
                {
                    BaseViewModel<string> already = new BaseViewModel<string>("Nome Already!");
                    return BadRequest(already);
                }

                //Produto tobeSave = _mapper.Map<Produto>(model);

                if (!model.Id.HasValue || model.Id == 0)
                {
                   var produtoSave =  _produto.Save(model.Id, model.Codigo, model.Descricao, model.UnidadeMedidaId, model.TopologiaId, model.TipoEntidadeId);
                    //_unitOfw.ProdutoRepository.Insert(tobeSave);
                    model.Id = produtoSave.Id;
                }
                else
                {

                    if (_unitOfw.ProdutoRepository.Count(y => y.Id == model.Id) == 0)
                    {
                        BaseViewModel<string> notFound = new BaseViewModel<string>("Produto Not Found!");
                        return NotFound(notFound);
                    }
                    var produtoSave = _produto.Save(model.Id, model.Codigo, model.Descricao, model.UnidadeMedidaId, model.TopologiaId, model.TipoEntidadeId);
                }

                BaseViewModel<RequestProdutoSave> baseObj = new BaseViewModel<RequestProdutoSave>(model, "Produto Saved Successfully!", "");
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
                List<Produto> produtoList = _unitOfw.ProdutoRepository.Get(y => y.TopologiaId == topologiaId).ToList();

                BaseViewModel<List<Produto>> baseObj = new BaseViewModel<List<Produto>>(produtoList, "Produto Retrieved Successfully!", "");
                return Ok(baseObj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
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
                Produto produto = _unitOfw.ProdutoRepository.Get(y => y.Id == id).FirstOrDefault();

                if (produto == null)
                {
                    BaseViewModel<string> notFound = new BaseViewModel<string>("Produto Not Found!");
                    return NotFound(notFound);
                }

                _unitOfw.ProdutoRepository.Delete(produto);

                BaseViewModel<string> baseObj = new BaseViewModel<string>("Produto Deleted Successfully!");
                return Ok(baseObj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }


        }
        #endregion

        #region UnidadesMedida
        [Route("UnidadesMedidaProduto/{tipoProdutoId}/{projetoId}"), HttpGet]
        public IActionResult UnidadesMedida(int tipoProdutoId, int projetoId)
        {
            try
            {

                int tipoUnidadeId = _unitOfw.TipoProdutoRepository.Get(y => y.Id == tipoProdutoId).FirstOrDefault().TipoUnidadeId;

                int idUnidadeDefault = _unitOfw.MedidaProjetoRepository.Get(y => y.ProjetoId == projetoId, null, "UnidadeMedida")
                                                                                .Where(y => y.UnidadeMedida.TipoUnidadeId == tipoUnidadeId)
                                                                                .Select(u => u.UnidadeMedida).FirstOrDefault().Id;

                List<ListSelectItems> listSelectItems = _unitOfw.UnidadeMedidaRepository.Get(y => y.TipoUnidadeId == tipoUnidadeId)
                                                                            .ToSelectList(p => p.Representacao, p => p.Id.ToString(),
                                                                            p => p.Id == idUnidadeDefault ? true : false).ToList();

                BaseViewModel<List<ListSelectItems>> baseObj = new BaseViewModel<List<ListSelectItems>>(listSelectItems);

                return Ok(baseObj);
            }
            catch (Exception ex)
            {
                BaseViewModel<string> notFound = new BaseViewModel<string>("Not Found!");
                return NotFound(notFound);
            }
        }
        #endregion

        #region List TiposProdutos
        [HttpGet, Route("TiposProduto/List/")]
        public IActionResult TipoProduto()
        {
            try
            {
                List<ListSelectItems> tipoProdutoList = _unitOfw.TipoProdutoRepository.Get().ToSelectList(p => p.Nome, p => p.TipoUnidadeId.ToString()).ToList();

                BaseViewModel<List<ListSelectItems>> baseObj = new BaseViewModel<List<ListSelectItems>>(tipoProdutoList);

                return Ok(baseObj);
            }
            catch (Exception ex)
            {
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
                Produto produto = _unitOfw.ProdutoRepository.Get(y => y.Id == id, null, "TipoEntidade,UnidadeMedida").FirstOrDefault();

                if (produto == null)
                {
                    BaseViewModel<string> notFound = new BaseViewModel<string>("Produto Not Found!");
                    return NotFound(notFound);
                }

                List<UnidadeMedida> unidadeMedidaList = _unitOfw.UnidadeMedidaRepository.Get(y => y.TipoUnidadeId == produto.UnidadeMedida.TipoUnidadeId).ToList();

                List<UnidadeMedidaHelper> unidadeMedidaHelpers = new List<UnidadeMedidaHelper>();
                ResponseProduto responseProduto = _mapper.Map<ResponseProduto>(produto);

                foreach (var oneUnidadeMedidaList in unidadeMedidaList)
                    unidadeMedidaHelpers.Add(new UnidadeMedidaHelper(oneUnidadeMedidaList.Id, responseProduto.UnidadeMedidaId, oneUnidadeMedidaList.Representacao));

                responseProduto.UnidadesMedida = unidadeMedidaHelpers;

                BaseViewModel<ResponseProduto> baseObj = new BaseViewModel<ResponseProduto>(responseProduto, "Produto Retrieved Successfully!", "");
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