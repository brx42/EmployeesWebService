namespace EmployeesWebService.Models.Employee.Response;

/// <summary>
/// Модель ответа на обновление сотрудника
/// </summary>
public sealed class UpdateEmployeeResponse
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Фамилия
    /// </summary>
    public string Surname { get; set; } = null!;

    /// <summary>
    /// Номер телефона
    /// </summary>
    public string Phone { get; set; } = null!;

    /// <summary>
    /// Идентификатор отдела
    /// </summary>
    public int DepartmentId { get; set; }
}