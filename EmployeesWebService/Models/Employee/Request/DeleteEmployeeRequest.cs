namespace EmployeesWebService.Models.Employee.Request;

/// <summary>
/// Модель запроса на удаление множества сотрудников
/// </summary>
public sealed class DeleteEmployeeRequest
{
    /// <summary>
    /// Коллекция идентификаторов
    /// </summary>
    public IEnumerable<long> Ids { get; set; } = new List<long>();
}