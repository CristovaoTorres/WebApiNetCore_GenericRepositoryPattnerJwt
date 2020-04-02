using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VcmSuite3x_api.Models
{
    public class DiagramLinkModel : DiagramPartModel
    {


        public Int32 From { get; set; }

        public String FromPort { get; set; }

        public Int32 To { get; set; }

        public String ToPort { get; set; }

        public string Color { get; set; }

    }
}
