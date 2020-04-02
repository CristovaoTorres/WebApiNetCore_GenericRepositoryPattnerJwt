using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VcmSuite3x.Application.Interface;
using VcmSuite3x.Application.ViewModel;
using VcmSuite3x_api.Core.Interface;
using VcmSuite3x_api.Core.Models;

namespace VcmSuite3x.Application.Service
{
    public class MercadoAppService : IMercadoAppService
    {
        private readonly IUnitOfWork _unitOfw;

        public MercadoAppService(IUnitOfWork unitOfWork)
        {
            _unitOfw = unitOfWork;
        }

        public MercadoCenario MercadoCenarioFind(int elementoId, int cenarioId)
        {
            //pr_VCane_MercadoCenarioFind

            string codigo = _unitOfw.NoRepository.Get(y => y.Id == elementoId).FirstOrDefault()?.Codigo;

            if (!string.IsNullOrEmpty(codigo))
            {
                MercadoCenario mercadoCenario = _unitOfw.MercadoCenarioRepository.Get(y => y.NoId == elementoId && y.CenarioId == cenarioId).FirstOrDefault();
                mercadoCenario.IsSpot = _unitOfw.MercadoContratoRepository.Count(y => y.MercadoId == mercadoCenario.NoId) > 0;

                if (mercadoCenario == null)
                {
                    int tipoDemandaId = _unitOfw.TipoDemandaRepository.Get(y => y.Nome == "Produto").FirstOrDefault().Id;

                    _unitOfw.MercadoCenarioRepository.Insert(new MercadoCenario
                    {
                        NoId = elementoId,
                        CenarioId = cenarioId,
                        TipoDemandaId = tipoDemandaId,
                        IncluirCalculoImpostos = false
                    });
                }
                return mercadoCenario;
            }

            return null;
        }



        public MercadoCenario MercadoCenarioFindByCodigo(string codigo, int cenarioId)
        {
            //pr_VCane_MercadoCenarioFindByCodigo
            MercadoCenario mercadoCenario = new MercadoCenario();

            int tipoEntidadeMercado = _unitOfw.TipoEntidadeRepository.Get(y => y.Nome == "Mercado").FirstOrDefault().Id;

            var elementoId = (from n in _unitOfw.NoRepository.Get(y => y.Codigo == codigo && y.TipoEntidadeId == tipoEntidadeMercado)
                              join c in _unitOfw.CenarioRepository.Get(y => y.Id == cenarioId) on n.TopologiaId equals c.TopologiaId
                              select n.Id).FirstOrDefault();

            if (elementoId > 0)
                mercadoCenario = MercadoCenarioFind(elementoId, cenarioId);

            return mercadoCenario;
        }
        public MercadoViewModel Find(int topologiaId, int noId, IMapper _mapper)
        {

            NoViewModel bo = new NoAppService(_unitOfw).Create(noId, topologiaId, _mapper);
            //No no = _unitOfw.NoRepository.Get(y => y.Id == noId).FirstOrDefault();

            MercadoViewModel model = new MercadoViewModel
            {
                Familias = new SelectableEntityViewModel()
                {
                    Available = new FamiliaSelect().Select(topologiaId),
                    Selected = new NoFamiliaSelect().Select(noId)
                },

                Items = bo.Items,
                Elementos = bo.Elementos
            };

            // Produtos cadastrados no No
            List<string> produtoList = new NoProdutoSelect().Select(noId, _mapper).Select(p => p.Codigo).ToList();
            // + Produtos pertencentes as familias cadastradas no No. (As familias são selecionadas nas correntes de entrada)
            produtoList.AddRange(new NoFamiliaProdutoSelect().Select(noId).Select(p => p.Codigo).ToList());


            // Seleção dos Contratos que não sejam "Take Or Pay"
            model.Contratos = new SelectableEntityViewModel()
            {
                Available = new ContratoSelect().Select(topologiaId).Where(c => c.TipoEntidadeNome != "Take Or Pay" &&
                                                                           (new ProdutoContratoSelect().Select(c.Id).Where(p => produtoList.Contains(p.Codigo)).Count() > 0 ||
                                                                            new ProdutoFamiliaContratoSelect().Select(c.Id).Where(p => produtoList.Contains(p.Codigo)).Count() > 0)),
                Selected = new MercadoContratoSelect().Select(noId)
            };

            model.IsSpot = (model.Contratos.Selected.Count() == 0);

            return model;
        }

    }
}
