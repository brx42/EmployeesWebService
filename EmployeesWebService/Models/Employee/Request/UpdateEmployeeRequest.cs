using SqlKata;

namespace EmployeesWebService.Models.Employee.Request;

/// <summary>
/// Модель запроса на обновление сотрудника
/// </summary>
public sealed class UpdateEmployeeRequest
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Ignore]
    public long? Id { get; set; }
    
    /// <summary>
    /// Имя
    /// </summary>
    [Column("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    [Column("surname")]
    public string? Surname { get; set; }

    /// <summary>
    /// Номер телефона
    /// </summary>
    [Column("phone")]
    public string? Phone { get; set; }

    /// <summary>
    /// Идентификатор отдела
    /// </summary>
    [Column("department_id")]
    public int? DepartmentId { get; set; }
}