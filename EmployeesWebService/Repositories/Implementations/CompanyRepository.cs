using EmployeesWebService.Models.Company.Request;
using EmployeesWebService.Models.Company.Response;
using EmployeesWebService.Repositories.Interfaces;
using SqlKata;
using SqlKata.Execution;
using Exception = System.Exception;

namespace EmployeesWebService.Repositories.Implementations;

public sealed class CompanyRepository : ICompanyRepository
{
    private readonly QueryFactory _queryFactory;

    private const string CompanyTableName = "public.company";

    public CompanyRepository(IDbConnectionManager config)
    {
        _queryFactory = config.PostgresQueryFactory;
    }

    /// <inheritdoc />
    public async Task<CreateCompanyResponse> CreateCompanyAsync(CreateCompanyRequest request, CancellationToken ct = default)
    {
        Query companyQuery = _queryFactory.Query(CompanyTableName);

        int companyId = await companyQuery.InsertGetIdAsync<int>(request, cancellationToken: ct);
        
        if (companyId == 0)
        {
            throw new Exception("При создании компании произошла ошибка");
        }
        
        CreateCompanyResponse response = new(companyId);

        return response;
    }
}