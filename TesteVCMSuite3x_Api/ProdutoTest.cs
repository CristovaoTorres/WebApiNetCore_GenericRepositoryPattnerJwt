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
    public class ProdutoTest
    {
        private string _baseController = "api/Produto/";
        ClientCall _clientCall = new ClientCall();
        UnitOfWork _unitOfw = new UnitOfWork();


        [TestMethod]
        public async System.Threading.Tasks.Task Get()
        {
            int idProduto = 1;

            HttpResponseMessage response = await _clientCall.Detail(_baseController + "Detail/" + idProduto);

            Assert.IsTrue(response.IsSuccessStatusCode);
            if (response.IsSuccessStatusCode)
            {
                var retorno = await response.Content.ReadAsStringAsync();

                ResponseProduto produto = JsonConvert.DeserializeObject<ResponseProduto>(JObject.Parse(retorno)["data"].ToString());

                Assert.IsNotNull(produto);
                Assert.AreEqual(Convert.ToInt32(idProduto), Convert.ToInt32(produto.Id));

                Assert.IsNotNull(produto.UnidadesMedida);

                foreach (var oneUnidadeMedida in produto.UnidadesMedida)
                {

                    Assert.IsNotNull(oneUnidadeMedida.Value);
                    Assert.IsNotNull(oneUnidadeMedida.Text);
                    Assert.IsNotNull(oneUnidadeMedida.Selected);

                    if (oneUnidadeMedida.Value == produto.UnidadeMedidaId.ToString())
                        Assert.IsTrue(oneUnidadeMedida.Selected);

                    else
                        Assert.IsFalse(oneUnidadeMedida.Selected);
                }
            }
        }


        [TestMethod]
        public async System.Threading.Tasks.Task List()
        {

            int idTopologia = 4015;
            HttpResponseMessage response = await _clientCall.Detail(_baseController + "List/" + idTopologia);

            Assert.IsTrue(response.IsSuccessStatusCode);
            if (response.IsSuccessStatusCode)
            {
                var retorno = await response.Content.ReadAsStringAsync();

                List<ResponseProduto> produtoList = JsonConvert.DeserializeObject<List<ResponseProduto>>(JObject.Parse(retorno)["data"].ToString());

                Assert.IsNotNull(produtoList);

                foreach (var oneProdutoLit in produtoList)
                    Assert.AreEqual(idTopologia, oneProdutoLit.TopologiaId);

            }
        }

        [TestMethod]
        public async System.Threading.Tasks.Task Delete()
        {
            int idProduto = 3041;


            HttpResponseMessage response = await _clientCall.Delete(_baseController + "Delete/" + idProduto);

            Assert.IsTrue(response.IsSuccessStatusCode);

            Produto produtoGet = _unitOfw.ProdutoRepository.Get(y => y.Id == idProduto).FirstOrDefault();

            Assert.IsNull(produtoGet);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task Save()
        {

            try
            {
                RequestProdutoSave produtoToBeSave = new RequestProdutoSave
                {
                    Codigo = "Código + " + DateTime.Now,
                    Descricao = "Insert" + DateTime.Now,
                    TopologiaId = 1,
                    TipoEntidadeId = 232,
                    UnidadeMedidaId = 23,
                    Id = null
                };


                HttpResponseMessage response = await _clientCall.Save(_baseController + "Save/", JsonConvert.SerializeObject(produtoToBeSave));

                Assert.IsTrue(response.IsSuccessStatusCode);
                if (response.IsSuccessStatusCode)
                {
                    var retorno = await response.Content.ReadAsStringAsync();

                    ResponseProduto produtoRetorno = JsonConvert.DeserializeObject<ResponseProduto>(JObject.Parse(retorno)["data"].ToString());

                    Produto produtoFromDataBasefterSave = _unitOfw.ProdutoRepository.Get(y => y.Id == produtoRetorno.Id).FirstOrDefault();

                    Assert.AreEqual(produtoToBeSave.Descricao, produtoFromDataBasefterSave.Descricao);

                    Assert.AreEqual(produtoToBeSave.TopologiaId, produtoFromDataBasefterSave.TopologiaId);
                    Assert.AreEqual(produtoToBeSave.TipoEntidadeId, produtoFromDataBasefterSave.TipoEntidadeId);
                    Assert.AreEqual(produtoToBeSave.UnidadeMedidaId, produtoFromDataBasefterSave.UnidadeMedidaId);
                    Assert.AreEqual(produtoToBeSave.Codigo, produtoFromDataBasefterSave.Codigo);
                    Assert.AreEqual(produtoToBeSave.Descricao, produtoFromDataBasefterSave.Descricao);

                    HttpResponseMessage responseProduto = await _clientCall.Detail(_baseController + "Detail/" + produtoRetorno.Id);

                    var retornoProduto = await responseProduto.Content.ReadAsStringAsync();

                    ResponseProduto produto = JsonConvert.DeserializeObject<ResponseProduto>(JObject.Parse(retornoProduto)["data"].ToString());

                    foreach (var item in produto.UnidadesMedida)
                    {
                        if (item.Value == produtoToBeSave.UnidadeMedidaId.ToString())
                            Assert.IsTrue(item.Selected);
                    }

                    Assert.AreEqual(produto.TipoEntidadeId, produtoToBeSave.TipoEntidadeId);
                }
            }
            catch (Exception ex)
            {
                throw;
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
