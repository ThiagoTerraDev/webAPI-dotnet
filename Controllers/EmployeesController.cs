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
        ServiceResponse<List<EmployeeModel>> serviceResponse = await _employeeInterface.GetEmployees();
        
        if (!serviceResponse.Success)
        {
          return BadRequest(serviceResponse);
        }
        
        return Ok(serviceResponse);
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
        ServiceResponse<List<EmployeeModel>> serviceResponse = await _employeeInterface.CreateEmployee(newEmployee);
        
        if (!serviceResponse.Success)
        {
          return BadRequest(serviceResponse);
        }
        
        return CreatedAtAction(nameof(GetEmployees), serviceResponse);
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

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<EmployeeModel>>> GetEmployeeById(int id)
    {
    try
    {
        ServiceResponse<EmployeeModel> serviceResponse = await _employeeInterface.GetEmployeeById(id);
        
        if (!serviceResponse.Success)
        {
          return BadRequest(serviceResponse);
        }
        
        return Ok(serviceResponse);
    }
    catch (Exception)
    {
        return StatusCode(500, new ServiceResponse<EmployeeModel>
        {
          Data = null,
          Message = "Internal server error",
          Success = false
        });
    }
    }
  }
}
