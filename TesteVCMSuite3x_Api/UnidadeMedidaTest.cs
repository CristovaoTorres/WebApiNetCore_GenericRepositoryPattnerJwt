using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using VcmSuite3x_api.Business;
using VcmSuite3x_api.Core.Models;
using VcmSuite3x_api.Core.Repository;
using VcmSuite3x_api.Models;

namespace TesteVCMSuite3x_Api
{


    [TestClass]
    public class UnidadeMedidaTest
    {
        UnitOfWork _unitOfw = new UnitOfWork();
        ClientCall _clientCall = new ClientCall();
        private string _baseController = "api/UnidadeMedida/";



        [TestMethod]
        public async System.Threading.Tasks.Task Get()
        {


            HttpResponseMessage response = await _clientCall.Detail(_baseController + "Detail/" + 21);

            Assert.IsTrue(response.IsSuccessStatusCode);
            var retorno = await response.Content.ReadAsStringAsync();

            UnidadeMedidaResponse unidadeMedidaResponse = JsonConvert.DeserializeObject<UnidadeMedidaResponse>(JObject.Parse(retorno)["data"].ToString());

            UnidadeMedida unidadeMedidaFromDataBase = _unitOfw.UnidadeMedidaRepository.Get(y => y.Id == unidadeMedidaResponse.Id).FirstOrDefault();

            Assert.AreEqual(unidadeMedidaResponse.Id, unidadeMedidaFromDataBase.Id);
            Assert.AreEqual(unidadeMedidaResponse.Nome, unidadeMedidaFromDataBase.Nome);
            Assert.AreEqual(unidadeMedidaResponse.TipoUnidadeId, unidadeMedidaFromDataBase.TipoUnidadeId);
            Assert.AreEqual(unidadeMedidaResponse.Representacao, unidadeMedidaFromDataBase.Representacao);
            Assert.AreEqual(unidadeMedidaResponse.FatorConversao, unidadeMedidaFromDataBase.FatorConversao);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task Save()
        {

            RequestUnidadeMedidaSave unidadeMedidaToBeSave = new RequestUnidadeMedidaSave
            {
                Id = 0,
                Nome = "N" + DateTime.Now.ToString(),
                Representacao = "TNT",
                FatorConversao = 45,
                TipoUnidadeId = 2
            };


            HttpResponseMessage response = await _clientCall.Save(_baseController + "Save/", JsonConvert.SerializeObject(unidadeMedidaToBeSave));

            Assert.IsTrue(response.IsSuccessStatusCode);
            if (response.IsSuccessStatusCode)
            {
                var retorno = await response.Content.ReadAsStringAsync();

                RequestUnidadeMedidaSave unidadeMedidaRetornoJson = JsonConvert.DeserializeObject<RequestUnidadeMedidaSave>(JObject.Parse(retorno)["data"].ToString());

                UnidadeMedida unidadeMedidafterSaveDataBase = _unitOfw.UnidadeMedidaRepository.Get(y => y.Id == unidadeMedidaRetornoJson.Id).FirstOrDefault();

                Assert.AreEqual(unidadeMedidaRetornoJson.Id, unidadeMedidafterSaveDataBase.Id);
                Assert.AreEqual(unidadeMedidafterSaveDataBase.Nome, unidadeMedidaRetornoJson.Nome);
                Assert.AreEqual(unidadeMedidafterSaveDataBase.FatorConversao, unidadeMedidaRetornoJson.FatorConversao);
                Assert.AreEqual(unidadeMedidafterSaveDataBase.Representacao, unidadeMedidaRetornoJson.Representacao);
                Assert.AreEqual(unidadeMedidafterSaveDataBase.TipoUnidadeId, unidadeMedidaRetornoJson.TipoUnidadeId);
            }
        }

        [TestMethod]
        public async System.Threading.Tasks.Task SaveUpdate()
        {

            RequestUnidadeMedidaSave unidadeMedidaToBeUpdate = new RequestUnidadeMedidaSave
            {
                Id = 1,
                Nome = "N_" + DateTime.Now.ToString("ddMMyy HH:mm:ss"),
                Representacao = "TNT",
                FatorConversao = 45,
                TipoUnidadeId = 2
            };


            HttpResponseMessage response = await _clientCall.Save(_baseController + "Save/", JsonConvert.SerializeObject(unidadeMedidaToBeUpdate));

            Assert.IsTrue(response.IsSuccessStatusCode);
            if (response.IsSuccessStatusCode)
            {
                var retorno = await response.Content.ReadAsStringAsync();

                RequestUnidadeMedidaSave unidadeMedidaRetornoJson = JsonConvert.DeserializeObject<RequestUnidadeMedidaSave>(JObject.Parse(retorno)["data"].ToString());

                UnidadeMedida unidadeMedidafterSaveDataBase = _unitOfw.UnidadeMedidaRepository.Get(y => y.Id == unidadeMedidaToBeUpdate.Id).FirstOrDefault();

                Assert.AreEqual(unidadeMedidaRetornoJson.Id, unidadeMedidafterSaveDataBase.Id);

                Assert.AreEqual(unidadeMedidaToBeUpdate.Nome, unidadeMedidaRetornoJson.Nome);
                Assert.AreEqual(unidadeMedidaToBeUpdate.Nome, unidadeMedidafterSaveDataBase.Nome);

                Assert.AreEqual(unidadeMedidafterSaveDataBase.FatorConversao, unidadeMedidaRetornoJson.FatorConversao);
                Assert.AreEqual(unidadeMedidafterSaveDataBase.FatorConversao, unidadeMedidafterSaveDataBase.FatorConversao);

                Assert.AreEqual(unidadeMedidafterSaveDataBase.Representacao, unidadeMedidaRetornoJson.Representacao);
                Assert.AreEqual(unidadeMedidafterSaveDataBase.Representacao, unidadeMedidafterSaveDataBase.Representacao);

                Assert.AreEqual(unidadeMedidafterSaveDataBase.TipoUnidadeId, unidadeMedidaRetornoJson.TipoUnidadeId);
                Assert.AreEqual(unidadeMedidafterSaveDataBase.TipoUnidadeId, unidadeMedidafterSaveDataBase.TipoUnidadeId);
            }
        }

        [TestMethod]
        public async System.Threading.Tasks.Task Delete()
        {
            int idUnidadeMedida = 51;

            HttpResponseMessage response = await _clientCall.Delete(_baseController + "Delete/" + idUnidadeMedida);

            Assert.IsTrue(response.IsSuccessStatusCode);

            UnidadeMedida projetoFromDatabase = _unitOfw.UnidadeMedidaRepository.Get(y => y.Id == idUnidadeMedida).FirstOrDefault();

            Assert.IsNull(projetoFromDatabase);
        }




    }
}
