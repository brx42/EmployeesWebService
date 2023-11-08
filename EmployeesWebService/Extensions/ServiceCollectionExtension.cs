using System.Reflection;
using EmployeesWebService.Repositories.Implementations;
using EmployeesWebService.Repositories.Interfaces;
using EmployeesWebService.Services.Implementations;
using EmployeesWebService.Services.Interfaces;
using Mapster;
using MapsterMapper;

namespace EmployeesWebService.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddDatabase(this IServiceCollection service)
    {
        service.AddTransient<IDbConnectionManager, DbConnectionManager>();
    }

    public static void AddService(this IServiceCollection service)
    {
        service.AddScoped<IBootstrap, Bootstrap>();
    }

    public static void AddRepository(this IServiceCollection service)
    {
        // service.AddScoped<>()
    }
    
    public static void AddMapper(this IServiceCollection services)
    {
        TypeAdapterConfig config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        Mapper mapperConfig = new(config);
        services.AddSingleton<IMapper>(mapperConfig);
    }
}