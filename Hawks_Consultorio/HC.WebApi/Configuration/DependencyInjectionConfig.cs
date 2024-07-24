using HC.Data.Repository;
using HC.Manager.Implementation;
using HC.Manager.Interfaces.Managers;
using HC.Manager.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HC.WebApi.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void UseDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteManager, ClienteManager>();
            services.AddScoped<IMedicoRepository, MedicoRepository>();
            services.AddScoped<IMedicoManager, MedicoManager>();
            services.AddScoped<IEspecialidadeRepository, EspecialidadeRepository>();
            services.AddScoped<IEspecialidadeManager, EspecialidadeManager>();
           
        }
    }
}
