using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class Cadeia
    {
        public Cadeia()
        {
            FuncaoObjetivo = new HashSet<FuncaoObjetivo>();
            MedidaCadeia = new HashSet<MedidaCadeia>();
            Projeto = new HashSet<Projeto>();
            Propriedade = new HashSet<Propriedade>();
            Simbolo = new HashSet<Simbolo>();
            TemplateMedida = new HashSet<TemplateMedida>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<FuncaoObjetivo> FuncaoObjetivo { get; set; }
        public ICollection<MedidaCadeia> MedidaCadeia { get; set; }
        public ICollection<Projeto> Projeto { get; set; }
        public ICollection<Propriedade> Propriedade { get; set; }
        public ICollection<Simbolo> Simbolo { get; set; }
        public ICollection<TemplateMedida> TemplateMedida { get; set; }
    }
}
