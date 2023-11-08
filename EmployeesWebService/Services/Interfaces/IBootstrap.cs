namespace EmployeesWebService.Services.Interfaces;

public interface IBootstrap
{
    /// <summary>
    /// Метод, запускающий какую-то логику перед запуском приложения
    /// </summary>
    /// <returns></returns>
    void Begin();
}