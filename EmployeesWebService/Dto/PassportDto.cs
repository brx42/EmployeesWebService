using SqlKata;

namespace EmployeesWebService.Dto;

/// <summary>
/// Паспортные данные сотрудника
/// </summary>
public sealed class PassportDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Ignore]
    internal int Id { get; set; }

    /// <summary>
    /// Тип
    /// </summary>
    [Column("type")]
    public string Type { get; set; } = null!;

    /// <summary>
    /// Номер
    /// </summary>
    [Column("number")]
    public string Number { get; set; } = null!;

    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    [Ignore]
    internal long EmployeeId { get; set; }
}