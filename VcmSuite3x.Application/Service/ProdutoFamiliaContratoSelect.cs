using System;
using System.Collections.Generic;
using System.Text;
using VcmSuite3x_api.Core.Models;
using VcmSuite3x_api.Core.Repository;
using System.Linq;

namespace VcmSuite3x.Application.Service
{
    internal class ProdutoFamiliaContratoSelect
    {
        private readonly UnitOfWork unitOfw = new UnitOfWork();

        public List<Produto> Select(Int32 contratoId)
        {
            //database.SetCommand("pr_VCane_ProdutoFamiliaContratoSelect", CommandType.StoredProcedure);database.AddInParameter("ContratoId", contratoId);

            List<Produto> produtos = (from p in unitOfw.ProdutoRepository.Get()
                                      join tp in unitOfw.TipoProdutoRepository.Get() on p.TipoEntidadeId equals tp.Id
                                      join fp in unitOfw.ProdutoFamiliaRepository.Get() on p.Id equals fp.ProdutoId
                                      join fc in unitOfw.FamiliaContratoRepository.Get() on fp.FamiliaId equals fc.FamiliaId

                                      where fc.ContratoId == contratoId
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
