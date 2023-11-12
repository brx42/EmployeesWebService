using System.Data;
using EmployeesWebService.Common.BaseModels;
using EmployeesWebService.Dto;
using EmployeesWebService.Extensions;
using EmployeesWebService.Models.Employee.Request;
using EmployeesWebService.Models.Employee.Response;
using EmployeesWebService.Repositories.Interfaces;
using SqlKata;
using SqlKata.Execution;
using SqlKata.Extensions;
using Employee = EmployeesWebService.Dto.EmployeeDto;
using Passport = EmployeesWebService.Dto.PassportDto;
using Company = EmployeesWebService.Dto.CompanyDto;
using Department = EmployeesWebService.Dto.DepartmentDto;

namespace EmployeesWebService.Repositories.Implementations;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly QueryFactory _queryFactory;

    private const string EmployeeTableName = "public.employee";
    private const string PassportTableName = "public.passport";
    private const string CompanyTableName = "public.company";
    private const string DepartmentTableName = "public.department";

    public EmployeeRepository(IDbConnectionManager config)
    {
        _queryFactory = config.PostgresQueryFactory;
    }

    /// <inheritdoc />
    public async Task<CreateEmployeeResponse> CreateEmployeeAsync(CreateEmployeeRequest request, CancellationToken ct = default)
    {
        _queryFactory.Connection.Open();
        
        IDbTransaction transaction = _queryFactory.Connection.BeginTransaction();
        
        Query employeeQuery = _queryFactory.Query(EmployeeTableName);

        int employeeId = await employeeQuery.InsertGetIdAsync<int>(
            new
            {
                name = request.Name,
                surname = request.Surname,
                phone = request.Phone,
                department_id = request.DepartmentId
            }, cancellationToken: ct);

        if (employeeId == 0)
        {
            transaction.Rollback();
            
            // Сюда можно вставить свой тип ошибки
            throw new Exception("При создании сотрудника произошла ошибка");
        }

        CreateEmployeeResponse employeeResponse = new(employeeId);

        Query passportQuery = _queryFactory.Query(PassportTableName);

        request.Passport.EmployeeId = employeeId;
        
        int passportId = await passportQuery.InsertGetIdAsync<int>(request.Passport, cancellationToken: ct);

        if (passportId == 0)
        {
            transaction.Rollback();
            
            throw new Exception("При создании информации о паспорте сотрудника произошла ошибка");
        }
        
        transaction.Commit();
        
        _queryFactory.Connection.Close();

        return employeeResponse;
    }

    #region BaseQuery

    private Query CompanyQuery(int? companyId = null)
    {
        Query query = _queryFactory
            .Query(CompanyTableName)
            .Select(
                "id",
                $"id as {nameof(Company.Id)}",
                $"name as {nameof(Company.Name)}")
            .When(companyId.HasValue, q => q.Where("id", companyId));

        return query;
    }

    private Query DepartmentQuery(int? departmentId = null, int? companyId = null)
    {
        Query query = _queryFactory
            .Query(DepartmentTableName)
            .Select(
                "id",
                $"id as {nameof(Department.Id)}",
                $"name as {nameof(Department.Name)}",
                $"phone as {nameof(Department.Phone)}",
                $"company_id as {nameof(Department.CompanyId)}")
            .When(departmentId.HasValue, q => q.Where("id", departmentId))
            .Include(nameof(Department.Company), CompanyQuery(companyId), $"{nameof(Department.CompanyId)}", "id");

        return query;
    }

    private Query EmployeeQuery(int? departmentId = null, int? companyId = null)
    {
        Query query = _queryFactory
            .Query(EmployeeTableName)
            .ForPostgreSql(q => q.Select(
                $"id as {nameof(Employee.Id)}",
                $"name as {nameof(Employee.Name)}",
                $"surname as {nameof(Employee.Surname)}",
                $"phone as {nameof(Employee.Phone)}",
                $"department_id as {nameof(Employee.DepartmentId)}")
                .Include(nameof(Employee.Passport), PassportQuery, $"{nameof(Employee.Id)}", "employee_id"));
            // .Include(nameof(Employee.Department), DepartmentQuery(departmentId, companyId), 
                // $"{nameof(Employee.DepartmentId)}", "id")
            // .Include(nameof(Employee.Passport), PassportQuery, $"{nameof(Employee.Id)}", "employee_id");

        return query;
    }

    private Query PassportQuery => _queryFactory
        .Query(PassportTableName)
        .ForPostgreSql(q => q.Select(
            $"id as {nameof(Passport.Id)}",
            $"number as {nameof(Passport.Number)}",
            $"type as {nameof(Passport.Type)}",
            $"employee_id as {nameof(Passport.EmployeeId)}")
            .SelectRaw("[employee_id]::bigint"));

    #endregion

    public async Task<PaginationResult<EmployeeDto>> GetEmployeesAsync(GetEmployeeRequest request, CancellationToken ct = default)
    {
        Query query = EmployeeQuery(request.DepartmentId, request.CompanyId);

        if (!string.IsNullOrEmpty(request.SortColumn))
        {
            query = request.SortDirection switch
            {
                SortDirection.Asc => query.OrderBy(request.SortColumn),
                SortDirection.Desc => query.OrderByDesc(request.SortColumn),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        PaginationResult<EmployeeDto>? response =
            await query.PaginateForInclude<EmployeeDto>(request.PageNumber, request.PageSize, ct);

        if (response is null)
        {
            throw new Exception("При получении сотрудников произошла ошибка");
        }
        
        return response;
    }

    public async Task<UpdateEmployeeResponse> UpdateEmployeeAsync(UpdateEmployeeRequest request, CancellationToken ct = default)
    {
        Query employeeQuery = _queryFactory
            .Query(EmployeeTableName)
            .Where("id", request.Id);

        int count = await employeeQuery.UpdateAsync(request, cancellationToken: ct);

        if (count == 0)
        {
            throw new Exception("При обновлении сотрудника произошла ошибка");
        }

        UpdateEmployeeResponse? response = _queryFactory
            .Query(EmployeeTableName)
            .Where("id", request.Id)
            .Get<UpdateEmployeeResponse>()
            .FirstOrDefault();

        return response!;
    }

    public async Task<DeleteEmployeeResponse> DeleteEmployeeAsync(DeleteEmployeeRequest request, CancellationToken ct = default)
    {
        Query employeeQuery = _queryFactory
            .Query(EmployeeTableName)
            .WhereIn("id", request.Ids);

        int count = await _queryFactory.ExecuteAsync(employeeQuery, cancellationToken: ct);

        if (count == 0)
        {
            throw new Exception("При удалении сотрудников произошла ошибка");
        }

        DeleteEmployeeResponse response = new()
        {
            CountSuccessfullyDelete = count
        };

        return response;
    }
}