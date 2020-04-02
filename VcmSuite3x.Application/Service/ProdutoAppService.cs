using System;
using System.Collections.Generic;
using System.Text;
using VcmSuite3x.Application.Interface;
using VcmSuite3x_api.Core.Interface;
using VcmSuite3x_api.Core.Models;

namespace VcmSuite3x.Application.Service
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IUnitOfWork _unitOfw;

        public ProdutoAppService(IUnitOfWork unitOfWork)
        {
            _unitOfw = unitOfWork;
        }

        public Produto Save(int? id, string codigo, string descricao, int UnidadeMedidaId, int topologiaId, int tipoEntidadeId)
        {

            int idNew = id == null ? 0 : (int)id;
            Produto produto = new Produto
            {
                Id = idNew,
                Codigo = codigo,
                Descricao = descricao,
                UnidadeMedidaId = UnidadeMedidaId,
                TopologiaId = topologiaId,
                TipoEntidadeId = tipoEntidadeId
            };
            _unitOfw.ProdutoRepository.AddOrUpdate(produto);
            return produto;
        }
    }
}
