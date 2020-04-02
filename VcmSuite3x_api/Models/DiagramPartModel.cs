using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VcmSuite3x_api.Models
{
    public class DiagramPartModel
    {
        public Int32 DiagramId { get; set; }

        public String Category { get; set; }

        //[JsonIgnore]
        public String Code { get; set; }

        public Int32 Id { get; set; }
    }
}
