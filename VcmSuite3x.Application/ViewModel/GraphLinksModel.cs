using System;
using System.Collections.Generic;
using System.Text;
using VcmSuite3x.Application.Model;
using VcmSuite3x_api.Core.Models;
using static VcmSuite3x_api.Core.Repository.UnitOfWork;

namespace VcmSuite3x.Application.ViewModel
{
    public class GraphLinksModel
    {
        public List<Drawing> NodeDataArray { get; set; }
        public List<DiagramaLinkModel> LinkDataArray { get; set; }
        public List<string> Erros { get; set; }
    }
}
