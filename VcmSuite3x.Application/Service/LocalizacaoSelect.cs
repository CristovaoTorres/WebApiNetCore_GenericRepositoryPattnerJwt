using System;
using System.Collections.Generic;
using System.Text;
using VcmSuite3x_api.Core.Repository;
using System.Linq;
using VcmSuite3x.Application.Model;

namespace VcmSuite3x.Application.Service
{
    internal class LocalizacaoSelect
    {
        private readonly UnitOfWork unitOfw = new UnitOfWork();

        public List<Localizacao> Select(Int32 topologiaId)
        {
            //return this.Select("[pr_VCM_LocalizacaoSelect]", "NoId", noId);



            List<Localizacao> localizacaos = (from e in unitOfw.EstadoRepository.Get(y => y.TopologiaId == topologiaId)
                                              select new Localizacao
                                              {
                                                  Id = e.Id,
                                                  Codigo = e.Sigla,
                                                  Descricao = e.Descricao,
                                                  TipoEntidadeId = e.TipoEntidadeId
                                              })
                                    .Concat(
                                            from p in unitOfw.PaisRepository.Get(y => y.TopologiaId == topologiaId)
                                            where p.TopologiaId == topologiaId
                                            select new Localizacao
                                            {
                                                Id = p.Id,
                                                Codigo = p.Codigo,
                                                Descricao = p.Descricao,
                                                TipoEntidadeId = p.TipoEntidadeId

                                            }).ToList();


            return localizacaos;
        }

    }
}
