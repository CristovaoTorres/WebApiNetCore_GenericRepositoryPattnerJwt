using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VcmSuite3x.Application.Interface;
using VcmSuite3x.Application.ViewModel;
using VcmSuite3x_api.Core.Interface;
using VcmSuite3x_api.Core.Models;
using VcmSuite3x.Application.Extensions;

namespace VcmSuite3x.Application.Service
{
    public class ProjetoAppService : IProjetoAppService
    {
        private readonly IUnitOfWork _unitOfw;
        private readonly IMapper _mapper;

        public ProjetoAppService(IUnitOfWork unitOfw, IMapper mapper)
        {
            _unitOfw = unitOfw;
            _mapper = mapper;
        }
        public List<string> Validate(List<int> listUndiadeMedidaId)
        {
            IQueryable<UnidadeMedida> unidadeMedida = _unitOfw.UnidadeMedidaRepository.GetAll();
            List<int> unidadeMedidaId = unidadeMedida.Select(y => y.Id).ToList();

            List<int> unitIdsFromApi = listUndiadeMedidaId;
            List<int> dups = unitIdsFromApi.Intersect(unidadeMedidaId).ToList();

            List<string> returnMessages = new List<string>();
            if (!dups.SequenceEqual(unitIdsFromApi))
            {
                string unitMeasuresIdsString = "----";
                try { unitMeasuresIdsString = string.Join(",", unidadeMedida.Select(y => y.Id)); } catch { /* Do Nothing */ }

                returnMessages.Add(string.Format("{0} Unidade de Medida não encontrada no Banco de Dados!", string.Join(",", unitIdsFromApi)));

                return returnMessages;
            }
            return returnMessages;

        }
        public ProjetoViewModel Register(ProjetoViewModel model)
        {
            var projeto = _mapper.Map<Projeto>(model);

            using (var context = new VCMContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Projeto.AddRange(projeto);

                        List<MedidaProjeto> medidas = new List<MedidaProjeto>();
                        foreach (var oneMedidaProjeto in model.UnidadeMedidaId)
                            medidas.Add(new MedidaProjeto() { UnidadeMedidaId = oneMedidaProjeto, ProjetoId = projeto.Id });
                        context.AddRange(medidas);
                        context.SaveChanges();
                        transaction.Commit();
                    }


                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }

            model.Id = projeto.Id;
            return model;
        }
        public object List()
        {
            return (from p in _unitOfw.ProjetoRepository.Get()
                    join t in _unitOfw.TopologiaRepository.Get() on p.Id equals t.ProjetoId
                    join c in _unitOfw.FluxogramaDrawingRepository.Get() on t.Id equals c.TopologiaId
                    select new
                    {
                        p.Id,
                        p.Nome,
                        FluxogramaID = c.Id
                    }).GroupBy(y => y.Id).Select(y => y.First()).ToList();
        }

        public void Delete(Projeto model)
        {
            _unitOfw.ProjetoRepository.Delete(model);
        }

        public ProjetoViewModel Get(int idProjeto)
        {
            Projeto projeto = _unitOfw.ProjetoRepository.Get(y => y.Id == idProjeto, null, "MedidaProjeto").FirstOrDefault();

            if (projeto == null)
                return null;

            List<UnidadeMedida> unidadesMedida = _unitOfw.UnidadeMedidaRepository.GetAll().ToList();

            List<TipoUnidade> tipoUnidadeList = _unitOfw.TipoUnidadeRepository.GetAll().ToList();

            ProjetoViewModel model = new ProjetoViewModel();

            foreach (TipoUnidade oneTipoUnidade in tipoUnidadeList)
            {
                var unidadesMediasList = unidadesMedida.Select(oneTipoUnidade.Nome);

                if (unidadesMediasList != null)
                {
                    UnidadeMedidaHelper unidadeHelper = new UnidadeMedidaHelper
                    {
                        Nome = oneTipoUnidade.Nome,
                        Items = Items(unidadesMediasList, projeto.MedidaProjeto.Select(y => y.UnidadeMedidaId).ToList())
                    };

                    model.UnidadeMedidas.Add(unidadeHelper);
                }
            }

            model.Nome = projeto.Nome;
            model.Nota = projeto.Nota;
            model.Id = projeto.Id;
            model.CadeiaId = projeto.CadeiaId;

            return model;
        }

        private static List<SelectListItem> Items(List<UnidadeMedida> unidades, List<Int32> unidadeMedidaId)
        {
            return unidades.Select(um =>
            {
                return new SelectListItem()
                {
                    Selected = (unidadeMedidaId.Contains(um.Id)),
                    Text = um.Representacao,
                    Value = um.Id.ToString(),
                };
            }).ToList();
        }

        public Projeto Update(ProjetoViewModel model)
        {

            Projeto projectToBeSaved = _unitOfw.ProjetoRepository.GetQuery(y => y.Id == model.Id, "MedidaProjeto");

            if (projectToBeSaved == null)
                return null;

            using (var context = new VCMContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        List<int> unitIdsFromDB = projectToBeSaved.MedidaProjeto.Select(s => s.UnidadeMedidaId).ToList();

                        List<int> unitsIDToBeInserted = model.UnidadeMedidaId.Except(unitIdsFromDB).ToList();
                        List<int> unitsIDToBeRemoved = unitIdsFromDB.Except(model.UnidadeMedidaId).ToList();


                        unitsIDToBeInserted.ForEach(x => projectToBeSaved.MedidaProjeto.Add(new MedidaProjeto { ProjetoId = (int)model.Id, UnidadeMedidaId = x }));
                        unitsIDToBeRemoved.ForEach(x => projectToBeSaved.MedidaProjeto.Remove(projectToBeSaved.MedidaProjeto.Where(y => y.UnidadeMedidaId == x).FirstOrDefault()));

                        projectToBeSaved.Nome = model.Nome;
                        projectToBeSaved.Nota = model.Nota;

                        context.Projeto.Update(projectToBeSaved);
                        _unitOfw.MedidaProjetoRepository.Delete(y => y.ProjetoId == projectToBeSaved.Id);

                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {

                    }
                }
                return projectToBeSaved;
            }
        }
    }
}
