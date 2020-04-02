using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VcmSuite3x.Application.Model;
using VcmSuite3x.Application.ViewModel;
using VcmSuite3x_api.Core.Models;

namespace VcmSuite3x.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<No, NoViewModel>();
            CreateMap<No, NoModel>();
            CreateMap<FornecimentoCenario, RequestCenarioFluxogramaSave>();
            CreateMap<Topologia, TopologiaViewModel>();
            CreateMap<Cenario, CenarioViewModel>();
            CreateMap<Periodo, PeriodoViewModel>();
            CreateMap<UnidadeMedida, UnidadeMedidaResponse>();
            CreateMap<Produto, ProdutoNo>();


        }
    }
}
