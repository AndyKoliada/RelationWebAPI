using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using WebAPI.Infrastructure.Context;
using WebAPI.Infrastructure.Repositories;
using WebAPI.Domain.Interfaces.Repositories;
using WebAPI.Domain.Interfaces.Services;
using WebAPI.Services;
using NLog;
using System;
using System.IO;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //Enable CORS
            services.AddCors(c =>
            c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod()
            .AllowAnyHeader()));

            //JSON Serializer
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options => 
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(options => 
                options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            
            //Registering custom services
            services.AddScoped<IRelationsService, RelationsServiceCached>();
            services.AddScoped<ICountriesService, CountriesService>();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<IRelationsRepository, RelationsRepository>();
            services.AddScoped<ICountriesRepository, CountriesRepository>();
            services.AddSingleton<ILoggerService, LoggerService>();

            services.AddControllers();

            services.AddDbContext<RepositoryContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("RelationDB")));
            
            services.AddSwaggerGen(c =>
            {
                c.IncludeXmlComments(string.Format(@"{0}\WebAPI.xml", System.AppDomain.CurrentDomain.BaseDirectory));
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "RelationWebAPI",
                });

            });

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {   
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod()
            .AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Enable middleware to serve generated Swagger as a JSON endpoint.
                app.UseSwagger(c =>
{
                    c.SerializeAsV2 = true;
                });

                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
                // specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "RelationWebAPI");
                });
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}