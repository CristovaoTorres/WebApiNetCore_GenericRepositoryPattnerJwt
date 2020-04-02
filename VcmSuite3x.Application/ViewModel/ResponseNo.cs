using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace VcmSuite3x.Application.ViewModel
{
    public class NoViewModel
    {

        private object elementos = new object();

        private ISelectableEntityViewModel<ProdutoNo> items = new SelectableProdutoViewModel();
        private IEnumerable<SelectListItem> localizacoes;

        public ISelectableEntityViewModel<ProdutoNo> Items
        {
            get { return this.items; }
            set { this.items = value; }
        }
        public object Elementos
        {
            get { return this.elementos; }
            set { this.elementos = value; }
        }

        public IEnumerable<SelectListItem> Localizacoes
        {
            get { return this.localizacoes; }
            set
            {
                if (value == null)
                    this.localizacoes = new List<SelectListItem>();

                else
                    this.localizacoes = value;

            }
        }
    }

    public class ProdutoNo
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string TipoProdutoNome { get; set; }
    }


    public class NoModel
    {
        public string Descricao { get; set; }
        public string Codigo { get; set; }
        public int Id { get; set; }
        public int TipoEntidadeId { get; set; }
        public int TopologiaId { get; set; }
        public string Nota { get; set; }
        public bool IsConector { get; set; }
        public string Localizacao { get; set; }
        public bool IsFornecimento { get; set; }
        //public TipoEntidade TipoEntidade { get; set; }
    }


    //public class TipoEntidade
    //{
    //    public int Id { get; set; }
    //    public string Nome { get; set; }
    //    public string Prefixo { get; set; }

    //}
}
