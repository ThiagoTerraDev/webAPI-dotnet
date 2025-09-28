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
      return Ok(await _employeeInterface.GetEmployees());
    }
  }
}
