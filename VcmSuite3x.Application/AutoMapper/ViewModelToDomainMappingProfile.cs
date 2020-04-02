using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VcmSuite3x.Application.Model;
using VcmSuite3x.Application.ViewModel;
using VcmSuite3x_api.Core.Models;

namespace VcmSuite3x.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<RequestCenarioFluxogramaSave, FornecimentoCenario>();
            CreateMap<ProjetoViewModel, Projeto>();
            CreateMap<TopologiaViewModel, Topologia>();
            CreateMap<CenarioViewModel, Cenario>();
            CreateMap<PeriodoViewModel, Periodo>();

            CreateMap<ProdutoNo, Produto>();
            CreateMap<EntradaRequest, Entrada>();


        }
    }
}
