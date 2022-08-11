namespace CCMS.NEOPE.Web.Extensions;

public static class MvcConfiguration
{
    public static IServiceCollection AddMvcConfiguration(this IServiceCollection services)
    {
        services.AddDistributedMemoryCache();

        services.AddAuthentication();
        services.AddAuthorization();
        services.ConfigureApplicationCookie(options =>
        {
            options.Cookie.Name = "IdentityCookie";
            options.Cookie.IsEssential = true;
            options.Cookie.HttpOnly = true;
            options.ExpireTimeSpan = TimeSpan.FromMinutes(180);
            options.LoginPath = new PathString("/Users/Login");
            options.LogoutPath = new PathString("/Users/Logout");
            options.AccessDeniedPath = new PathString("/Error/");
        });
        
        services.AddControllersWithViews()
            .AddSessionStateTempDataProvider();

        return services;
    }

    public static IApplicationBuilder UseMvcConfiguration(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseStatusCodePagesWithRedirects("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        else
        {   
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseIdentityConfiguration();

        app.MapDefaultControllerRoute();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
        app.MapRazorPages();

        return app;
    }
}
