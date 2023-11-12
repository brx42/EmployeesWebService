using EmployeesWebService.Common.BaseModels;

namespace EmployeesWebService.Models.Employee.Request;

/// <summary>
/// Модель запроса на получение сотрудников по идентификатору отдела компании
/// </summary>
public sealed class GetEmployeeByDepartmentIdRequest : BaseRequest
{
    /// <summary>
    /// Идентификатор отдела компании
    /// </summary>
    public int DepartmentId { get; set; }
}