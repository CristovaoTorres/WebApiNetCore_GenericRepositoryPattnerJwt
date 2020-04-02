//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Drawing;
//using System.IO;
//using System.Linq;
//using System.Runtime.Serialization;
//using System.Text;

//namespace VcmSuite3x_api.Core.Models
//{
//    public  class NoDrawing
//    {
//        /// <summary>
//        /// Categoria do nó.
//        /// </summary>
//        /// <remarks>Corresponde ao prefixo do tipo de entidade do nó.</remarks>
//        [DataMember()]
//        public String Categoria { get; set; }

//        /// <summary>
//        /// Número de portas do nó.
//        /// </summary>
//        [DataMember()]
//        public Int32 Portas { get; set; }

//        [NotMapped]
//        public PointF Location { get; set; }
//    }
//}