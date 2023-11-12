using EmployeesWebService.Dto;
using EmployeesWebService.Models.Employee.Request;
using EmployeesWebService.Models.Employee.Response;
using SqlKata.Execution;

namespace EmployeesWebService.Repositories.Interfaces;

public interface IEmployeeRepository
{
    /// <summary>
    /// Создание сотрудника
    /// </summary>
    /// <param name="request">Объект запроса</param>
    /// <param name="ct">Токен отмены</param>
    /// <returns>Модель ответа</returns>
    Task<CreateEmployeeResponse> CreateEmployeeAsync(CreateEmployeeRequest request, CancellationToken ct = default);

    /// <summary>
    /// Получение сотрудников
    /// </summary>
    /// <param name="request">Объект запроса</param>
    /// <param name="ct">Токен отмены</param>
    /// <returns>Модель ответа с пагинацией</returns>
    Task<PaginationResult<EmployeeDto>> GetEmployeesAsync(GetEmployeeRequest request, CancellationToken ct = default);

    /// <summary>
    /// Обновление сотрудника
    /// </summary>
    /// <param name="request">Объект запроса</param>
    /// <param name="ct">Токен отмены</param>
    /// <returns>Модель ответа</returns>
    Task<UpdateEmployeeResponse> UpdateEmployeeAsync(UpdateEmployeeRequest request, CancellationToken ct = default);

    /// <summary>
    /// Удаление сотрудников
    /// </summary>
    /// <param name="request">Объект запроса</param>
    /// <param name="ct">Токен отмены</param>
    /// <returns>Модель ответа</returns>
    Task<DeleteEmployeeResponse> DeleteEmployeeAsync(DeleteEmployeeRequest request, CancellationToken ct = default);
}