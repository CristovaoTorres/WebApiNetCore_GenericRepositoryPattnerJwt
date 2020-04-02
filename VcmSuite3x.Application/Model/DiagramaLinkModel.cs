using System;
using System.Collections.Generic;
using System.Text;

namespace VcmSuite3x.Application.Model
{
    public class DiagramaLinkModel
    {
        public Int32 DiagramId { get; set; }

        public String Category { get; set; }

        public String Code { get; set; }

        public Int32 Key { get; set; }
        public Int32 From { get; set; }

        public String FromPort { get; set; }

        public Int32 To { get; set; }

        public String ToPort { get; set; }

        public string Color { get; set; }
        public int EntradaIndex { get; set; }
        public int SaidaIndex { get; set; }
    }
}
