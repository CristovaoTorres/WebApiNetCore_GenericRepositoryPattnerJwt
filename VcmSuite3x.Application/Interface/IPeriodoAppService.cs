using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VcmSuite3x_api.Core.Models;

namespace VcmSuite3x.Application.Interface
{
    public interface  IPeriodoAppService
    {
        List<Periodo> InsertMultiplePeriodos(int quantidade, string descricao, int topologiaId);

        bool Update(Periodo periodo);
        bool Delete(int idPeriodo);


    }
}
