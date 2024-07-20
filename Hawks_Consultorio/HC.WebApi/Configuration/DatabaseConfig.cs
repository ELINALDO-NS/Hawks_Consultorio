using HC.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HC.WebApi.Configuration
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<HCContext>(option => option.UseSqlServer(configuration.GetConnectionString("HCConection")));

        }

        public static void UseDatabaseConfiguration(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var contex = serviceScope.ServiceProvider.GetService<HCContext>();
            contex.Database.Migrate();
            contex.Database.EnsureCreated();

        }
    }
}
