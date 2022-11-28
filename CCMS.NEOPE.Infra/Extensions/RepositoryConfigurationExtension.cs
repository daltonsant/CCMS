using CCMS.NEOPE.Domain.Core.Interfaces;
using CCMS.NEOPE.Domain.Interfaces;
using CCMS.NEOPE.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CCMS.NEOPE.Infra.Extensions;

public static class RepositoryConfigurationExtension
{
    public static IServiceCollection ConfigureRepository(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<,>), typeof( Repository< , >));
        services.AddScoped(typeof(ITaskRepository), typeof(TaskRepository));
        services.AddScoped(typeof(ITaskTypeRepository), typeof(TaskTypeRepository));
        services.AddScoped(typeof(ITaskStepRepository), typeof(TaskStepRepository));
        services.AddScoped(typeof(IProjectRepository), typeof(ProjectRepository));
        services.AddScoped(typeof(IAssetRepository), typeof(AssetRepository));
        services.AddScoped(typeof(IAssetTypeRepository), typeof(AssetTypeRepository));
        services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));
        services.AddScoped(typeof(ILinkedTasksRepository), typeof(LinkedTaskRepository));
        services.AddScoped(typeof(IAccountableRepository), typeof(AccountableRepository));
        services.AddScoped(typeof(IAssetProjectStatusRepository), typeof(AssetProjectStatusRepository));
        return services;
    }
}