using FluentValidation.AspNetCore;
using HC.Manager.Validator;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Globalization;


namespace HC.WebApi.Configuration
{
    public static class FluenteValidationConfig
    {
        public static void AddFluenteValidationConfiguration(this IServiceCollection services)
        {
            services.AddControllers().
                AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore).
                AddFluentValidation(p =>
                {
                    p.RegisterValidatorsFromAssemblyContaining<NovoClienteValidator>();
                    p.RegisterValidatorsFromAssemblyContaining<AlteraClienteValidator>();
                    p.RegisterValidatorsFromAssemblyContaining<NovoClienteValidator>();

                    p.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");

                });
           
           
        }
    }
}
