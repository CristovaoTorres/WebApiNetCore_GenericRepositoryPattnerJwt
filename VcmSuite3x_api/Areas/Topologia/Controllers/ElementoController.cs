using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VcmSuite3x.Application.Interface;
using VcmSuite3x.Application.ViewModel;
using VcmSuite3x_api.Core.Interface;
using VcmSuite3x_api.Core.Models;
using VcmSuite3x_api.Core.Repository;
using VcmSuite3x_api.Models;

namespace VcmSuite3x_api.Areas.Topologia.Controllers
{
    [Route("api/[controller]")/*, Authorize*/]
    public class ElementoController : Controller
    {
        private readonly IUnitOfWork _unitOfw;
        private readonly IElementoAppService _elemento;
        public ElementoController(IUnitOfWork unitOfWork, IElementoAppService elementoAppService)
        {
            _unitOfw = unitOfWork;
            _elemento = elementoAppService;
        }


        [HttpGet]
        public IActionResult Get(int elementoId, int cenarioId, string tipoElemento)
        {

            var elementoRetorno = _elemento.Get(elementoId, cenarioId, tipoElemento);

            BaseViewModel<object> baseObj = new BaseViewModel<object>(elementoRetorno, "", "");

            return Ok(baseObj);
        }


        [HttpPost]
        public IActionResult Update([FromBody]NoViewModel model)
        {
            try
            {
                NoModel elemento = JsonConvert.DeserializeObject<NoModel>(model.Elementos.ToString());

                No no = _unitOfw.NoRepository.Get(y => y.Id == elemento.Id, null, "NoProduto").FirstOrDefault();
                if (model.Items.Posted.Count() > 0)
                {
                    //Remove a ligação com o No dos Produtos que não estão mais selecionados

                    _unitOfw.pr_VCM_NoProdutosUpdate(elemento.Id, elemento.Codigo, elemento.Descricao, elemento.TipoEntidadeId, elemento.TopologiaId, elemento.Localizacao, elemento.Nota, model.Items.Posted);
                }
                else
                {
                    _unitOfw.pr_VCM_NoUpdate(elemento.Id, elemento.Codigo, elemento.Descricao, elemento.TipoEntidadeId, elemento.TopologiaId, elemento.Localizacao, elemento.Nota);

                    
                }
                BaseViewModel<NoViewModel> baseObj = new BaseViewModel<NoViewModel>(model, "Saved Successfully!", "");
                return Ok(baseObj);
                //string localizacao = null;

                //if (model.Localizacoes != null)
                //{
                //    localizacao = model.Localizacoes.Where(y => y.Selected == true).Select(t => t.Text).FirstOrDefault();

                //    if (!_unitOfw.LocalizacaoExiste(localizacao, 0))
                //    {
                //        BaseViewModel<string> notFound = new BaseViewModel<string>("Localização Not Found!");
                //        return NotFound(notFound);
                //    }
                //}

                //No noToBeSaved = new No { Localizacao = localizacao };



            }
            catch (Exception ex)
            {
                throw;
            }


        }
    }
}