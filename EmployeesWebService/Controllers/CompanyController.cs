using EmployeesWebService.Models.Company.Request;
using EmployeesWebService.Models.Company.Response;
using EmployeesWebService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesWebService.Controllers;

[ApiController]
[Route("api/company")]
public sealed class CompanyController : ControllerBase
{
    private readonly ICompanyRepository _repository;

    public CompanyController(ICompanyRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public async Task<ActionResult<CreateCompanyResponse>> CreateCompanyAsync(CreateCompanyRequest request, CancellationToken ct = default)
    {
        CreateCompanyResponse response;

        try
        {
            response = await _repository.CreateCompanyAsync(request, ct);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return Ok(response);
    }
}