using EmployeesWebService.Services.Interfaces;

namespace EmployeesWebService.Extensions;

public static class WebApplicationExtension
{
    public static void Bootstrap(this WebApplication app)
    {
        using IServiceScope scope = app.Services.CreateScope();

        IServiceProvider services = scope.ServiceProvider;
        IBootstrap bootstrap = services.GetRequiredService<IBootstrap>();
        bootstrap.Begin();

        scope.Dispose();
    }
}