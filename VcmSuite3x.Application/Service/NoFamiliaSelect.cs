using System;
using System.Collections.Generic;
using System.Text;
using VcmSuite3x_api.Core.Models;
using VcmSuite3x_api.Core.Repository;
using System.Linq;

namespace VcmSuite3x.Application.Service
{
    public class NoFamiliaSelect
    {

        private readonly UnitOfWork unitOfw = new UnitOfWork();


        public List<Familia> Select(Int32 noId)
        {
            //return this.Select("pr_VCane_NoFamiliaSelect", "NoId", noId);

            List<Familia> familias = (from f in unitOfw.FamiliaRepository.Get()
                                      join nf in unitOfw.NoFamiliaRepository.Get() on f.Id equals nf.FamiliaId
                                      where nf.NoId == noId
                                      select new Familia
                                      {
                                          Id = f.Id,
                                          Codigo = f.Codigo,
                                          Descricao = f.Descricao
                                      }).ToList();


            familias.Add(new Familia
            {
                Id = 1,
                Codigo = "AAA",
                Descricao = "Des",
            });


            return familias;
        }

    }
}
