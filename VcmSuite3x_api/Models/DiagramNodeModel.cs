using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;

namespace VcmSuite3x_api.Models
{
    public class DiagramNodeModel : DiagramPartModel
    {

        public Int32 Height { get; set; }


        public float LocationX { get; set; }
        public float LocationY { get; set; }


        public Int32 Ports { get; set; }

        public Int32 Width { get; set; }
    }
}
