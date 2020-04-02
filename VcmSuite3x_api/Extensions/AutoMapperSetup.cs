using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using VcmSuite3x.Application.AutoMapper;

namespace VcmSuite3x_api.Extensions
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper();

            // Registering Mappings automatically only works if the 
            // Automapper Profile classes are in ASP.NET project
            AutoMapperConfig.RegisterMappings();
        }
    }
}
