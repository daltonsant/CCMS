using CCMS.NEOPE.Domain.Core.Interfaces;
using CCMS.NEOPE.Infra.Data.Context;
using CCMS.NEOPE.Infra.Data.UoW;
using CCMS.NEOPE.Infra.Extensions;
using CCMS.NEOPE.Infra.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;


namespace CCMS.NEOPE.Infra;
using Microsoft.Extensions.DependencyInjection;

public static class ApplicationConfiguration
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOrmConfiguration(configuration)
            .AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
            })
            .AddRoles<ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationContext>()
            .AddErrorDescriber<IdentityMessagesPtBr>();

        services.Configure<IdentityOptions>(options =>
        {
            options.User.AllowedUserNameCharacters = 
                "abcdefghijklmnopqrstuvxwyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            options.User.RequireUniqueEmail = false;
        });
            
        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequiredLength = 4;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredUniqueChars = 0;
        });
        
        services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

        services.ConfigureRepository()
            .ConfigureApplicationServices();
    }
}
