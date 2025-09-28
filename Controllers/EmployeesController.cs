using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using webAPI_dotnet.Service.EmployeeService;
using System.Threading.Tasks;
using webAPI_dotnet.Models;

namespace webAPI_dotnet.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EmployeesController : ControllerBase
  {
    private readonly IEmployeeInterface _employeeInterface;
    public EmployeesController(IEmployeeInterface employeeInterface)
    {
      _employeeInterface = employeeInterface;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<EmployeeModel>>>> GetEmployees()
    {
    try
    {
        var result = await _employeeInterface.GetEmployees();
        
        if (!result.Success)
        {
          return BadRequest(result);
        }
        
        return Ok(result);
    }
    catch (Exception)
    {
        return StatusCode(500, new ServiceResponse<List<EmployeeModel>>
        {
          Data = null,
          Message = "Internal server error",
          Success = false
        });
    }
}

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<List<EmployeeModel>>>> CreateEmployee(EmployeeModel newEmployee)
    {
    try
    {
        var result = await _employeeInterface.CreateEmployee(newEmployee);
        
        if (!result.Success)
        {
          return BadRequest(result);
        }
        
        return CreatedAtAction(nameof(GetEmployees), result);
    }
    catch (Exception)
    {
        return StatusCode(500, new ServiceResponse<List<EmployeeModel>>
        {
          Data = null,
          Message = "Internal server error",
          Success = false
        });
    }
}
  }
}
