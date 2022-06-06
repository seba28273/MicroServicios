using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MS.Aplicaciones.Interfaces;
using MS.Aplicaciones.Interfaces.Claro;
using MS.Aplicaciones.Servicios.Claro;
using MS.Aplicaciones.Servicios.Telerecargas;
using MS.Domain.Telerecargas.Comunications.Request;
using MS.Dominio.Entidades.Claro.Request;
using MS.Dominio.Entidades.Claro.Response;
using MS.Dominio.Interfaces;
using ServiceTR;

namespace MS.GestorApp
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
            services.AddSingleton<IOperacionesTelerecargasVentas<ventaRecargaRequest, consultaRecargaResponse>, TRServicioRecarga>();
            services.AddSingleton<IOperacionesTelerecargasBalance<ResponseBase>, TRServicioBalance>();
            services.AddSingleton<IOperacionesTelerecargasSearchSale<estadoVentaRequest, estadoVentaResponse>, TRServicioSearchSale>();
            services.AddSingleton<IOperacionesClaroSale<requestSaleClaro, responseSaleClaro>, ClaroServiceSale>();
            services.AddSingleton<IOperacionesClaroSearchSale<requestSearchClaro, responseSaleClaro>, ClaroServiceSearchSale>();

            // services.AddSingleton<IpsGvWebServiceSoap, ServicesTelerecargas>();
            AddSwagger(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1", });
            });
        }


    }
}
