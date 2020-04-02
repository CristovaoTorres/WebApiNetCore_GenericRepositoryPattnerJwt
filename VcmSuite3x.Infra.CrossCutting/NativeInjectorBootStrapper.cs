using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using VcmSuite3x.Application.Interface;
using VcmSuite3x.Application.Service;
using VcmSuite3x_api.Core.Interface;
using VcmSuite3x_api.Core.Repository;

namespace VcmSuite3x.Infra.CrossCutting
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.TryAddSingleton<INoAppService, NoAppService>();
            services.TryAddSingleton<IMercadoAppService, MercadoAppService>();
            //services.TryAddSingleton<IContratoTakeOrPayBO, ContratoTakeOrPayBO>();
            services.AddScoped<ITopologiaAppService, TopologiaAppService>();
            services.AddScoped<IPeriodoAppService, PeriodoAppService>();
            services.AddScoped<INoDrawingAppService, NoDrawingAppService>();
            services.AddScoped<ICenarioFluxoAppService, CenarioFluxoAppService>();
            services.AddScoped<IProjetoAppService, ProjetoAppService>();
            services.AddScoped<ICorrenteDrawingAppService, CorrenteDrawingAppService>();
            services.AddScoped<ISimboloService, SimboloService>();
            services.AddScoped<IEntradaSimbolo, EntradaSimbolo>();
            services.AddScoped<IElementoAppService, ElementoAppService>();
            services.AddScoped<IEntradaAppService, EntradaAppService>();
            services.AddScoped<IConfiguracaoAppService, ConfiguracaoAppService>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();


            

            //services.TryAddSingleton<ICenarioFluxoAppService, CenarioFluxoAppService>();
            services.TryAddSingleton<IDrawingAppService, DrawingAppService>();


            services.TryAddSingleton<IUnitOfWork, UnitOfWork>();

        }
    }
}
