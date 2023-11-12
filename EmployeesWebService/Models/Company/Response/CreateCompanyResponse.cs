namespace EmployeesWebService.Models.Company.Response;

/// <summary>
/// Модель ответа на создание компании 
/// </summary>
public sealed class CreateCompanyResponse
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }

    public CreateCompanyResponse(int id)
    {
        Id = id;
    }
}