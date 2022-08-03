namespace CCMS.NEOPE.Web.Extensions;

public static class IdentityConfiguration
{
    public static IApplicationBuilder UseIdentityConfiguration(this IApplicationBuilder app)
    {
        app.UseAuthentication();
        app.UseAuthorization();

        return app;
    }
}