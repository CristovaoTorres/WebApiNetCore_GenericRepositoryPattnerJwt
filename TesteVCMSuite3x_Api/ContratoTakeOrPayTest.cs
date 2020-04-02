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
using VcmSuite3x_api.Core.Models;
using VcmSuite3x_api.Core.Repository;
using VcmSuite3x_api.Models;

namespace TesteVCMSuite3x_Api
{
    [TestClass]
    public class ContratoTakeOrPayTest
    {
        UnitOfWork _unitOfw = new UnitOfWork();
        ClientCall _clientCall = new ClientCall();
        private string _baseController = "api/ContratoTakeOrpay/";



        [TestMethod]
        public async System.Threading.Tasks.Task Get()
        {
            int portaSaidaId = 33504;
            int portaEntradaId = 33497;

            var noIdDestino = from p in _unitOfw.NoProdutoRepository.Get()
                              join f in _unitOfw.NoProdutoRepository.Get() on p.ProdutoId equals f.ProdutoId into fg
                              from fgi in (from f in fg
                                           where f.NoId == portaSaidaId
                                           select f).DefaultIfEmpty()
                              where p.NoId == portaEntradaId && fgi.NoId == null
                              select new { NoId = 0, ProdudoId = p.ProdutoId };


            List<produtos> list = noIdDestino.Select(x => new produtos
            {
                NoId = x.NoId,
                ProdudoId = x.ProdudoId
            }).ToList();

            foreach (var item in list)
            {
               var aa =  item.NoId;
            }


            Contrato contrato = _unitOfw.ContratoRepository.Get().ToList().FirstOrDefault();

            HttpResponseMessage response = await _clientCall.Detail(_baseController + "Detail/" + contrato.Id);

            Assert.IsTrue(response.IsSuccessStatusCode);
            if (response.IsSuccessStatusCode)
            {
                var retorno = await response.Content.ReadAsStringAsync();

                RequestContratoTakeOrplay contratoFromJson = JsonConvert.DeserializeObject<RequestContratoTakeOrplay>(JObject.Parse(retorno)["data"].ToString());


                Assert.IsNotNull(contrato);
                Assert.AreEqual(contrato.Id, contratoFromJson.Id.Value);

                Assert.AreEqual(contrato.Codigo, contratoFromJson.Codigo);
                Assert.AreEqual(contrato.Descricao, contratoFromJson.Descricao);
                Assert.AreEqual(contrato.TipoEntidadeId, contratoFromJson.TipoEntidadeId);
                Assert.AreEqual(contrato.TopologiaId, contratoFromJson.TopologiaId);


            }
        }


        public class produtos
        {
            public int ProdudoId { get; set; }
            public int NoId { get; set; }
        }

        [TestMethod]
        public async System.Threading.Tasks.Task List()
        {

            int idTopologia = 1;
            HttpResponseMessage response = await _clientCall.Detail(_baseController + "List/" + idTopologia);

            Assert.IsTrue(response.IsSuccessStatusCode);
            if (response.IsSuccessStatusCode)
            {
                var retorno = await response.Content.ReadAsStringAsync();

                List<PeriodoViewModel> periodoList = JsonConvert.DeserializeObject<List<PeriodoViewModel>>(JObject.Parse(retorno)["data"].ToString());

                Assert.IsNotNull(periodoList);

                foreach (var oneProdutoLit in periodoList)
                    Assert.AreEqual(idTopologia, oneProdutoLit.TopologiaId);

            }
        }

        [TestMethod]
        public async System.Threading.Tasks.Task Delete()
        {
            int idContrato = 1049;


            HttpResponseMessage response = await _clientCall.Delete(_baseController + "Delete/" + idContrato);

            Assert.IsTrue(response.IsSuccessStatusCode);

            Contrato Contrato = _unitOfw.ContratoRepository.Get(y => y.Id == idContrato).FirstOrDefault();

            Assert.IsNull(Contrato);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task Save()
        {

            RequestContratoTakeOrplay contratoToBeSave = new RequestContratoTakeOrplay
            {
                Codigo = "Código + " + DateTime.Now.ToString("ddMMyyy HHmmss"),
                Descricao = "Descricao" + DateTime.Now.ToString("ddMMyyy HHmmss"),
                TopologiaId = 1,
                TipoEntidadeId = 203,
                Id = null
            };


            HttpResponseMessage response = await _clientCall.Save(_baseController + "Save/", JsonConvert.SerializeObject(contratoToBeSave));

            Assert.IsTrue(response.IsSuccessStatusCode);
            if (response.IsSuccessStatusCode)
            {
                var retorno = await response.Content.ReadAsStringAsync();

                RequestContratoTakeOrplay contratoRetornoJson = JsonConvert.DeserializeObject<RequestContratoTakeOrplay>(JObject.Parse(retorno)["data"].ToString());

                Contrato produtoFromDataBasefterSave = _unitOfw.ContratoRepository.Get(y => y.Id == contratoRetornoJson.Id).FirstOrDefault();

                Assert.AreEqual(contratoToBeSave.Descricao, produtoFromDataBasefterSave.Descricao);

                Assert.AreEqual(contratoToBeSave.TopologiaId, produtoFromDataBasefterSave.TopologiaId);
                Assert.AreEqual(contratoToBeSave.TipoEntidadeId, produtoFromDataBasefterSave.TipoEntidadeId);
                Assert.AreEqual(contratoToBeSave.Codigo, produtoFromDataBasefterSave.Codigo);

            }
        }

        [TestMethod]
        public async System.Threading.Tasks.Task SaveUpdate()
        {

            RequestProdutoSave produtoToBeSave = new RequestProdutoSave
            {
                Codigo = "Código + " + DateTime.Now,
                Descricao = "Insert" + DateTime.Now,
                UnidadeMedidaId = 23,
                Id = 3041,
                TopologiaId = 4015, /*Não deve ser alterado, deixar igual produto que já consta no banco*/
                TipoEntidadeId = 230 /*Não deve ser alterado,  deixar igual produto que já consta no banco*/
            };


            HttpResponseMessage response = await _clientCall.Save(_baseController + "Save/", JsonConvert.SerializeObject(produtoToBeSave));

            Assert.IsTrue(response.IsSuccessStatusCode);
            if (response.IsSuccessStatusCode)
            {
                var retorno = await response.Content.ReadAsStringAsync();

                RequestProdutoSave produtoRetorno = JsonConvert.DeserializeObject<RequestProdutoSave>(JObject.Parse(retorno)["data"].ToString());

                Produto produtoAfterUpdate = _unitOfw.ProdutoRepository.Get(y => y.Id == produtoToBeSave.Id).FirstOrDefault();


                Assert.AreEqual(produtoToBeSave.Codigo, produtoAfterUpdate.Codigo);
                Assert.AreEqual(produtoRetorno.Codigo, produtoAfterUpdate.Codigo);

                Assert.AreEqual(produtoToBeSave.TopologiaId, produtoAfterUpdate.TopologiaId);
                Assert.AreEqual(produtoRetorno.TopologiaId, produtoAfterUpdate.TopologiaId);

                Assert.AreEqual(produtoToBeSave.TipoEntidadeId, produtoAfterUpdate.TipoEntidadeId);
                Assert.AreEqual(produtoRetorno.TipoEntidadeId, produtoAfterUpdate.TipoEntidadeId);

                Assert.AreEqual(produtoToBeSave.UnidadeMedidaId, produtoAfterUpdate.UnidadeMedidaId);
                Assert.AreEqual(produtoRetorno.UnidadeMedidaId, produtoAfterUpdate.UnidadeMedidaId);

            }
        }

    }
}
