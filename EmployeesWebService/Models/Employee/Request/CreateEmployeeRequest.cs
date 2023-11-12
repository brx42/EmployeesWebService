using EmployeesWebService.Dto;

namespace EmployeesWebService.Models.Employee.Request;

/// <summary>
/// Модель запроса на создание сотрудника
/// </summary>
public sealed class CreateEmployeeRequest
{
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

    /// <summary>
    /// Паспортные данные
    /// </summary>
    public PassportDto Passport { get; set; } = null!;
}