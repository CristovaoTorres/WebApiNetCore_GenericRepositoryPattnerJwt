using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using VcmSuite3x_api.Core.Models;
using VcmSuite3x_api.Core.Repository;
using VcmSuite3x_api.Models;

namespace TesteVCMSuite3x_Api
{
    [TestClass]
    public class DrawingTest
    {

        private string _baseController = "api/Drawing/";
        ClientCall _clientCall = new ClientCall();
        UnitOfWork _unitOfw = new UnitOfWork();

        [TestMethod]
        public async System.Threading.Tasks.Task List()
        {

            int noId = 0;


            var produtosNo = (from n in _unitOfw.NoRepository.Get()
                              join np in _unitOfw.NoProdutoRepository.Get() on n.Id equals np.NoId
                              join cp in _unitOfw.CorrenteProdutoRepository.Get() on np.ProdutoId equals cp.ProdutoId
                              join c in _unitOfw.CorrenteRepository.Get() on cp.CorrenteId equals c.Id
                              where c.SaidaId == c.Id
                              select new { Noid = n.Id, np.ProdutoId }).ToList().Distinct();





            var produtosSelect = (from p in _unitOfw.ProdutoRepository.Get()
                                  join np in _unitOfw.NoProdutoRepository.Get() on p.Id equals np.NoId
                                  join n in _unitOfw.NoRepository.Get() on np.NoId equals n.Id
                                  join tp in _unitOfw.TipoProdutoRepository.Get() on p.TipoEntidadeId equals tp.Id


                                  join vnp in produtosNo on np.NoId equals vnp.ProdutoId into prods
                                  from x in prods.DefaultIfEmpty()
                                  where n.Id == noId
                                  select new { p.Id, p.Codigo, TipoProdutoNome = tp.Nome, ProdutoCorrente = x.ProdutoId });


            int fluxogramaId = 1;
            HttpResponseMessage response = await _clientCall.Detail(_baseController + "List/" + fluxogramaId);

            Assert.IsTrue(response.IsSuccessStatusCode);
            if (response.IsSuccessStatusCode)
            {
                var retorno = await response.Content.ReadAsStringAsync();

                List<ResponseDrawingA> drawingListFromJson = JsonConvert.DeserializeObject<List<ResponseDrawingA>>(JObject.Parse(retorno)["data"].ToString());
                List<int> noIds = drawingListFromJson.Select(y => y.Key).ToList();

                List<NoDrawing> nodrawingList = _unitOfw.NoDrawingRepository.Get(y => noIds.Contains(y.NoId)).ToList();
                List<No> noList = _unitOfw.NoRepository.Get(y => noIds.Contains(y.Id)).ToList();

                List<int> tipoEntidadeId = noList.Select(y => y.TipoEntidadeId).ToList();
                List<VcmSuite3x_api.Core.Models.TipoEntidade> tipoEntidadeList = _unitOfw.TipoEntidadeRepository.Get(y => tipoEntidadeId.Contains(y.Id)).ToList();

                foreach (var oneNoDrawingFromJson in drawingListFromJson)
                {
                    NoDrawing noDrawing = nodrawingList.Where(y => y.NoId == oneNoDrawingFromJson.Key).FirstOrDefault();
                    Assert.AreEqual(oneNoDrawingFromJson.CoordenadaX, noDrawing.CoordenadaX);
                    Assert.AreEqual(oneNoDrawingFromJson.CoordenadaY, noDrawing.CoordenadaY);
                    Assert.AreEqual(oneNoDrawingFromJson.DiagramaId, noDrawing.FluxogramaId);

                    No no = noList.Where(y => y.Id == oneNoDrawingFromJson.Key).FirstOrDefault();
                    Assert.AreEqual(oneNoDrawingFromJson.Code, no.Codigo);

                    VcmSuite3x_api.Core.Models.TipoEntidade tipoEntidade = tipoEntidadeList.Where(y => y.Id == no.TipoEntidadeId).FirstOrDefault();
                    Assert.AreEqual(oneNoDrawingFromJson.Categoria, tipoEntidade.Prefixo);


                }

            }
        }


        public class ResponseDrawingA
        {
            public string Code { get; set; }
            public int Portas { get; set; }
            public int DiagramaId { get; set; }
            public string Categoria { get; set; }
            public int Key { get; set; }

            public float CoordenadaX { get; set; }
            public float CoordenadaY { get; set; }



        }

    }
}
