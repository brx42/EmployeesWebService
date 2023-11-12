namespace EmployeesWebService.Models.Employee.Response;

/// <summary>
/// Модель ответа на создание сотрудника
/// </summary>
public sealed class CreateEmployeeResponse
{
    public CreateEmployeeResponse(long id)
    {
        Id = id;
    }

    /// <summary>
    /// Идентификатор
    /// </summary>
    public long Id { get; set; }
}