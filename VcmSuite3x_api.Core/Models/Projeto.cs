using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class Projeto
    {
        public Projeto()
        {
            MedidaProjeto = new HashSet<MedidaProjeto>();
            Topologia = new HashSet<Topologia>();
        }
        public Projeto(string name, string note, int cadeiaId)
        {
            this.Nome = name;
            this.Nota = note;
            this.CadeiaId = cadeiaId;

            //this.MedidaProjeto = medidaProjado;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Nota { get; set; }
        public int CadeiaId { get; set; }

        public Cadeia Cadeia { get; set; }
        public ICollection<MedidaProjeto> MedidaProjeto { get; set; }
        public ICollection<Topologia> Topologia { get; set; }
    }
}
