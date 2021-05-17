using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Receita.Aplicacao;
using Receita.Aplicacao.Interfaces;
using Receita.Dominio.Repositorios;
using Receita.Infraestrutura.Repositorios;
using System;
using System.IO;

namespace Receita.Api
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
            services.AddControllers();
            services.AddScoped<IReceitaAplicacao, ReceitaAplicacao>();
            services.AddScoped<IReceitaRepository, ReceitaRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Serviço de Receita",
                    Description = "Serviço responsável pelo domínio de receita, realizando integração com a base de dados do https://www.themealdb.com/api.php, seguindo os conceitos da arquitetura de API Rest.",
                    Contact = new OpenApiContact
                    {
                        Name = "Alan Samora Rodrigues",
                        Email = "1278768@sga.pucminas.br"
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Receita V1");
            });
        }
    }
}
