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
    public class TopologiaTest
    {
        UnitOfWork _unitOfw = new UnitOfWork();
        private readonly string _baseAddress = "http://localhost:63373/";
        private readonly string _baseController = "api/Topologia/";
        ClientCall _clientCall = new ClientCall();


        [TestMethod]
        public async System.Threading.Tasks.Task List()
        {

            int idProjeto = _unitOfw.ProjetoRepository.Get(y => y.Id == 1).FirstOrDefault().Id;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(_baseController + "List/" + idProjeto);

                Assert.IsTrue(response.IsSuccessStatusCode);
                if (response.IsSuccessStatusCode)
                {
                    var retorno = await response.Content.ReadAsStringAsync();

                    List<Topologia> topologiaList = JsonConvert.DeserializeObject<List<Topologia>>(JObject.Parse(retorno)["data"].ToString());

                    Assert.IsNotNull(topologiaList);

                    foreach (var oneTopologia in topologiaList)
                    {
                        Assert.AreEqual(oneTopologia.ProjetoId, idProjeto);
                    }
                }
            }

        }

        [TestMethod]
        public async System.Threading.Tasks.Task Get()
        {

            int idTopologia = _unitOfw.TopologiaRepository.Get().ToList().FirstOrDefault().Id;

            HttpResponseMessage response = await _clientCall.Detail(_baseController + "Detail/" + idTopologia);

            Assert.IsTrue(response.IsSuccessStatusCode);
            if (response.IsSuccessStatusCode)
            {
                var retorno = await response.Content.ReadAsStringAsync();

                Topologia topologia = JsonConvert.DeserializeObject<Topologia>(JObject.Parse(retorno)["data"].ToString());

                Assert.IsNotNull(topologia);
                Assert.AreEqual(idTopologia, topologia.Id);
            }

        }

        [TestMethod]
        public async System.Threading.Tasks.Task Save()
        {
            RequestTopologiaSave topologiaToBeSave = new RequestTopologiaSave
            {
                Nome = "Insert" + DateTime.Now,
                ProjetoId = 1,
                Id = 0
            };

            HttpResponseMessage response = await _clientCall.Save(_baseController + "Save/", JsonConvert.SerializeObject(topologiaToBeSave));

            Assert.IsTrue(response.IsSuccessStatusCode);
            if (response.IsSuccessStatusCode)
            {
                var retorno = await response.Content.ReadAsStringAsync();

                RequestTopologiaSave topologiaRetorno = JsonConvert.DeserializeObject<RequestTopologiaSave>(JObject.Parse(retorno)["data"].ToString());

                Topologia topologiaAfterSave = _unitOfw.TopologiaRepository.Get(y => y.Id == topologiaRetorno.Id).FirstOrDefault();

                Assert.AreEqual(topologiaToBeSave.Nome, topologiaAfterSave.Nome);

                Assert.AreEqual(topologiaToBeSave.ProjetoId, topologiaAfterSave.ProjetoId);
            }
        }

        [TestMethod]
        public async System.Threading.Tasks.Task SaveUpdate()
        {

            try
            {
                int idTopologia = 1;
                RequestTopologiaSave topologiaToBeSave = new RequestTopologiaSave
                {
                    Nome = "Update" + DateTime.Now,
                    Id = idTopologia,
                    ProjetoId = 1
                };

                HttpResponseMessage response = await _clientCall.Save(_baseController + "Save/", JsonConvert.SerializeObject(topologiaToBeSave));

                Assert.IsTrue(response.IsSuccessStatusCode);
                if (response.IsSuccessStatusCode)
                {
                    var retorno = await response.Content.ReadAsStringAsync();

                    RequestTopologiaSave topologiaRetorno = JsonConvert.DeserializeObject<RequestTopologiaSave>(JObject.Parse(retorno)["data"].ToString());

                    Topologia topologiaAfterUpdate = _unitOfw.TopologiaRepository.Get(y => y.Id == idTopologia).FirstOrDefault();


                    Assert.AreEqual(topologiaToBeSave.Nome, topologiaAfterUpdate.Nome);
                    Assert.AreEqual(topologiaRetorno.Nome, topologiaAfterUpdate.Nome);

                    Assert.AreEqual(topologiaToBeSave.ProjetoId, topologiaAfterUpdate.ProjetoId);
                    Assert.AreEqual(topologiaRetorno.ProjetoId, topologiaAfterUpdate.ProjetoId);
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
                int idTopologia = 6118;
                RequestTopologiaSave topologia = new RequestTopologiaSave();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_baseAddress);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.DeleteAsync(_baseController + "Delete/" + idTopologia);

                    Assert.IsTrue(response.IsSuccessStatusCode);
                    if (response.IsSuccessStatusCode)
                    {
                        var retorno = await response.Content.ReadAsStringAsync();

                        Topologia topologiaGet = _unitOfw.TopologiaRepository.Get(y => y.Id == idTopologia).FirstOrDefault();

                        Assert.IsNull(topologiaGet);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
