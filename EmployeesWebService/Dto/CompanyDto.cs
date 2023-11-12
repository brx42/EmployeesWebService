using SqlKata;

namespace EmployeesWebService.Dto;

/// <summary>
/// DTO компании
/// </summary>
public sealed class CompanyDto
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
}