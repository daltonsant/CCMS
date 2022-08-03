using System.Reflection;
using CCMS.NEOPE.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CCMS.NEOPE.Infra.Extensions;

public static class OrmConfigurationExtension
{
    public static IServiceCollection AddOrmConfiguration(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"), 
                    b => 
                        b.MigrationsAssembly(Assembly.GetAssembly(typeof(ApplicationConfiguration))?.ToString()));
            }
        );
        return services;
    }
}