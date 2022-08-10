using System.Reflection;
using CCMS.NEOPE.Application.AutoMapper.MapProfiles;
using CCMS.NEOPE.Application.Extensions;
using CCMS.NEOPE.Infra;
using CCMS.NEOPE.Web.Extensions;

namespace CCMS.NEOPE.Web;


public class Startup : IStartup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.RegisterServices(Configuration);
        services.AddAutoMapper(Assembly.GetAssembly(typeof(ProjectProfile)));
        services.ConfigureApplicationServices();
        services.AddMvcConfiguration();
    }

    public void Configure(WebApplication app, IWebHostEnvironment environment)
    {
        app.UseMvcConfiguration();
    }
}

public interface IStartup
{
    IConfiguration Configuration { get; }
    void ConfigureServices(IServiceCollection services);
    void Configure(WebApplication app, IWebHostEnvironment environment);
}

public static class StartupExtensions
{
    public static WebApplicationBuilder UseStartup<TStartup>(this WebApplicationBuilder webAppBuilder)
        where TStartup : IStartup
    {
        var startup = Activator.CreateInstance(typeof(TStartup), webAppBuilder.Configuration) as IStartup;
        if (startup == null) throw new ArgumentException("Invalid Startup class.");

        startup.ConfigureServices(webAppBuilder.Services);
        var app = webAppBuilder.Build();
        startup.Configure(app, app.Environment);

        app.Run();

        return webAppBuilder;
    }
}