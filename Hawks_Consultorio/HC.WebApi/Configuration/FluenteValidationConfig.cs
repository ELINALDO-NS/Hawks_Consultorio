using FluentValidation.AspNetCore;
using HC.Manager.Validator;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;


namespace HC.WebApi.Configuration
{
    public static class FluenteValidationConfig
    {
        public static void AddFluenteValidationConfiguration(this IServiceCollection services)
        {
            services.AddControllers().
                AddFluentValidation(p =>
                {
                    p.RegisterValidatorsFromAssemblyContaining<NovoClienteValidator>();
                    p.RegisterValidatorsFromAssemblyContaining<AlteraClienteValidator>();
                    p.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");

                });
           
            //services.AddFluentValidationRulesToSwagger();
        }
    }
}
