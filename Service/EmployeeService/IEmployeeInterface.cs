using webAPI_dotnet.Models;

namespace webAPI_dotnet.Service.EmployeeService
{
  public interface IEmployeeInterface
  {
    Task<ServiceResponse<List<EmployeeModel>>> GetEmployees();
    Task<ServiceResponse<List<EmployeeModel>>> CreateEmployee(EmployeeModel newEmployee);
    Task<ServiceResponse<EmployeeModel>> GetEmployeeById(int id);
    Task<ServiceResponse<List<EmployeeModel>>> UpdateEmployee(EmployeeModel updatedEmployee);
    Task<ServiceResponse<List<EmployeeModel>>> DeleteEmployee(int id);
    Task<ServiceResponse<List<EmployeeModel>>> DeactivateEmployee(int id);
  }
}
