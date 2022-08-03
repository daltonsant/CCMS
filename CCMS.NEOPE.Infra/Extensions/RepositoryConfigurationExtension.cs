using CCMS.NEOPE.Domain.Core.Interfaces;
using CCMS.NEOPE.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CCMS.NEOPE.Infra.Extensions;

public static class RepositoryConfigurationExtension
{
    public static IServiceCollection ConfigureRepository(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<,>), typeof( Repository< , >));
        
        return services;
    }
}