using System.Reflection;
using EmployeesWebService.Repositories.Implementations;
using EmployeesWebService.Repositories.Interfaces;
using EmployeesWebService.Services.Implementations;
using EmployeesWebService.Services.Interfaces;
using Mapster;
using MapsterMapper;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

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
        service.AddSwagger();
    }

    public static void AddRepository(this IServiceCollection service)
    {
        service.AddScoped<ICompanyRepository, CompanyRepository>();
        service.AddScoped<IDepartmentRepository, DepartmentRepository>();
        service.AddScoped<IEmployeeRepository, EmployeeRepository>();
    }

    public static void AddMapper(this IServiceCollection service)
    {
        TypeAdapterConfig config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        Mapper mapperConfig = new(config);
        service.AddSingleton<IMapper>(mapperConfig);
    }

    private static void AddSwagger(this IServiceCollection service)
    {
        service.AddSwaggerGen(options =>
        {
            options.EnableAnnotations();
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "EmployeesWebService",
                Version = "v1"
            });

            options.DescribeAllParametersInCamelCase();
            string? xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            string? xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
        });
    }
}