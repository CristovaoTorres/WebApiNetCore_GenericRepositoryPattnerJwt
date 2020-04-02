using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VcmSuite3x.Application.Interface;
using VcmSuite3x.Application.ViewModel;
using VcmSuite3x_api.Core.Interface;
using VcmSuite3x_api.Core.Models;

namespace VcmSuite3x.Application.Service
{
    public class TopologiaAppService : ITopologiaAppService
    {
        private readonly IUnitOfWork _unitOfw;
        private readonly IMapper _mapper;


        public TopologiaAppService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfw = unitOfWork;
            _mapper = mapper;


        }

        public Topologia Get(int id)
        {
            return _unitOfw.TopologiaRepository.Get(y => y.Id == id).FirstOrDefault();
        }
        public void Update(TopologiaViewModel model)
        {
            _unitOfw.TopologiaRepository.AddOrUpdate(_mapper.Map<Topologia>(model));
        }

        public void Save(TopologiaViewModel model)
        {
            using (var context = new VCMContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Topologia topologia = _mapper.Map<Topologia>(model);
                        context.Topologia.Add(topologia);

                        //pr_VCM_TopologiaInsert

                        //TODO:  esta fixo na function o "Sistema"  ([fn_find_TipoPropriedadeByNome])
                        int tipoPropriedadeId = _unitOfw.TipoPropriedadeRepository.Get(y => y.Nome == "Padrao").Select(y => y.Id).FirstOrDefault();
                        int tipoValorId = _unitOfw.TipoValorRepository.Get(y => y.Nome == "Sistema").Select(y => y.Id).FirstOrDefault();

                        //cadeiaId = _unitOfw.ProjetoRepository.Get(y => y.Topologia.Any(t => t.Id == tobeSave.Id)).Select(c => c.Cadeia.Id).FirstOrDefault();

                        //TODO: CENARIO1 Fixo na Procedure [pr_VCM_CenarioInsert] 
                        Cenario cenario = new Cenario { Nome = "CENARIO1", TopologiaId = topologia.Id };
                        context.Cenario.Add(cenario);

                        FluxogramaDrawing fluxogramaDrawing = new FluxogramaDrawing(topologia.Id, 0, 0, 1);
                        context.FluxogramaDrawing.Add(fluxogramaDrawing);

                        PropriedadeTopologiaCreate(tipoPropriedadeId, topologia.Id, context);

                        context.SaveChanges();
                        transaction.Commit();


                        model.Id = topologia.Id;
                        model.CenarioId = cenario.Id;
                        model.Id = topologia.Id;
                        model.FluxogramaId = fluxogramaDrawing.Id;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }

        private void PropriedadeTopologiaCreate(int tipoPropriedadeId, int topologiaId, VCMContext context)
        {
            List<PropriedadeTopologia> propriedadeTopologiaList = new List<PropriedadeTopologia>();

            List<Propriedade> tipoPropriedadeList = _unitOfw.PropriedadeRepository.Get(y => y.TipoPropriedadeId == tipoPropriedadeId).ToList();

            foreach (var oneTipoPropriedadeList in tipoPropriedadeList)
            {
                PropriedadeTopologia propriedadeTopologia = new PropriedadeTopologia { PropriedadeId = oneTipoPropriedadeList.Id, TopologiaId = topologiaId };
                propriedadeTopologiaList.Add(propriedadeTopologia);
            }
            context.PropriedadeTopologia.AddRange(propriedadeTopologiaList);
        }
    }
}
