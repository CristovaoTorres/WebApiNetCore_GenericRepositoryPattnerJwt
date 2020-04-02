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
    public class RequestNoDrawingTest
    {
        UnitOfWork _unitOfw = new UnitOfWork();
        ClientCall _clientCall = new ClientCall();
        private string _baseController = "api/NoDrawing/";

        [TestMethod]
        public async System.Threading.Tasks.Task Save()
        {

            RequestNoDrawing noDrawingToBeSave = new RequestNoDrawing
            {
                Categoria = "UA",
                FluxogramaId = 1,
                CoordenadaX = 1254,
                CoordenadaY = 1044,
                Portas = 4,
            };


            HttpResponseMessage response = await _clientCall.Save(_baseController + "Save/", JsonConvert.SerializeObject(noDrawingToBeSave));

            Assert.IsTrue(response.IsSuccessStatusCode);
            if (response.IsSuccessStatusCode)
            {
                var retorno = await response.Content.ReadAsStringAsync();

                RequestNoDrawing noDrawingRetornoJson = JsonConvert.DeserializeObject<RequestNoDrawing>(JObject.Parse(retorno)["data"].ToString());

                NoDrawing noDrawingfterSaveDataBase = _unitOfw.NoDrawingRepository.Get(y => y.NoId == noDrawingRetornoJson.Key).FirstOrDefault();
                No noFromDatabase = _unitOfw.NoRepository.Get(y => y.Id == noDrawingRetornoJson.Key).FirstOrDefault();

                VcmSuite3x_api.Core.Models.TipoEntidade tipoEntidadeFromDatabase = _unitOfw.TipoEntidadeRepository.Get(y => y.Prefixo == noDrawingToBeSave.Categoria).FirstOrDefault();

                Assert.AreEqual(noDrawingRetornoJson.Key, noDrawingfterSaveDataBase.NoId);

                Assert.AreEqual(tipoEntidadeFromDatabase.Id, noFromDatabase.TipoEntidadeId);

                Assert.AreEqual(noDrawingToBeSave.CoordenadaX, noDrawingfterSaveDataBase.CoordenadaX);
                Assert.AreEqual(noDrawingToBeSave.CoordenadaX, noDrawingRetornoJson.CoordenadaX);

                Assert.AreEqual(noDrawingToBeSave.CoordenadaY, noDrawingfterSaveDataBase.CoordenadaY);
                Assert.AreEqual(noDrawingToBeSave.CoordenadaY, noDrawingRetornoJson.CoordenadaY);


                List<PortaDrawing> portas = _unitOfw.PortaDrawingRepository.Get(y => y.NoId == noDrawingRetornoJson.Key).OrderBy(y => y.Index).ToList();

                Assert.AreEqual(noDrawingToBeSave.Portas, portas.Count);
                for (int i = 0; i < portas.Count; i++)
                {
                    Assert.AreEqual(noDrawingToBeSave.FluxogramaId, portas[i].FluxogramaId);
                    Assert.AreEqual(portas[i].Index, i + 1);
                }
            }
        }
    }
}
