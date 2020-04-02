using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class FuncaoObjetivo
    {
        public int Id { get; set; }
        public int Valor { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int CadeiaId { get; set; }

        public Cadeia Cadeia { get; set; }
    }
}
