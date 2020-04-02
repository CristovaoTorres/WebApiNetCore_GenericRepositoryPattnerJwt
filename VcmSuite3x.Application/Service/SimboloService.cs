using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VcmSuite3x.Application.Interface;
using VcmSuite3x_api.Core.Interface;
using VcmSuite3x_api.Core.Models;

namespace VcmSuite3x.Application.Service
{
    public class SimboloService : ISimboloService
    {

        private readonly IUnitOfWork _unitOfw;
        public SimboloService(IUnitOfWork unitOfWork)
        {
            _unitOfw = unitOfWork;
        }

        public Simbolo Find(string entrada)
        {
            return new Simbolo();
        }

        public Simbolo Find(int id)
        {
            return new Simbolo();
        }
        public List<Simbolo> GetSimbolsByCodeList(List<string> codeList)
        {
            return _unitOfw.SimboloRepository.Get(p => codeList.Contains(p.Codigo)).ToList();
        }
    }
}
