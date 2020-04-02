using System;
using System.Collections.Generic;
using System.Text;

namespace VcmSuite3x.Application.Model
{
    public class Localizacao
    {

        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Codigo { get; set; }
        public int TipoEntidadeId { get; set; }
    }
}
