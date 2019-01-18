using System;
using System.Collections.Generic;

namespace WebApiNetCore_GenericRepositoryPattnerJwt.Core.Models
{
    public partial class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Nota { get; set; }
        public string Email { get; set; }
    }
}
