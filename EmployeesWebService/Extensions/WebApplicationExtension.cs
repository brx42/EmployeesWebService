using EmployeesWebService.Services.Interfaces;
using Microsoft.OpenApi.Models;

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

    public static void UseSwagger(this WebApplication app)
    {
        app.UseSwagger(so =>
        {
            so.PreSerializeFilters.Add((swagger, httpReq) =>
            {
                swagger.Servers = new List<OpenApiServer>
                {
                    new()
                    {
                        Url = $"https://{httpReq.Host}"
                    }
                };
            });
        });

        app.UseSwaggerUI(sui => sui.SwaggerEndpoint("/swagger/v1/swagger.json", "WebService V1"));
    }
}