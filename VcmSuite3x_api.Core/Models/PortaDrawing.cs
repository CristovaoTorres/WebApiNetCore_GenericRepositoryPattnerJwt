using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class PortaDrawing
    {
        public PortaDrawing()
        {
            CorrenteDrawingPortaEntrada = new HashSet<CorrenteDrawing>();
            CorrenteDrawingPortaSaida = new HashSet<CorrenteDrawing>();
        }

        public int Id { get; set; }
        public int NoId { get; set; }
        public int FluxogramaId { get; set; }
        public int Index { get; set; }

        public NoDrawing NoDrawing { get; set; }
        public ICollection<CorrenteDrawing> CorrenteDrawingPortaEntrada { get; set; }
        public ICollection<CorrenteDrawing> CorrenteDrawingPortaSaida { get; set; }
    }
}
