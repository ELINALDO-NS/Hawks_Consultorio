using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace HC.WebApi.Configuration
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Hawks Consultorio",
                    Version = "v1",
                    Description = "API da aplicação Hawks Consultorio",
                    Contact = new OpenApiContact
                    {
                        Name = "Elinaldo Nascimeto",
                        Email = "elinaldo_nascimento@Outlook.com"
                    },
                    License = new OpenApiLicense
                    {
                        Name = "OSD",
                        Url = new System.Uri("https://opensource.org/osd")
                    },
                    TermsOfService = new System.Uri("https://opensource.org/osd")

                });
               
                var XmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var XmlPath = Path.Combine(AppContext.BaseDirectory, XmlFile);
                c.IncludeXmlComments(XmlPath);
                XmlPath = Path.Combine(AppContext.BaseDirectory, "HC.Core.Shared.xml");
                c.IncludeXmlComments(XmlPath);
                var securityschema = new OpenApiSecurityScheme{
                    Name = "Autorization",
                    Description = "Insira o Tokem Bearer",
                    In = ParameterLocation.Header, 
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securityschema);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityschema,new string[]{} }
                });
            });
            
            services.AddFluentValidationRulesToSwagger();
         
        }
        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("./Swagger/v1/swagger.json", "HC v1");
            });
        }
    }
}
