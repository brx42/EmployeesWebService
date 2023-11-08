using EmployeesWebService.Repositories.Interfaces;
using Npgsql;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace EmployeesWebService.Repositories.Implementations;

public sealed class DbConnectionManager : IDbConnectionManager
{
    private readonly IConfiguration _configuration;

    private string PostgresConnectionString => _configuration["ConnectionStrings:PostgresConnection"]!;

    private NpgsqlConnection PostgresDbConnection => new(PostgresConnectionString);
    
    public DbConnectionManager(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public QueryFactory PostgresQueryFactory => new(PostgresDbConnection, new PostgresCompiler(), 60);
}