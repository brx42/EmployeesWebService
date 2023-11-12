using EmployeesWebService.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

IServiceCollection services = builder.Services;

services.AddControllers();

services.AddDatabase();

services.AddService();

services.AddRepository();

services.AddMapper();

WebApplication app = builder.Build();

app.MapControllers();

app.UseSwagger();

app.Bootstrap();

app.Run();