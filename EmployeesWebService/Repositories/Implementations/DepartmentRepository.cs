using EmployeesWebService.Models.Department.Request;
using EmployeesWebService.Models.Department.Response;
using EmployeesWebService.Repositories.Interfaces;
using SqlKata;
using SqlKata.Execution;

namespace EmployeesWebService.Repositories.Implementations;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly QueryFactory _queryFactory;

    private const string DepartmentTableName = "public.department";

    public DepartmentRepository(IDbConnectionManager config)
    {
        _queryFactory = config.PostgresQueryFactory;
    }
    
    public async Task<CreateDepartmentResponse> CreateDepartmentAsync(CreateDepartmentRequest request, CancellationToken ct = default)
    {
        Query departmentQuery = _queryFactory.Query(DepartmentTableName);

        int departmentId = await departmentQuery.InsertGetIdAsync<int>(request, cancellationToken: ct);

        if (departmentId == 0)
        {
            throw new Exception("При создании отдела компании произошла ошибка");
        }

        CreateDepartmentResponse response = new(departmentId);

        return response;
    }
}