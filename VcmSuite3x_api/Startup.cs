using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using VcmSuite3x.Application.AutoMapper;
using VcmSuite3x.Application.Interface;
using VcmSuite3x.Application.Service;
using VcmSuite3x.Infra.CrossCutting;
using VcmSuite3x_api.Business;
using VcmSuite3x_api.Core.Interface;
using VcmSuite3x_api.Core.Models;
using VcmSuite3x_api.Core.Repository;
using VcmSuite3x_api.Extensions;

namespace VcmSuite3x_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string conn = Configuration.GetConnectionString("DBVCM");
            services.AddDbContext<VCMContext>(options => options.UseSqlServer(conn, sqlServerOptions => sqlServerOptions.CommandTimeout(300)));

            services.AddAutoMapperSetup();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                     .AddJwtBearer(options =>
                     {
                         options.TokenValidationParameters = new TokenValidationParameters
                         {
                             ValidateIssuer = true,
                             ValidateAudience = true,
                             ValidateLifetime = true,
                             ValidateIssuerSigningKey = true,
                             ValidIssuer = Configuration["Jwt:Issuer"],
                             ValidAudience = Configuration["Jwt:Issuer"],
                             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                         };
                     });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMediatR(typeof(Startup));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "VCM 3X",
                    Description = "Op2B VCm 3X  ASP.NET Core Web API",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "Talking to Developer", Email = "cristovao.ftorres@hotmail.com", Url = "http://op2b.com.br/" }
                });
            });

            services.AddMvc();
            RegisterServices(services);


        }
        private static void RegisterServices(IServiceCollection services)
        {
            // Adding dependencies from another layers (isolated from Presentation)
            NativeInjectorBootStrapper.RegisterServices(services);
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseAuthentication();

            string swaggerJson = Configuration["SwaggerPath"].ToString();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseCors(builder =>
            {
                builder.WithOrigins("*");
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            });
            app.UseMvc();
        }
    }
}
