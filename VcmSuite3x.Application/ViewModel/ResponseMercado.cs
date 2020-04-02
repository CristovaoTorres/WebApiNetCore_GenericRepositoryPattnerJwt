using System;
using System.Collections.Generic;
using System.Text;

namespace VcmSuite3x.Application.ViewModel
{
    public class MercadoViewModel
    {
        private SelectableEntityViewModel contratos = new SelectableEntityViewModel();
        private SelectableEntityViewModel familias = new SelectableEntityViewModel();
        private ISelectableEntityViewModel<ProdutoNo> items = new SelectableProdutoViewModel();



        private object elementos = new object();
        private Boolean isSpot;



        //public string Codigo { get; set; }
        //public int Id { get; set; }

        public SelectableEntityViewModel Contratos
        {
            get { return this.contratos; }
            set { this.contratos = value; }
        }

        public object Elementos
        {
            get { return this.elementos; }
            set { this.elementos = value; }
        }

        public ISelectableEntityViewModel<ProdutoNo> Items
        {
            get { return this.items; }
            set { this.items = value; }
        }

        public SelectableEntityViewModel Familias
        {
            get { return this.familias; }
            set { this.familias = value; }
        }
        public Boolean IsSpot
        {
            get { return this.isSpot; }
            set { this.isSpot = value; }
        }
    }
}
