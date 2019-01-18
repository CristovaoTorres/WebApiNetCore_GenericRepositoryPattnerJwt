using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiNetCore_GenericRepositoryPattnerJwt.Models
{
    public class RequestAluno
    {

        [Required]
        public string Nome { get; set; }

        [Required]
        public decimal Nota { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
