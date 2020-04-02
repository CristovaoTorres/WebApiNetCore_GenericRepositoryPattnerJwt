using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using VcmSuite3x_api.Core.Models;
using VcmSuite3x_api.Core.Repository;

namespace VcmSuite3x.Application.Service
{
    internal class ContratoSelect
    {

        private readonly UnitOfWork unitOfw = new UnitOfWork();

        public List<Contrato> Select(int topologiaId)
        {
            //[pr_VCane_ContratoSelect]
            List<Contrato> contratos = (from c in unitOfw.ContratoRepository.Get()
                                        join te in unitOfw.TipoEntidadeRepository.Get()
                                      on c.TipoEntidadeId equals te.Id

                                        join tp in unitOfw.TipoProdutoRepository.Get()
                                        on c.TipoProdutoId equals tp.Id
                                        into de
                                        from j in de.DefaultIfEmpty()

                                        where c.TopologiaId == topologiaId
                                        select new Contrato
                                        {
                                            Id = c.Id,
                                            Codigo = c.Codigo,
                                            Descricao = c.Descricao,
                                            TipoEntidadeNome = te.Nome,
                                            TipoProdutoNome = j.Nome
                                        }).ToList();

            return contratos;
        }
    }
}
