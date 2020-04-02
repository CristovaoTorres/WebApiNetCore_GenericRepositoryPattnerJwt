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
using VcmSuite3x.Application.ViewModel;
using VcmSuite3x_api.Business;
using VcmSuite3x_api.Core.Models;
using VcmSuite3x_api.Core.Repository;
using VcmSuite3x_api.Models;

namespace TesteVCMSuite3x_Api
{


    [TestClass]
    public class PeriodoTest
    {
        UnitOfWork _unitOfw = new UnitOfWork();
        ClientCall _clientCall = new ClientCall();
        private string _baseController = "api/Periodo/";


        [TestMethod]
        public async System.Threading.Tasks.Task Get()
        {
            HttpResponseMessage response = await _clientCall.Detail(_baseController + "Detail/" + 1);

            Assert.IsTrue(response.IsSuccessStatusCode);
            var retorno = await response.Content.ReadAsStringAsync();

            PeriodoViewModel periodoResponse = JsonConvert.DeserializeObject<PeriodoViewModel>(JObject.Parse(retorno)["data"].ToString());

            Periodo periodoFromDataBase = _unitOfw.PeriodoRepository.Get(y => y.Id == periodoResponse.Id).FirstOrDefault();

            Assert.AreEqual(periodoResponse.Id, periodoFromDataBase.Id);
            Assert.AreEqual(periodoResponse.Descricao, periodoFromDataBase.Descricao);
            Assert.AreEqual(periodoResponse.Codigo, periodoFromDataBase.Codigo);
            Assert.AreEqual(periodoResponse.TopologiaId, periodoFromDataBase.TopologiaId);

        }

        [TestMethod]
        public async System.Threading.Tasks.Task Save()
        {

            RequestPeriodoSave periodoToBeSave = new RequestPeriodoSave
            {

                Codigo = "Codigo + " + DateTime.Now,
                Descricao = "Descrição" + DateTime.Now,
                Quantidade = 1,
                TopologiaId = 1,
            };

            HttpResponseMessage response = await _clientCall.Save(_baseController + "Save/", JsonConvert.SerializeObject(periodoToBeSave));

            Assert.IsTrue(response.IsSuccessStatusCode);
            if (response.IsSuccessStatusCode)
            {
                var retorno = await response.Content.ReadAsStringAsync();

                List<PeriodoViewModel> listPeriodoRetornoJson = JsonConvert.DeserializeObject<List<PeriodoViewModel>>(JObject.Parse(retorno)["data"].ToString());

                Assert.AreEqual(periodoToBeSave.Quantidade, listPeriodoRetornoJson.Count());


                foreach (PeriodoViewModel onePeriodo in listPeriodoRetornoJson)
                {

                    Periodo periodo = _unitOfw.PeriodoRepository.Get(y => y.Id == onePeriodo.Id).FirstOrDefault();


                    Assert.AreEqual(onePeriodo.TopologiaId, periodoToBeSave.TopologiaId);
                    Assert.AreEqual(onePeriodo.TopologiaId, periodo.TopologiaId);

                    Assert.AreEqual(onePeriodo.Codigo, periodo.Codigo);
                    Assert.AreEqual(onePeriodo.Descricao, periodo.Descricao);
                }
            }


        }

        [TestMethod]
        public async System.Threading.Tasks.Task SaveUpdate()
        {

            RequestPeriodoSave periodoToBeSave = new RequestPeriodoSave
            {

                Id = 10993,
                Codigo = "C" + DateTime.Now.ToString("ddMMyyHHmmss"),
                Descricao = "D_" + DateTime.Now.ToString("ddMMyy HHmmss"),
                TopologiaId = 1,
            };

            HttpResponseMessage response = await _clientCall.Save(_baseController + "Save/", JsonConvert.SerializeObject(periodoToBeSave));

            Assert.IsTrue(response.IsSuccessStatusCode);
            if (response.IsSuccessStatusCode)
            {
                var retorno = await response.Content.ReadAsStringAsync();

                PeriodoViewModel periodoRetornoJson = JsonConvert.DeserializeObject<PeriodoViewModel>(JObject.Parse(retorno)["data"].ToString());


                Periodo periodo = _unitOfw.PeriodoRepository.Get(y => y.Id == periodoToBeSave.Id).FirstOrDefault();

                Assert.AreEqual(periodoToBeSave.Id, periodoRetornoJson.Id);

                Assert.AreEqual(periodoToBeSave.TopologiaId, periodo.TopologiaId);
                Assert.AreEqual(periodoToBeSave.TopologiaId, periodoRetornoJson.TopologiaId);

                Assert.AreEqual(periodoToBeSave.Codigo, periodo.Codigo);
                Assert.AreEqual(periodoToBeSave.Codigo, periodoRetornoJson.Codigo);

                Assert.AreEqual(periodoToBeSave.Descricao, periodo.Descricao);
                Assert.AreEqual(periodoToBeSave.Descricao, periodoRetornoJson.Descricao);

            }
        }

        [TestMethod]
        public async System.Threading.Tasks.Task Delete()
        {
            int idPeriodo = 10993;

            HttpResponseMessage response = await _clientCall.Delete(_baseController + "Delete/" + idPeriodo);

            Assert.IsTrue(response.IsSuccessStatusCode);

            Periodo periodoFromDatabase = _unitOfw.PeriodoRepository.Get(y => y.Id == idPeriodo).FirstOrDefault();

            Assert.IsNull(periodoFromDatabase);
        }




    }
}
