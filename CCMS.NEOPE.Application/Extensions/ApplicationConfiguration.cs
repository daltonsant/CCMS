using CCMS.NEOPE.Application.Interfaces;
using CCMS.NEOPE.Application.Services;
using CCMS.NEOPE.Infra.Interfaces;
using CCMS.NEOPE.Infra.Services.Impl;
using Microsoft.Extensions.DependencyInjection;

namespace CCMS.NEOPE.Application.Extensions;

public static class ApplicationConfiguration
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IUserService), typeof(UserService));
        services.AddScoped(typeof(ITaskService), typeof(TaskService));
        services.AddScoped(typeof(ITaskTypeService), typeof(TaskTypeService));
        services.AddScoped(typeof(IProjectService), typeof(ProjectService));
        services.AddScoped(typeof(ITaskStepService), typeof(TaskStepService));
        services.AddScoped(typeof(IAssetService), typeof(AssetService));
        services.AddScoped(typeof(IAssetTypeService), typeof(AssetTypeService));
        services.AddScoped(typeof(IBoardService), typeof(BoardService));
        services.AddScoped(typeof(ICalendarService), typeof(CalendarService));

        return services;
    }
}