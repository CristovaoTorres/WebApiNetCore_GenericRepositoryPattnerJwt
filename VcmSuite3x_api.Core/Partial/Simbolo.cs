using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VcmSuite3x_api.Core.Helper;

namespace VcmSuite3x_api.Core.Models
{
    public partial class Simbolo
    {
        public SimboloHelper Preferences
        {
            get
            {
                switch (this.Codigo)
                {
                    //bool detailed, int typeEntry, int typeDetail, bool exactValue, int columnSize, int columnStart, List<string> columnNames
                    case "CusMP": return new SimboloHelper(true, 0, 0, false, 3, 2, new string[] { "Unidade", "Produto", "Período", "Custo" }.ToList());
                    case "VolIni": return new SimboloHelper(true, 0, 0, false, 2, 1, new string[] { "Unidade", "Produto", "Volume Inicial" }.ToList());
                    case "VolMinT": return new SimboloHelper(true, 0, 0, false, 2, 2, new string[] { "Unidade", "Período", "Volume Mínimo", "Volume Máximo" }.ToList());
                    case "VolMaxT": return new SimboloHelper(true, 0, 0, false, 2, 2, new string[] { "Unidade", "Período", "Volume Mínimo", "Volume Máximo" }.ToList());
                    case "valor": return new SimboloHelper(true, 0, 0, false, 3, 2, new string[] { "Unidade", "Produto", "Período", "Valor do produto<br/>em Estoque", "Custo Financeiro", "Custo de<br/>Armazenagem", "Custo do Seguro" }.ToList());
                    case "cFin": return new SimboloHelper(true, 0, 0, false, 3, 2, new string[] { "Unidade", "Produto", "Período", "Valor do produto<br/>em Estoque", "Custo Financeiro", "Custo de<br/>Armazenagem", "Custo do Seguro" }.ToList());
                    case "cusArm": return new SimboloHelper(true, 0, 0, false, 3, 2, new string[] { "Unidade", "Produto", "Período", "Valor do produto<br/>em Estoque", "Custo Financeiro", "Custo de<br/>Armazenagem", "Custo do Seguro" }.ToList());
                    case "cusSeg": return new SimboloHelper(true, 0, 0, false, 3, 2, new string[] { "Unidade", "Produto", "Período", "Valor do produto<br/>em Estoque", "Custo Financeiro", "Custo de<br/>Armazenagem", "Custo do Seguro" }.ToList());
                    default: return new SimboloHelper();
                }
            }
        }

    }
}
