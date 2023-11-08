using SqlKata.Execution;

namespace EmployeesWebService.Repositories.Interfaces;

public interface IDbConnectionManager
{
    public QueryFactory PostgresQueryFactory { get; }
}