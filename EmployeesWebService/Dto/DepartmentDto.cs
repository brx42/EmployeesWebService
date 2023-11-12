using SqlKata;

namespace EmployeesWebService.Dto;

/// <summary>
/// DTO отдела компании
/// </summary>
public sealed class DepartmentDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Ignore]
    public int Id { get; set; }

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

    /// <summary>
    /// Компания, в которой находится отдел
    /// </summary>
    public CompanyDto Company { get; set; } = null!;
}