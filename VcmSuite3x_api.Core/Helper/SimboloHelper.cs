using System;
using System.Collections.Generic;
using System.Text;

namespace VcmSuite3x_api.Core.Helper
{
   public class SimboloHelper
    {
        public SimboloHelper()
        {

        }
        public SimboloHelper(bool detailed, int typeEntry, int typeDetail, bool exactValue, int columnSize, int columnStart, List<string> columnNames)
        {
            this.Detailed = detailed;
            this.TypeEntry = typeEntry;
            this.TypeDetail = typeDetail;
            this.ExactValue = exactValue;
            this.ColumnSize = columnSize;
            this.ColumnStart = ColumnStart;
            this.ColumnNames = columnNames;
        }

        public bool Detailed { get; set; }
        public int TypeEntry { get; set; }
        public int TypeDetail { get; set; }
        public bool ExactValue { get; set; }

        public int ColumnSize { get; set; }
        public int ColumnStart { get; set; }
        public List<string> ColumnNames { get; set; }
    }
}
