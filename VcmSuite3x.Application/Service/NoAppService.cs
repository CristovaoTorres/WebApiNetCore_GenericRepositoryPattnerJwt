using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using VcmSuite3x.Application.Interface;
using VcmSuite3x.Application.Model;
using VcmSuite3x.Application.ViewModel;
using VcmSuite3x_api.Core.Interface;
using VcmSuite3x_api.Core.Models;
using VcmSuite3x_api.Core.Repository;

namespace VcmSuite3x.Application.Service
{
    public class NoAppService : INoAppService
    {
        private readonly IUnitOfWork _unitOfw;

        public NoAppService(IUnitOfWork unitOfWork)
        {
            _unitOfw = unitOfWork;
        }

        public NoViewModel Create(int id, int topologiaId, IMapper _mapper)
        {

            No no = _unitOfw.NoRepository.Get(y => y.Id == id, null, "TipoEntidade").FirstOrDefault();
            //No noElemento = _unitOfw.NoRepository.Get(y => y.Id == id).FirstOrDefault();

            no.IsFornecimento = Regex.IsMatch(no.TipoEntidade.Nome, "(Armazenamento|Fornecimento|Porto)", RegexOptions.IgnoreCase);
            no.IsConector = Regex.IsMatch(no.TipoEntidade.Nome, "(Divisor|Unificador)", RegexOptions.IgnoreCase);

            NoViewModel noViewModel = _mapper.Map<NoViewModel>(no);
            NoModel noModel = _mapper.Map<NoModel>(no);

            List<ProdutoNo> produtos = no.Id > 0 ? (no.IsConector ? new ConectorProdutoSelect().Select(no.Id, _unitOfw) : new NoProdutoSelect().Select(no.Id, _mapper)) : new List<ProdutoNo>();

            noViewModel.Items = new SelectableProdutoViewModel()
            {
                Available = (no.IsConector ? produtos : GetProdutos(no, produtos)),
                Selected = produtos,
            };

            noViewModel.Elementos = noModel;

            if (!noModel.IsConector)
            {
                IEnumerable<SelectListItem> localizacoes;
                IEnumerable<Localizacao> localizacaoSelect = new LocalizacaoSelect().Select(topologiaId);

                localizacoes = localizacaoSelect.Select(l =>
                {
                    return new SelectListItem()
                    {
                        Selected = (l.Codigo == no.Localizacao),
                        Text = l.Descricao,
                        Value = l.Codigo,
                    };
                });

                noViewModel.Localizacoes = localizacoes;
            }
            return noViewModel;
        }

        private List<ProdutoNo> GetProdutos(No no, List<ProdutoNo> selecionados)
        {
            List<ProdutoNo> disponiveis = new List<ProdutoNo>(selecionados);

            List<ProdutoNo> produtos = (no.IsFornecimento ? new NoProdutoSelect().Select(no.TopologiaId, no.TipoEntidadeId) : new ConectorProdutoSelect().Select(no.Id, _unitOfw));

            IEnumerable<String> produtosSelecionados = selecionados.Select(p => p.Codigo);
            disponiveis.AddRange(produtos.Where(p => !produtosSelecionados.Contains(p.Codigo))/*.Select(p => ProdutoNo.Create(p))*/);

            return disponiveis.OrderBy(p => p.Codigo).ToList();
        }
    }
}
