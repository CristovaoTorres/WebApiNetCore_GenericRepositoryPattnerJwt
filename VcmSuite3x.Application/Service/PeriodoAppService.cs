using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VcmSuite3x.Application.Interface;
using VcmSuite3x_api.Core.Interface;
using VcmSuite3x_api.Core.Models;

namespace VcmSuite3x.Application.Service
{
    public class PeriodoAppService : IPeriodoAppService
    {
        private readonly IUnitOfWork _unitOfw;

        public PeriodoAppService(IUnitOfWork unitOfWork)
        {
            _unitOfw = unitOfWork;
        }

        public List<Periodo> InsertMultiplePeriodos(int quantidade, string descricao, int topologiaId)
        {
            try
            {
                int tipoEntidadeId = _unitOfw.TipoEntidadeRepository.Get(y => y.Nome == "Periodo").Select(y => y.Id).FirstOrDefault();

                List<Periodo> periodoList = new List<Periodo>();
                for (int i = 0; i < quantidade; i++)
                {
                    string codigo = _unitOfw.Fn_find_NovoCodigoById(tipoEntidadeId, topologiaId);

                    Periodo onePeriodo = new Periodo
                    {
                        Codigo = codigo,
                        Descricao = descricao,
                        TipoEntidadeId = tipoEntidadeId,
                        TopologiaId = topologiaId
                    };

                    _unitOfw.PeriodoRepository.Insert(onePeriodo);
                    periodoList.Add(onePeriodo);
                }
                return periodoList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Update(Periodo periodo)
        {
            try
            {
                //--Primeiro atualiza eventuais entradas para o período.  
                //EXEC[dbo].[pr_ValoresUpdate] @Id, @TopologiaId, @Codigo, @TipoEntidadeId
                _unitOfw.ValoresUpdate(periodo.Id, periodo.TopologiaId, periodo.Codigo, periodo.TipoEntidadeId);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(int idPeriodo)
        {
            //pr_VCane_PeriodoDelete
            try
            {
                Periodo periodo = _unitOfw.PeriodoRepository.Get(y => y.Id == idPeriodo).FirstOrDefault();

                PeriodoAgregadoItem periodoAgregado = _unitOfw.PeriodoAgregadoItemRepository.Get(y => y.PeriodoId == periodo.Id).FirstOrDefault();
                _unitOfw.PeriodoAgregadoItemRepository.Delete(periodoAgregado);

                PeriodoCenario periodoCenario = _unitOfw.PeriodoCenarioRepository.Get(y => y.PeriodoId == periodo.Id).FirstOrDefault();
                _unitOfw.PeriodoCenarioRepository.Delete(periodoCenario);

                _unitOfw.pr_ValoresClear(periodo.Id, periodo.TipoEntidadeId, periodo.TopologiaId, "");

                _unitOfw.PeriodoRepository.Delete(periodo);

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
