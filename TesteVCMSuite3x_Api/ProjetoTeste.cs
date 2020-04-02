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
    public class ProjetoTeste
    {
        UnitOfWork _unitOfw = new UnitOfWork();
        ClientCall _clientCall = new ClientCall();
        private string _baseController = "api/Projeto/";


        [TestMethod]
        public async System.Threading.Tasks.Task Get()
        {


            HttpResponseMessage response = await _clientCall.Detail(_baseController + "Detail/" + 4010);

            Assert.IsTrue(response.IsSuccessStatusCode);
            if (response.IsSuccessStatusCode)
            {

                var retorno = await response.Content.ReadAsStringAsync();

                ProjetoViewModel projeto = JsonConvert.DeserializeObject<ProjetoViewModel>(JObject.Parse(retorno)["data"].ToString());

                Assert.IsNotNull(projeto);

                Assert.IsNotNull(projeto.UnidadeMedidas);

                List<int> unitIdsFromDB = _unitOfw.MedidaProjetoRepository.Get(y => y.ProjetoId == projeto.Id).Select(y => y.UnidadeMedidaId).ToList();

                List<int> idUnidadesProjetoRetorno = new List<int>();

                //Ids Unidades de Medidas retornados no GET
                foreach (var oneItemsUnidadeMedida in projeto.UnidadeMedidas.Select(y => y.Items))
                    idUnidadesProjetoRetorno.AddRange(oneItemsUnidadeMedida.Where(y => y.Selected == true).Select(y => Convert.ToInt32(y.Value)).ToList());


                //Verifica se os Ids das unidades retornadas estão salvas no banco de acordo com o Projeto
                Assert.IsTrue(idUnidadesProjetoRetorno.Except(unitIdsFromDB).Count() == 0);
                Assert.IsTrue(unitIdsFromDB.Except(idUnidadesProjetoRetorno).Count() == 0);

            }

        }

        [TestMethod]
        public async System.Threading.Tasks.Task Save()
        {

            RequestProjetoSave produtoToBeSave = new RequestProjetoSave
            {
                Nome = "Código + " + DateTime.Now,
                Nota = "Nota" + DateTime.Now,
                UnidadeMedidaId = new List<int> { 2, 6, 10 },
                CadeiaId = 2
            };

            HttpResponseMessage response = await _clientCall.Save(_baseController + "Save/", JsonConvert.SerializeObject(produtoToBeSave));

            Assert.IsTrue(response.IsSuccessStatusCode);
            if (response.IsSuccessStatusCode)
            {
                var retorno = await response.Content.ReadAsStringAsync();

                RequestProjetoSave projetoRetorno = JsonConvert.DeserializeObject<RequestProjetoSave>(JObject.Parse(retorno)["data"].ToString());

                Projeto projetofterSave = _unitOfw.ProjetoRepository.Get(y => y.Id == projetoRetorno.Id).FirstOrDefault();
                List<int> unitIdsFromDB = _unitOfw.MedidaProjetoRepository.Get(y => y.ProjetoId == projetoRetorno.Id).Select(y => y.UnidadeMedidaId).ToList();


                HttpResponseMessage responseProduto = await _clientCall.Detail(_baseController + "Detail/" + projetoRetorno.Id);

                var retornoProjeto = await responseProduto.Content.ReadAsStringAsync();

                ProjetoViewModel projeto = JsonConvert.DeserializeObject<ProjetoViewModel>(JObject.Parse(retornoProjeto)["data"].ToString());

                Assert.AreEqual(produtoToBeSave.Nota, projetofterSave.Nota);
                Assert.AreEqual(produtoToBeSave.Nome, projetofterSave.Nome);
                Assert.AreEqual(produtoToBeSave.CadeiaId, projetofterSave.CadeiaId);

                //Verifica se os Itens da unidade batem
                Assert.IsTrue(produtoToBeSave.UnidadeMedidaId.Except(unitIdsFromDB).Count() == 0);
                Assert.IsTrue(unitIdsFromDB.Except(produtoToBeSave.UnidadeMedidaId).Count() == 0);

            }
        }

        [TestMethod]
        public async System.Threading.Tasks.Task SaveUpdate()
        {

            RequestProjetoSave produtoToBeSave = new RequestProjetoSave
            {
                Nome = "Código + " + DateTime.Now,
                Nota = "Nota" + DateTime.Now,
                UnidadeMedidaId = new List<int> { 2, 6, 10, 11 },
                CadeiaId = 2,
                Id = 4010
            };


            HttpResponseMessage response = await _clientCall.Save(_baseController + "Save/", JsonConvert.SerializeObject(produtoToBeSave));

            Assert.IsTrue(response.IsSuccessStatusCode);
            if (response.IsSuccessStatusCode)
            {
                var retorno = await response.Content.ReadAsStringAsync();

                RequestProjetoSave projetoRetorno = JsonConvert.DeserializeObject<RequestProjetoSave>(JObject.Parse(retorno)["data"].ToString());

                Projeto projetoAfterUpdate = _unitOfw.ProjetoRepository.Get(y => y.Id == produtoToBeSave.Id, null, "MedidaProjeto").FirstOrDefault();


                Assert.AreEqual(produtoToBeSave.Nome, projetoAfterUpdate.Nome);
                Assert.AreEqual(projetoRetorno.Nome, projetoAfterUpdate.Nome);

                Assert.AreEqual(produtoToBeSave.Nota, projetoAfterUpdate.Nota);
                Assert.AreEqual(projetoRetorno.Nota, projetoAfterUpdate.Nota);


                List<int> unitIdsFromDB = projetoAfterUpdate.MedidaProjeto.Select(y => y.UnidadeMedidaId).ToList();

                Assert.IsTrue(produtoToBeSave.UnidadeMedidaId.Except(unitIdsFromDB).Count() == 0);
                Assert.IsTrue(unitIdsFromDB.Except(produtoToBeSave.UnidadeMedidaId).Count() == 0);


            }
        }

        [TestMethod]
        public async System.Threading.Tasks.Task Delete()
        {
            int idProjeto = 6061;

            HttpResponseMessage response = await _clientCall.Delete(_baseController + "Delete/" + idProjeto);

            Assert.IsTrue(response.IsSuccessStatusCode);

            Projeto projetoFromDatabase = _unitOfw.ProjetoRepository.Get(y => y.Id == idProjeto).FirstOrDefault();

            Assert.IsNull(projetoFromDatabase);
        }




    }
}
