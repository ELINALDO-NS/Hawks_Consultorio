using HC.Manager.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace HC.WebApi.Configuration
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(NovoClienteMappigProfile), typeof(AlteraClienteMappingProfile));
            services.AddAutoMapper(typeof(NovoMedicoMappingProfile), typeof(UsuarioMappingProfile));
           
               
                
                
        }
    }
}
