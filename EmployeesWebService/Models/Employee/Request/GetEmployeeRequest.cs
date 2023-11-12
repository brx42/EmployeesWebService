using EmployeesWebService.Common.BaseModels;

namespace EmployeesWebService.Models.Employee.Request;

/// <summary>
/// Модель запроса на получение списка сотрудников
/// </summary>
public sealed class GetEmployeeRequest : BaseRequest
{
    /// <summary>
    /// Идентификатор компании
    /// </summary>
    public int? CompanyId { get; set; }

    /// <summary>
    /// Идентификатор отдела компании
    /// </summary>
    public int? DepartmentId { get; set; }
}