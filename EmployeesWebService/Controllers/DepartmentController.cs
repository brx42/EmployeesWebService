using EmployeesWebService.Models.Department.Request;
using EmployeesWebService.Models.Department.Response;
using EmployeesWebService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesWebService.Controllers;

[ApiController]
[Route("api/department")]
public sealed class DepartmentController : ControllerBase
{
    private readonly IDepartmentRepository _repository;

    public DepartmentController(IDepartmentRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public async Task<ActionResult<CreateDepartmentResponse>> CreateDepartmentAsync(
        CreateDepartmentRequest request, CancellationToken ct = default)
    {
        CreateDepartmentResponse response;
        
        try
        {
            response = await _repository.CreateDepartmentAsync(request, ct);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return Ok(response);
    }
}