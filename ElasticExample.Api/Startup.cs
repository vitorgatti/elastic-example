using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElasticExample.Domain.Application;
using ElasticExample.Domain.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nest;

namespace ElasticExample.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            #region Elastic
            var settings = new ConnectionSettings(new Uri(Configuration["ElasticsearchSettings:uri"]));

            var defaultIndex = Configuration["ElasticsearchSettings:defaultIndex"];

            if (!string.IsNullOrEmpty(defaultIndex))
                settings = settings.DefaultIndex(defaultIndex);

            var basicAuthUser = Configuration["ElasticsearchSettings:username"];
            var basicAuthPassword = Configuration["ElasticsearchSettings:password"];

            if (!string.IsNullOrEmpty(basicAuthUser) && !string.IsNullOrEmpty(basicAuthPassword))
                settings = settings.BasicAuthentication(basicAuthUser, basicAuthPassword);

            var client = new ElasticClient(settings);

            services.AddSingleton<IElasticClient>(client);
            #endregion

            services.AddTransient<ICatalogApplication, CatalogApplication>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
