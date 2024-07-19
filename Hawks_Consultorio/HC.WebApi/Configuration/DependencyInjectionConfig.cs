using HC.Data.Repository;
using HC.Manager.Implementation;
using HC.Manager.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HC.WebApi.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void UseDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteManager, ClienteManager>();
        }
    }
}
