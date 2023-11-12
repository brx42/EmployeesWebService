using EmployeesWebService.Models.Company.Request;
using EmployeesWebService.Models.Company.Response;

namespace EmployeesWebService.Repositories.Interfaces;

public interface ICompanyRepository
{
    /// <summary>
    /// Создание компании
    /// </summary>
    /// <param name="request">Объект запроса</param>
    /// <param name="ct">Токен отмены</param>
    /// <returns>Модель ответа</returns>
    Task<CreateCompanyResponse> CreateCompanyAsync(CreateCompanyRequest request, CancellationToken ct = default);
}