using SqlKata;

namespace EmployeesWebService.Models.Company.Request;

/// <summary>
/// Модель запроса на создание компании
/// </summary>
public sealed class CreateCompanyRequest
{
    /// <summary>
    /// Наименование
    /// </summary>
    [Column("name")]
    public string Name { get; set; } = null!;
}