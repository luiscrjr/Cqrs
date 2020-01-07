using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Projeto.Presentation.Infra.Contexts;
using Projeto.Presentation.Infra.Contracts;
using Projeto.Presentation.Infra.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace Projeto.Presentation
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<DataContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("Aula"))
                );

            services.AddTransient<IProductRepository, ProductRepository>();

            //automapper..
            services.AddAutoMapper(typeof(Startup));

            //mediator
            services.AddMediatR(typeof(Startup));

            services.AddSwaggerGen(
              swagger =>
              {
                  swagger.SwaggerDoc("v1",
                      new Info
                      {
                          Title = "API para Controle de Produtos",
                          Version = "v1",
                          Description = "Projeto CQRS"
                      });
              }
              );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(
                swagger =>
                {
                    swagger.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto");
                }
                );
        }
    }
}
