using GameOfLifeAPI.Repository;
using GameOfLifeAPI.UseCases;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace GameOfLifeAPI {
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
            services.AddMvc(o => o.InputFormatters.Insert(0, new RawRequestBodyFormatter()));
            services.AddSingleton<SaveBoardRepository, SaveBoardInMemory>();
            services.AddSingleton<SetNewBoardCommandHandler, SetNewBoardCommandHandler>();
            services.AddSingleton<GetActualBoardQuery, GetActualBoardQuery>();
            services.AddSingleton<GetNextGenerationBoardQuery, GetNextGenerationBoardQuery>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "GAMEOFLIFE API", 
                    Version = "v1", 
                    Description = "Api para el juego de la vida" ,
                    License = new OpenApiLicense {
                        Name = "MIT",
                        Url = new Uri("https://es.wikipedia.org/wiki/Licencia_MIT")
                     },
                     Contact = new OpenApiContact {
                         Name = "Saulo Santana",
                         Email = "sausantana@domingoalonsogroup.com"
                     }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });


            services
                .AddHealthChecks()
                .AddCheck<FileHealthChecks>("file_health_checks");
            services
                .AddHealthChecksUI(setupSettings: setup => {
                    setup.AddHealthCheckEndpoint("file_health_checks", "https://localhost:5001/health");
                })
                .AddInMemoryStorage();
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
                endpoints.MapHealthChecks("/health");
               
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "GAMEOFLIFE API V1");
            });


        }
    }
}
