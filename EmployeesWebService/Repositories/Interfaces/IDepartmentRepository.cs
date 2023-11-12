using EmployeesWebService.Models.Department.Request;
using EmployeesWebService.Models.Department.Response;

namespace EmployeesWebService.Repositories.Interfaces;

public interface IDepartmentRepository
{
    /// <summary>
    /// Создание отдела
    /// </summary>
    /// <param name="request">Объект запроса</param>
    /// <param name="ct">Токен отмены</param>
    /// <returns>Модель ответа</returns>
    Task<CreateDepartmentResponse> CreateDepartmentAsync(CreateDepartmentRequest request, CancellationToken ct = default);
}