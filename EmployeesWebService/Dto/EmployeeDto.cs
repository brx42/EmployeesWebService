namespace EmployeesWebService.Dto;

/// <summary>
/// DTO сотрудника
/// </summary>
public sealed class EmployeeDto
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
    /// Паспортные данные
    /// </summary>
    public PassportDto Passport { get; set; } = null!;

    /// <summary>
    /// Идентификатор отдела компании
    /// </summary>
    public int DepartmentId { get; set; }

    /// <summary>
    /// Отдел компании
    /// </summary>
    public DepartmentDto Department { get; set; } = null!;
}