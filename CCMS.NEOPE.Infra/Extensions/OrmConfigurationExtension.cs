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
        var databaseType = configuration.GetSection("DatabaseType")?.Value ?? string.Empty;
        
        
        services.AddDbContext<ApplicationContext>(options =>
            {
                if (string.IsNullOrEmpty(databaseType))
                {
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
                        b => 
                            b.MigrationsAssembly(Assembly.GetAssembly(typeof(ApplicationConfiguration))?.ToString()));
                }
                else if(databaseType.ToLower().Equals("mysql"))
                {
                    var version = configuration.GetSection("MysqlVersion")?.Value ?? "8.0.30";
                    var serverVersion = new MySqlServerVersion(new Version(version));
                    options.UseMySql(configuration.GetConnectionString("MysqlConnection"), serverVersion,
                        b =>
                        {
                            b.MigrationsAssembly(Assembly.GetAssembly(typeof(ApplicationConfiguration))?.ToString());
                            b.EnableRetryOnFailure(5);
                        });
                }
            }
        );
        return services;
    }
}