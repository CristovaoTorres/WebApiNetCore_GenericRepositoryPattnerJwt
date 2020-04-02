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
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using VcmSuite3x_api.Core;
using VcmSuite3x_api.Core.Models;
using VcmSuite3x_api.Core.Repository;
using VcmSuite3x_api.Models;

namespace TesteVCMSuite3x_Api
{
    [TestClass]
    public class CorrenteDrawingTest
    {
        UnitOfWork _unitOfw = new UnitOfWork();
        ClientCall _clientCall = new ClientCall();
        private readonly string _baseController = "api/CorrenteDrawing/";


        [TestMethod]
        public async System.Threading.Tasks.Task Get()
        {
            HttpResponseMessage response = await _clientCall.Detail(_baseController + "Detail/" + 21);
        }


        [TestMethod]
        public async System.Threading.Tasks.Task Save()
        {
            DiagramLinkModel correnteDrawingToBeSave = new DiagramLinkModel
            {
                From = 33497,
                FromPort = "right",
                To = 33517,
                ToPort = "left",
                Color = "",
                DiagramId = 8095,
                Category = "S",
                Code = "",
                Id = 0

            };

            HttpResponseMessage response = await _clientCall.Save(_baseController + "Save/", JsonConvert.SerializeObject(correnteDrawingToBeSave));

            Assert.IsTrue(response.IsSuccessStatusCode);
            if (response.IsSuccessStatusCode)
            {
                var retorno = await response.Content.ReadAsStringAsync();

                DiagramLinkModel correnteRetornoJson = JsonConvert.DeserializeObject<DiagramLinkModel>(JObject.Parse(retorno)["data"].ToString());


                int tipoEntidadeId = _unitOfw.TipoEntidadeRepository.Get(y => y.Nome == "Corrente").FirstOrDefault().Id;
                Corrente correnteAfterSave = _unitOfw.CorrenteRepository.Get(y => y.Id == correnteRetornoJson.Id).FirstOrDefault();

                //Verifica o insert na tabela Corrente
                Assert.AreEqual(correnteAfterSave.TipoEntidadeId, tipoEntidadeId);
                Assert.AreEqual(correnteAfterSave.Codigo, correnteRetornoJson.Code);
                Assert.AreEqual(correnteAfterSave.SaidaId, correnteDrawingToBeSave.To);
                Assert.AreEqual(correnteAfterSave.EntradaId, correnteDrawingToBeSave.From);


                Enum.TryParse<PortSpot>(correnteDrawingToBeSave.FromPort, true, out PortSpot portaEntradaSpot);
                Enum.TryParse<PortSpot>(correnteDrawingToBeSave.ToPort, true, out PortSpot portaSaidaSpot);

                int portaEntradaIdOut = _unitOfw.PortaDrawingRepository.Get(y => y.NoId == correnteDrawingToBeSave.From && y.FluxogramaId == correnteDrawingToBeSave.DiagramId
                                                                        && y.Index == (Int32)portaEntradaSpot).FirstOrDefault().Id;

                int portaSaidaIdOut = _unitOfw.PortaDrawingRepository.Get(y => y.NoId == correnteDrawingToBeSave.To && y.FluxogramaId == correnteDrawingToBeSave.DiagramId
                                                                       && y.Index == (Int32)portaSaidaSpot).FirstOrDefault().Id;


                //Verifica o Insert na tabela CorrenteDrawing
                CorrenteDrawing correnteDrawing = _unitOfw.CorrenteDrawingRepository.Get(y => y.CorrenteId == correnteRetornoJson.Id).FirstOrDefault();

                Assert.AreEqual(portaSaidaIdOut, correnteDrawing.PortaSaidaId);
                Assert.AreEqual(portaEntradaIdOut, correnteDrawing.PortaEntradaId);
                Assert.AreEqual(correnteDrawing.FluxogramaId, correnteDrawingToBeSave.DiagramId);


                //Cadastro dos produtos do No de Origem na Corrente
                List<int> noProdutoOrigemList = _unitOfw.NoProdutoRepository.Get(y => y.NoId == correnteDrawingToBeSave.From)
                                                             .Select(y => y.ProdutoId).ToList();

                foreach (var oneProdutoCorrente in noProdutoOrigemList)
                {
                    CorrenteProduto correnteProduto = _unitOfw.CorrenteProdutoRepository.Get(y => y.ProdutoId == oneProdutoCorrente
                                                                        && y.CorrenteId == correnteRetornoJson.Id).FirstOrDefault();

                    Assert.IsNotNull(correnteProduto);
                }


                //Produtos do No de origem devem estar cadastrados no No de destino

                //noProdutos origem
                List<int> noProdutosOrigemList = _unitOfw.NoProdutoRepository.Get(y => y.NoId == correnteDrawingToBeSave.From).Select(y => y.ProdutoId).ToList();

                //noProdudos Destino
                List<int> noProdutosDestinoList = _unitOfw.NoProdutoRepository.Get(y => y.NoId == correnteDrawingToBeSave.To).Select(y => y.ProdutoId).ToList();

                //Verifica se algum produto não existe no destino
                List<int> dups = noProdutosOrigemList.Except(noProdutosDestinoList).ToList();

                Assert.AreEqual(0, dups.Count());


            }
        }


    }
}
