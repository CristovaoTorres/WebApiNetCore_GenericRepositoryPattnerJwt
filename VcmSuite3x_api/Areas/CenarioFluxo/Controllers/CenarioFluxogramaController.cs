using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using VcmSuite3x.Application.Interface;
using VcmSuite3x_api.Core.Repository;
using VcmSuite3x_api.Models;

namespace VcmSuite3x_api.Areas.CenarioFluxograma.Controllers
{
    [Route("api/[controller]/")/*, Authorize*/]
    public class CenarioFluxogramaController : Controller
    {
        #region Properties
        private readonly ICenarioFluxoAppService _cenario;

        public CenarioFluxogramaController(ICenarioFluxoAppService cenario)
        {
            _cenario = cenario;
        }

        #endregion
        //[HttpPost]
        //public IActionResult Post(string data, string no)
        //{
        //    _cenario.Post(data);

        //    BaseViewModel<RequestCenarioSave> baseObj = new BaseViewModel<RequestCenarioSave>(new RequestCenarioSave(), "Cenario Saved Successfully!", "");
        //    return Ok(baseObj);
        //}

        [HttpGet]
        public IActionResult Get(int elementoId, int cenarioId, string codigo, int topologiaId)
        {
            //Funcionando
            //var uf_ProductCost = _cenario.EntradaSimbolo(cenarioId, codigo, VcmSuite3x.Application.Util.EEntryBySymbolType.UF_ProductCost);

            //FUncionando
            //var ua_InitialVolume = _cenario.EntradaSimbolo(cenarioId, codigo, VcmSuite3x.Application.Util.EEntryBySymbolType.UA_InitialVolume);

            //Funcionando -  Definir como deve retornar qual é o valor Minimo e o Máximo, se deve ser verificado no back ou no front
            //var ua_AgrupedVolume = _cenario.EntradaSimbolo(cenarioId, codigo, VcmSuite3x.Application.Util.EEntryBySymbolType.UA_AgrupedVolume);

            //Funcionando: Verificar como o front faz para separar os itens por colunas e linhas;
            //var ua_VariableCost = _cenario.EntradaSimbolo(cenarioId, codigo, VcmSuite3x.Application.Util.EEntryBySymbolType.UA_VariableCost);

            //Funcionando
            //var ua_FixedCost = _cenario.EntradaSimbolo(cenarioId, codigo, VcmSuite3x.Application.Util.EEntryBySymbolType.UA_FixedCost);

            //var ua_FixedCost = _cenario.EntradaSimbolo(cenarioId, codigo, VcmSuite3x.Application.Util.EEntryBySymbolType.MC_DemandaProduto);

            return Ok();
        }

    }
}