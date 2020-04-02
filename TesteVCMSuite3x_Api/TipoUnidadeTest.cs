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
    public class TipoUnidadeTest
    {
        UnitOfWork _unitOfw = new UnitOfWork();
        ClientCall _clientCall = new ClientCall();
        private readonly string _baseAddress = "http://localhost:63373/";
        private readonly string _baseController = "api/TipoUnidade/";


        [TestMethod]
        public async System.Threading.Tasks.Task List()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(_baseController + "List");

                Assert.IsTrue(response.IsSuccessStatusCode);
                if (response.IsSuccessStatusCode)
                {
                    var retorno = await response.Content.ReadAsStringAsync();

                    List<RequestTipoUnidadeSave> tipoUnidadeList = JsonConvert.DeserializeObject<List<RequestTipoUnidadeSave>>(JObject.Parse(retorno)["data"].ToString());

                    Assert.IsNotNull(tipoUnidadeList);
                }
            }

        }

        [TestMethod]
        public async System.Threading.Tasks.Task Get()
        {

            int idTipoUnidade = _unitOfw.TipoUnidadeRepository.Get().ToList().FirstOrDefault().Id;

            HttpResponseMessage response = await _clientCall.Detail(_baseController + "Detail/" + idTipoUnidade);

            Assert.IsTrue(response.IsSuccessStatusCode);
            if (response.IsSuccessStatusCode)
            {
                var retorno = await response.Content.ReadAsStringAsync();

                TipoUnidadeResponse tipoUnidade = JsonConvert.DeserializeObject<TipoUnidadeResponse>(JObject.Parse(retorno)["data"].ToString());

                Assert.IsNotNull(tipoUnidade);
                Assert.AreEqual(idTipoUnidade, tipoUnidade.Id);
            }
        }

        [TestMethod]
        public async System.Threading.Tasks.Task Save()
        {
            RequestTipoUnidadeSave tipoUnidadeToBeSave = new RequestTipoUnidadeSave
            {
                Nome = "Insert" + DateTime.Now,
                Id = 0
            };

            HttpResponseMessage response = await _clientCall.Save(_baseController + "Save/", JsonConvert.SerializeObject(tipoUnidadeToBeSave));

            Assert.IsTrue(response.IsSuccessStatusCode);
            if (response.IsSuccessStatusCode)
            {
                var retorno = await response.Content.ReadAsStringAsync();

                RequestTipoUnidadeSave tipoUnidadeRetorno = JsonConvert.DeserializeObject<RequestTipoUnidadeSave>(JObject.Parse(retorno)["data"].ToString());

                TipoUnidade tipoUnidadeAfterSave = _unitOfw.TipoUnidadeRepository.Get(y => y.Id == tipoUnidadeRetorno.Id).FirstOrDefault();

                Assert.AreEqual(tipoUnidadeToBeSave.Nome, tipoUnidadeAfterSave.Nome);
            }
        }

        [TestMethod]
        public async System.Threading.Tasks.Task SaveUpdate()
        {
            try
            {
                int idTopologia = 1;
                RequestTipoUnidadeSave topologiaToBeSave = new RequestTipoUnidadeSave
                {
                    Nome = "Update" + DateTime.Now,
                    Id = idTopologia
                };

                HttpResponseMessage response = await _clientCall.Save(_baseController + "Save/", JsonConvert.SerializeObject(topologiaToBeSave));

                Assert.IsTrue(response.IsSuccessStatusCode);
                if (response.IsSuccessStatusCode)
                {
                    var retorno = await response.Content.ReadAsStringAsync();

                    RequestTipoUnidadeSave topologiaRetorno = JsonConvert.DeserializeObject<RequestTipoUnidadeSave>(JObject.Parse(retorno)["data"].ToString());

                    TipoUnidade tipoUnidadeAfterUpdate = _unitOfw.TipoUnidadeRepository.Get(y => y.Id == idTopologia).FirstOrDefault();

                    Assert.AreEqual(topologiaToBeSave.Nome, tipoUnidadeAfterUpdate.Nome);
                    Assert.AreEqual(topologiaRetorno.Nome, tipoUnidadeAfterUpdate.Nome);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [TestMethod]
        public async System.Threading.Tasks.Task Delete()
        {
            try
            {
                int idTipoUnidade = 13;

                HttpResponseMessage response = await _clientCall.Delete(_baseController + "Delete/" + idTipoUnidade);

                Assert.IsTrue(response.IsSuccessStatusCode);
                if (response.IsSuccessStatusCode)
                {
                    var retorno = await response.Content.ReadAsStringAsync();

                    TipoUnidade tipounidade = _unitOfw.TipoUnidadeRepository.Get(y => y.Id == idTipoUnidade).FirstOrDefault();

                    Assert.IsNull(tipounidade);
                }
            }

            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
