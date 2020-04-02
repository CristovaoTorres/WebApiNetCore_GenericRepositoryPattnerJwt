//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using VcmSuite3x_api.Core.Interface;
//using VcmSuite3x_api.Core.Models;
//using VcmSuite3x_api.Core.Repository;

//namespace VcmSuite3x_api.Business
//{
//    internal class FamiliaSelect
//    {

//        private readonly UnitOfWork unitOfw = new UnitOfWork();


//        public List<Familia> Select(int topologiaId)
//        {

//            //return this.Select("pr_VCane_FamiliaSelect", "TopologiaId", topologiaId);

//            List<Familia> familias = (from f in unitOfw.FamiliaRepository.Get(y => y.TopologiaId == topologiaId, null, "TipoProdutoRepository")
//                                          //join tp in unitOfw.TipoProdutoRepository.Get() on f.TipoProdutoId equals tp.Id
//                                      where f.TopologiaId == topologiaId
//                                      select new Familia
//                                      {
//                                          Id = f.Id,
//                                          Codigo = f.Codigo,
//                                          TipoProdutoId = f.TipoProdutoId,
//                                          TipoProdutoNome = f.TipoProduto.Nome
//                                      }).ToList();

//            familias.Add(new Familia
//            {
//                Id = 1,
//                Codigo = "AAA",
//                TipoProdutoId = 2,
//                TipoProdutoNome = "Nome"
//            });

//            return familias;
//        }
//    }
//}
