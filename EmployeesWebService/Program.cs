using EmployeesWebService.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

IServiceCollection services = builder.Services;

services.AddDatabase();

services.AddService();

services.AddRepository();

services.AddMapper();

WebApplication app = builder.Build();

app.Bootstrap();

app.Run();