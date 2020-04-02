using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using VcmSuite3x_api.Core.Models;
using VcmSuite3x_api.Core.Repository;
using ex = VcmSuite3x_api.Extensions;
using VcmSuite3x_api.Models;
using Microsoft.CodeAnalysis.Scripting;
using VcmSuite3x.Application.Service;
using VcmSuite3x.Application.Interface;

namespace TesteVCMSuite3x_Api
{
    [TestClass]
    public class CenarioTeste
    {
        UnitOfWork _unitOfw = new UnitOfWork();
        ClientCall _clientCall = new ClientCall();
        private readonly IDrawingAppService _drawingAppService;


        private string _baseAddress = "http://localhost:63373/";
        private string _baseController = "api/Cenario/";

        public CenarioTeste(IDrawingAppService drawingAppService)
        {
            _drawingAppService = drawingAppService;

        }

        [TestMethod]
        public async System.Threading.Tasks.Task Get()
        {
            int fluxogramaId = 7038;

            try
            {
                var draing = _drawingAppService.pr_VCM_NoDrawingSelect(fluxogramaId);
            }
            catch (Exception ex)
            {

                throw;
            }


            var filter = "y => y.TipoEntidadeId == 224 && y.TopologiaId == 5077";
            List<Entidade> entidades = await _unitOfw.EntidadeRepository.EntidadesEntity(filter);


            #region Test
            //List<Entidade> entidades = _unitOfw.EntidadeRepository.EntidadesEntity(y => y.TipoEntidadeId == 224 && y.TopologiaId == 5077
            //                                           , y => y.TipoEntidadeId == 224 && y.TopologiaId == 5077
            //                                           , y => y.TipoEntidadeId == 224 && y.TopologiaId == 5077
            //                                           , y => y.TipoEntidadeId == 224 && y.TopologiaId == 5077
            //                                           , y => y.TipoEntidadeId == 224 && y.TopologiaId == 5077
            //                                           , y => y.TipoEntidadeId == 224 && y.TopologiaId == 5077
            //                                           , y => y.TipoEntidadeId == 224 && y.TopologiaId == 5077
            //                                           , y => y.TipoEntidadeId == 224 && y.TopologiaId == 5077
            //                                           , y => y.TipoEntidadeId == 224 && y.TopologiaId == 5077
            //                                           , y => y.TipoEntidadeId == 224 && y.TopologiaId == 5077
            //                                           , y => y.TipoEntidadeId == 224 && y.TopologiaId == 5077
            //                                           , y => y.TipoEntidadeId == 224 && y.TopologiaId == 5077
            //                                           , y => y.TipoEntidadeId == 224 && y.TopologiaId == 5077
            //                                           , y => y.TipoEntidadeId == 224 && y.TopologiaId == 5077
            //                                           , y => y.TipoEntidadeId == 224 && y.TopologiaId == 5077
            //                                           , y => y.TipoEntidadeId == 224 && y.TopologiaId == 5077
            //                                           , y => y.TipoEntidadeId == 224 && y.TopologiaId == 5077
            //                                           , y => y.TopologiaId == 5077
            //                                           , y => y.Id == 224
            //                                           , y => y.TipoEntidadeId == 224 && y.TopologiaId == 5077
            //                                           , y => y.TipoEntidadeId == 224 && y.TopologiaId == 5077
            //                                           , y => y.TipoEntidadeId == 224 && y.TopologiaId == 5077
            //                                           );
            #endregion

            int idCenario = _unitOfw.CenarioRepository.Get().ToList().FirstOrDefault().Id;

            HttpResponseMessage response = await _clientCall.Detail(_baseController + "Detail/" + idCenario);

            Assert.IsTrue(response.IsSuccessStatusCode);
            if (response.IsSuccessStatusCode)
            {
                var retorno = await response.Content.ReadAsStringAsync();

                RequestCenario cenario = JsonConvert.DeserializeObject<RequestCenario>(JObject.Parse(retorno)["data"].ToString());

                Assert.IsNotNull(cenario);
                Assert.AreEqual(Convert.ToInt32(idCenario), Convert.ToInt32(cenario.Id));
            }
        }

        [TestMethod]
        public async System.Threading.Tasks.Task Delete()
        {
            int idCenario = 6149;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.DeleteAsync(_baseController + "Delete/" + idCenario);

                Assert.IsTrue(response.IsSuccessStatusCode);
                if (response.IsSuccessStatusCode)
                {
                    var retorno = await response.Content.ReadAsStringAsync();
                }
            }

            Cenario cenarioGet = _unitOfw.CenarioRepository.Get(y => y.Id == idCenario).FirstOrDefault();

            Assert.IsNull(cenarioGet);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task Save()
        {
            RequestCenarioSave cenarioToBeSave = new RequestCenarioSave
            {
                Nome = "Insert" + DateTime.Now,
                TopologiaId = 1,
                Id = 0
            };

            HttpResponseMessage response = await _clientCall.Save(_baseController + "Save/", JsonConvert.SerializeObject(cenarioToBeSave));

            Assert.IsTrue(response.IsSuccessStatusCode);
            if (response.IsSuccessStatusCode)
            {
                var retorno = await response.Content.ReadAsStringAsync();

                RequestCenario cenarioRetorno = JsonConvert.DeserializeObject<RequestCenario>(JObject.Parse(retorno)["data"].ToString());

                Cenario cenarioafterSave = _unitOfw.CenarioRepository.Get(y => y.Id == cenarioRetorno.Id).FirstOrDefault();

                Assert.AreEqual(cenarioToBeSave.Nome, cenarioafterSave.Nome);

                Assert.AreEqual(cenarioToBeSave.TopologiaId, cenarioafterSave.TopologiaId);
            }
        }

        [TestMethod]
        public async System.Threading.Tasks.Task SaveUpdate()
        {
            int idCenario = 1;
            RequestCenarioSave cenarioToBeSave = new RequestCenarioSave
            {
                Nome = "Update" + DateTime.Now,
                Id = idCenario
            };

            HttpClient client = new HttpClient { BaseAddress = new Uri(_baseAddress) };

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, _baseController + "Save/")
            {
                Content = new StringContent(JsonConvert.SerializeObject(cenarioToBeSave), Encoding.UTF8, "application/json")
            };

            HttpResponseMessage response = await client.SendAsync(request);

            Assert.IsTrue(response.IsSuccessStatusCode);
            if (response.IsSuccessStatusCode)
            {
                var retorno = await response.Content.ReadAsStringAsync();

                RequestCenario cenarioRetorno = JsonConvert.DeserializeObject<RequestCenario>(JObject.Parse(retorno)["data"].ToString());

                Cenario cenarioAfterUpdate = _unitOfw.CenarioRepository.Get(y => y.Id == idCenario).FirstOrDefault();


                Assert.AreEqual(cenarioToBeSave.Nome, cenarioAfterUpdate.Nome);
                Assert.AreEqual(cenarioRetorno.Nome, cenarioAfterUpdate.Nome);

                Assert.AreEqual(cenarioToBeSave.TopologiaId, cenarioAfterUpdate.TopologiaId);
                Assert.AreEqual(cenarioRetorno.TopologiaId, cenarioAfterUpdate.TopologiaId);
            }
        }

    }
}
