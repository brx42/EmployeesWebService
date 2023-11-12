using System.ComponentModel;

namespace EmployeesWebService.Common.BaseModels;

public abstract class BaseRequest
{
    /// <summary>
    /// Номер страницы
    /// </summary>
    [DefaultValue(1)]
    public int PageNumber { get; set; } = 1;

    /// <summary>
    /// Размер страницы
    /// </summary>
    [DefaultValue(20)]
    public int PageSize { get; set; } = 20;

    /// <summary>
    /// Направление сортировки
    /// </summary>
    public SortDirection? SortDirection { get; set; } = BaseModels.SortDirection.Asc;

    /// <summary>
    /// Наименование поля, по которому производится сортировка
    /// </summary>
    public string? SortColumn { get; set; }
}