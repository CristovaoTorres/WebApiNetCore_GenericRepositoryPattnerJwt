using System;
using System.Collections.Generic;
using System.Text;
using VcmSuite3x.Application.ViewModel;
using VcmSuite3x_api.Core.Interface;
using System.Linq;

namespace VcmSuite3x.Application.Service
{
    internal class ConectorProdutoSelect
    {
        public List<ProdutoNo> Select(int noId, IUnitOfWork _unitOfWork)
        {
            // Procedure [pr_VCM_ConectorProdutoSelect]

            List<ProdutoNo> produtoNoList = (from p in _unitOfWork.ProdutoRepository.Get()
                                             join cp in _unitOfWork.CorrenteProdutoRepository.Get()
                                           on p.Id equals cp.ProdutoId

                                             join c in _unitOfWork.CorrenteRepository.Get()
                                             on cp.CorrenteId equals c.Id

                                             join tp in _unitOfWork.TipoProdutoRepository.Get()
                                             on p.TipoEntidadeId equals tp.Id
                                             where c.SaidaId == noId
                                             //where  /*out sempre enviado como false para procedure */ _out == false ? (c.EntradaId == noId) : (c.SaidaId == noId)
                                             select new ProdutoNo
                                             {
                                                 Id = p.Id,
                                                 Codigo = p.Codigo,
                                                 Descricao = p.Descricao
                                             }).ToList();

            return produtoNoList;
        }
    }
}
