using SqlKata;

namespace EmployeesWebService.Models.Department.Request;

/// <summary>
/// Модель запроса на создание отдела компании
/// </summary>
public sealed class CreateDepartmentRequest
{
    /// <summary>
    /// Наименование
    /// </summary>
    [Column("name")]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Номер телефона
    /// </summary>
    [Column("phone")]
    public string? Phone { get; set; }

    /// <summary>
    /// Идентификатор компании, в которой находится отдел
    /// </summary>
    [Column("company_id")]
    public int CompanyId { get; set; }
}