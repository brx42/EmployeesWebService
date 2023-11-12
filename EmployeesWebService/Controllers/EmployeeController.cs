using EmployeesWebService.Dto;
using EmployeesWebService.Models.Employee.Request;
using EmployeesWebService.Models.Employee.Response;
using EmployeesWebService.Repositories.Interfaces;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using SqlKata.Execution;

namespace EmployeesWebService.Controllers;

[ApiController]
[Route("api/employee")]
public sealed class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository _repository;
    private readonly IMapper _mapper;

    public EmployeeController(IEmployeeRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet("by-company-id")]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployeesByCompanyIdAsync(
        [FromQuery]GetEmployeeByCompanyIdRequest request, CancellationToken ct = default)
    {
        var baseRequest = _mapper.Map<GetEmployeeRequest>(request);
        
        PaginationResult<EmployeeDto> response;

        try
        {
            response = await _repository.GetEmployeesAsync(baseRequest, ct);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return Ok(response.List);
    }
    
    [HttpGet("by-department-id")]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployeesByDepartmentIdAsync(
       [FromQuery]GetEmployeeByDepartmentIdRequest request, CancellationToken ct = default)
    {
        var baseRequest = _mapper.Map<GetEmployeeRequest>(request);
        
        PaginationResult<EmployeeDto> response;

        try
        {
            response = await _repository.GetEmployeesAsync(baseRequest, ct);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return Ok(response.List);
    }

    [HttpPost]
    public async Task<ActionResult<CreateEmployeeResponse>> CreateEmployeeAsync(CreateEmployeeRequest request, CancellationToken ct = default)
    {
        CreateEmployeeResponse response;

        try
        {
            response = await _repository.CreateEmployeeAsync(request, ct);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdateEmployeeResponse>> UpdateEmployeeAsync(UpdateEmployeeRequest request, CancellationToken ct = default)
    {
        UpdateEmployeeResponse response;

        try
        {
            response = await _repository.UpdateEmployeeAsync(request, ct);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return Ok(response);
    }

    [HttpDelete]
    public async Task<ActionResult<DeleteEmployeeResponse>> DeleteEmployeesAsync(DeleteEmployeeRequest request, CancellationToken ct = default)
    {
        DeleteEmployeeResponse response;

        try
        {
            response = await _repository.DeleteEmployeeAsync(request, ct);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return Ok(response);
    }
}