using FluentValidation.AspNetCore;
using HC.Data.Context;
using HC.Data.Repository;
using HC.Manager.Implementation;
using HC.Manager.Interfaces;
using HC.Manager.Mappings;
using HC.Manager.Validator;
using HC.WebApi.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HC.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddJwtTConfiguration(Configuration);
            services.AddFluenteValidationConfiguration();
            services.AddAutoMapperConfiguration();
            services.AddSwaggerConfiguration();
            services.AddDatabaseConfiguration(Configuration);
            services.UseDependencyInjectionConfiguration();
            services.AddSerilog();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler("/error");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDatabaseConfiguration();
            app.UseSwaggerConfiguration();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseJwtConfiguration();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
