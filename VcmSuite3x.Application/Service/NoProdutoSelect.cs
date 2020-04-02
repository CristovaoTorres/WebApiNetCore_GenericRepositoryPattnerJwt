using System;
using System.Collections.Generic;
using System.Text;
using VcmSuite3x.Application.ViewModel;
using VcmSuite3x_api.Core.Repository;
using System.Linq;
using AutoMapper;

namespace VcmSuite3x.Application.Service
{
    internal class NoProdutoSelect
    {
        #region Properties
        private readonly UnitOfWork unitOfw = new UnitOfWork();


        #endregion

        public List<ProdutoNo> Select(Int32 noId, IMapper _mapper)
        {
            #region
            ////return this.Select("pr_VCM_NoProdutoSelect", "NoId", noId);
            //var leftJoidsn = (from n in unitOfw.NoRepository.Get()
            //                  join np in unitOfw.NoProdutoRepository.Get() on n.Id equals np.NoId
            //                  join cp in unitOfw.CorrenteProdutoRepository.Get() on np.ProdutoId equals cp.ProdutoId
            //                  join c in unitOfw.CorrenteRepository.Get() on cp.CorrenteId equals c.Id
            //                  select new
            //                  {
            //                      NoId = n.Id,
            //                      np.ProdutoId
            //                  }).Distinct();


            //List<ProdutoNo> produtos = (from p in unitOfw.ProdutoRepository.Get()
            //                            join np in unitOfw.NoProdutoRepository.Get() on p.Id equals np.ProdutoId
            //                            join n in unitOfw.NoRepository.Get() on np.NoId equals n.Id
            //                            join tp in unitOfw.TipoProdutoRepository.Get() on p.TipoEntidadeId equals tp.Id


            //                            join vnp in leftJoidsn on new { id = np.NoId, p = np.ProdutoId } equals new { id = vnp.NoId, p = vnp.ProdutoId }
            //                                         into listaT
            //                            from fd in listaT.DefaultIfEmpty()
            //                            where n.Id == noId
            //                            select new ProdutoNo
            //                            {
            //                                Id = p.Id,
            //                                Codigo = p.Codigo,
            //                                Descricao = p.Descricao,
            //                                //Produito fd.ProdutoId
            //                            }).ToList();


            #endregion


            //Possivel erro aqui, Estou retornando agora o ProdutoCorrente, isso pode da ruim no mapper, verificar os commit caso de problema (31/05/2019)
            List<ProdutoNo> produtos = _mapper.Map<List<ProdutoNo>>(unitOfw.GetProdutoNo(noId));


            return produtos;
        }

        public List<ProdutoNo> Select(Int32 topologiaId, Int32 tipoEntidadeId)
        {

            //pr_VCM_NoProdutoSelectByTipoEntidade
            List<ProdutoNo> produtos = (from p in unitOfw.ProdutoRepository.Get()
                                        join etp in unitOfw.ElementoTipoProdutoRepository.Get() on p.TipoEntidadeId equals etp.TipoProdutoId
                                        join tp in unitOfw.TipoProdutoRepository.Get() on etp.TipoProdutoId equals tp.Id
                                        where p.TopologiaId == topologiaId && etp.TipoEntidadeId == tipoEntidadeId
                                        select new ProdutoNo
                                        {
                                            Id = p.Id,
                                            Codigo = p.Codigo,
                                            Descricao = p.Descricao,
                                            TipoProdutoNome = tp.Nome
                                        }).ToList();



            return produtos;
        }

    }
}
