
using CCMS.NEOPE.Infra.Interfaces;
using CCMS.NEOPE.Infra.Services.Impl;
using Microsoft.Extensions.DependencyInjection;

namespace CCMS.NEOPE.Infra.Extensions;

public static class ApplicationServicesExtensions
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IUserService), typeof(UserService));
        
        return services;
    }
}