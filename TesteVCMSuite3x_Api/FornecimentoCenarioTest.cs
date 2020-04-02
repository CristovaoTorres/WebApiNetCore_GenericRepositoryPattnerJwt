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
using VcmSuite3x_api.Core.Models;
using VcmSuite3x_api.Core.Repository;
using VcmSuite3x_api.Models;

namespace TesteVCMSuite3x_Api
{
    [TestClass]
    public class FornecimentoCenarioTest
    {
        private string _baseController = "api/FornecimentoCenario/";
        ClientCall _clientCall = new ClientCall();
        UnitOfWork _unitOfw = new UnitOfWork();


        [TestMethod]
        public async System.Threading.Tasks.Task Save()
        {

            FornecimentoCenarioSave fornecimentoCenarioToBeSave = new FornecimentoCenarioSave
            {
                CenarioId = 2007,
                NoId = 26,
                CapacidadePoroes = true,
                IncluirCalculoImpostos = true,
                Suprimento = true,
                SuprimentoAgregado = true,
                SuprimentoAgregadoSemiContinuo = true,
                SuprimentoSemiContinuo = true
            };


            HttpResponseMessage response = await _clientCall.Save(_baseController + "Save/", JsonConvert.SerializeObject(fornecimentoCenarioToBeSave));

            Assert.IsTrue(response.IsSuccessStatusCode);
            if (response.IsSuccessStatusCode)
            {
                var retorno = await response.Content.ReadAsStringAsync();
                FornecimentoCenarioSave fornecimentoCenarioRetornoJson = JsonConvert.DeserializeObject<FornecimentoCenarioSave>(JObject.Parse(retorno)["data"].ToString());


                FornecimentoCenario fornecimentoCenario = _unitOfw.FornecimentoCenarioRepository.Get(y => y.NoId == fornecimentoCenarioToBeSave.NoId
                                                                                                    && y.CenarioId == fornecimentoCenarioToBeSave.CenarioId)
                                                                                                    .FirstOrDefault();


                Assert.AreEqual(fornecimentoCenarioToBeSave.NoId, fornecimentoCenarioRetornoJson.NoId);
                Assert.AreEqual(fornecimentoCenarioToBeSave.CenarioId, fornecimentoCenarioRetornoJson.CenarioId);
                Assert.AreEqual(fornecimentoCenarioToBeSave.Suprimento, fornecimentoCenarioRetornoJson.Suprimento);
                Assert.AreEqual(fornecimentoCenarioToBeSave.SuprimentoAgregado, fornecimentoCenarioRetornoJson.SuprimentoAgregado);
                Assert.AreEqual(fornecimentoCenarioToBeSave.SuprimentoAgregadoSemiContinuo, fornecimentoCenarioRetornoJson.SuprimentoAgregadoSemiContinuo);
                Assert.AreEqual(fornecimentoCenarioToBeSave.SuprimentoSemiContinuo, fornecimentoCenarioRetornoJson.SuprimentoSemiContinuo);
                Assert.AreEqual(fornecimentoCenarioToBeSave.CapacidadePoroes, fornecimentoCenarioRetornoJson.CapacidadePoroes);
                Assert.AreEqual(fornecimentoCenarioToBeSave.IncluirCalculoImpostos, fornecimentoCenarioRetornoJson.IncluirCalculoImpostos);


                Assert.AreEqual(fornecimentoCenarioToBeSave.NoId, fornecimentoCenario.NoId);
                Assert.AreEqual(fornecimentoCenarioToBeSave.CenarioId, fornecimentoCenario.CenarioId);
                Assert.AreEqual(fornecimentoCenarioToBeSave.Suprimento, fornecimentoCenario.Suprimento);
                Assert.AreEqual(fornecimentoCenarioToBeSave.SuprimentoAgregado, fornecimentoCenario.SuprimentoAgregado);
                Assert.AreEqual(fornecimentoCenarioToBeSave.SuprimentoAgregadoSemiContinuo, fornecimentoCenario.SuprimentoAgregadoSemiContinuo);
                Assert.AreEqual(fornecimentoCenarioToBeSave.SuprimentoSemiContinuo, fornecimentoCenario.SuprimentoSemiContinuo);
                Assert.AreEqual(fornecimentoCenarioToBeSave.CapacidadePoroes, fornecimentoCenario.CapacidadePoroes);
                Assert.AreEqual(fornecimentoCenarioToBeSave.IncluirCalculoImpostos, fornecimentoCenario.IncluirCalculoImpostos);



            }
        }

        [TestMethod]
        public async System.Threading.Tasks.Task Get()
        {
            int cenarioId = 2007;
            int noId = 26;


            HttpResponseMessage response = await _clientCall.Detail($"{_baseController}Detail/{cenarioId}/{noId}");

            Assert.IsTrue(response.IsSuccessStatusCode);
            var retorno = await response.Content.ReadAsStringAsync();

            FornecimentoCenarioSave FornecimentoCenarioResponseJson = JsonConvert.DeserializeObject<FornecimentoCenarioSave>(JObject.Parse(retorno)["data"].ToString());

            FornecimentoCenario fornecimentoCenarioFromDataBase = _unitOfw.FornecimentoCenarioRepository.Get(y => y.NoId == FornecimentoCenarioResponseJson.NoId
                                                                                                             && y.CenarioId == cenarioId).FirstOrDefault();

            Assert.AreEqual(fornecimentoCenarioFromDataBase.NoId, FornecimentoCenarioResponseJson.NoId);
            Assert.AreEqual(fornecimentoCenarioFromDataBase.CenarioId, FornecimentoCenarioResponseJson.CenarioId);
            Assert.AreEqual(fornecimentoCenarioFromDataBase.Suprimento, FornecimentoCenarioResponseJson.Suprimento);
            Assert.AreEqual(fornecimentoCenarioFromDataBase.CapacidadePoroes, FornecimentoCenarioResponseJson.CapacidadePoroes);
            Assert.AreEqual(fornecimentoCenarioFromDataBase.SuprimentoAgregado, FornecimentoCenarioResponseJson.SuprimentoAgregado);
            Assert.AreEqual(fornecimentoCenarioFromDataBase.SuprimentoSemiContinuo, FornecimentoCenarioResponseJson.SuprimentoSemiContinuo);
            Assert.AreEqual(fornecimentoCenarioFromDataBase.IncluirCalculoImpostos, FornecimentoCenarioResponseJson.IncluirCalculoImpostos);
            Assert.AreEqual(fornecimentoCenarioFromDataBase.SuprimentoAgregadoSemiContinuo, FornecimentoCenarioResponseJson.SuprimentoAgregadoSemiContinuo);


        }

    }
}
