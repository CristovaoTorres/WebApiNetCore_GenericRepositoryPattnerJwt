using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VcmSuite3x.Application.ViewModel;
using VcmSuite3x_api.Core.Models;
using VcmSuite3x_api.Core.Repository;

namespace VcmSuite3x.Application.Service
{
    internal class NoFamiliaProdutoSelect
    {

        private readonly UnitOfWork unitOfw = new UnitOfWork();

        public List<ProdutoNo> Select(int noId)
        {
            // Procedure [pr_VCane_NoFamiliaProdutoSelect]

            List<Produto> produtoNoList = (from p in unitOfw.ProdutoRepository.Get()
                                           join pf in unitOfw.ProdutoFamiliaRepository.Get()
                                         on p.Id equals pf.ProdutoId

                                           join nf in unitOfw.NoFamiliaRepository.Get()
                                           on pf.FamiliaId equals nf.FamiliaId

                                           join tp in unitOfw.TipoProdutoRepository.Get()
                                           on p.TipoEntidadeId equals tp.Id


                                           where nf.NoId == noId
                                           select new Produto
                                           {
                                               Id = p.Id,
                                               Codigo = p.Codigo,
                                               Descricao = p.Descricao,
                                               TipoEntidadeId = p.TipoEntidadeId,
                                               UnidadeMedidaId = p.UnidadeMedidaId,
                                               TipoProdutoNome = tp.Nome

                                           }).ToList();

            return new List<ProdutoNo>();
        }
    }
}
