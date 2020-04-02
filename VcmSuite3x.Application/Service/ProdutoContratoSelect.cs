using System;
using System.Collections.Generic;
using System.Text;
using VcmSuite3x_api.Core.Models;
using VcmSuite3x_api.Core.Repository;
using System.Linq;

namespace VcmSuite3x.Application.Service
{
    internal class ProdutoContratoSelect
    {

        private readonly UnitOfWork unitOfw = new UnitOfWork();


        public List<Produto> Select(Int32 contratoId)
        {
            //"pr_VCane_ProdutoContratoSelect", CommandType.StoredProcedure); database.AddInParameter("ContratoId", contratoId);


            //Todo verificar essa consulta p.tipoentidade == tp.id ???
            List<Produto> produtos = (from p in unitOfw.ProdutoRepository.Get()
                                      join tp in unitOfw.TipoProdutoRepository.Get()
                                    on p.TipoEntidadeId equals tp.Id

                                      join pc in unitOfw.ProdutoContratoRepository.Get()
                                      on p.Id equals pc.ProdutoId

                                      where pc.ContratoId == contratoId
                                      select new Produto
                                      {
                                          Id = p.Id,
                                          Codigo = p.Codigo,
                                          Descricao = p.Descricao,
                                          TipoEntidadeId = p.TipoEntidadeId,
                                          UnidadeMedidaId = p.UnidadeMedidaId,
                                          TipoProdutoNome = tp.Nome
                                      }).ToList();

            return produtos;


        }



    }
}
