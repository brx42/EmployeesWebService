using EmployeesWebService.Common.BaseModels;

namespace EmployeesWebService.Models.Employee.Request;

/// <summary>
/// Модель запроса на получение сотрудников по идентификатору компании
/// </summary>
public sealed class GetEmployeeByCompanyIdRequest : BaseRequest
{
    /// <summary>
    /// Идентификатор компании
    /// </summary>
    public int CompanyId { get; set; }
}