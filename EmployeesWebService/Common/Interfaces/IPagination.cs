namespace EmployeesWebService.Common.Interfaces;

public interface IPagination
{
    /// <summary>
    /// Номер страницы
    /// </summary>
    int PageNumber { get; set; }
    
    /// <summary>
    /// Размер страницы
    /// </summary>
    int PageSize { get; set; }
}