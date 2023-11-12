namespace EmployeesWebService.Models.Department.Response;

/// <summary>
/// Модель ответа на создание отдела компании
/// </summary>
public sealed class CreateDepartmentResponse
{
    public CreateDepartmentResponse(int id)
    {
        Id = id;
    }

    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }
}