namespace EmployeesWebService.Models.Employee.Response;

/// <summary>
/// Модель ответа на удаление сотрудников по Id
/// </summary>
public sealed class DeleteEmployeeResponse
{
    /// <summary>
    /// Количество успешно удалённых
    /// </summary>
    public int CountSuccessfullyDelete { get; set; }
}