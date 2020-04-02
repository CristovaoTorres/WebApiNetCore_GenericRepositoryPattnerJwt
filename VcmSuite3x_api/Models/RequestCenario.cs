using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VcmSuite3x_api.Models
{
    public class RequestCenario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int TopologiaId { get; set; }
    }
}
