using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class Modal
    {
        public Modal()
        {
            Corrente = new HashSet<Corrente>();
            Desconto = new HashSet<Desconto>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Corrente> Corrente { get; set; }
        public ICollection<Desconto> Desconto { get; set; }
    }
}
