using webAPI_dotnet.DataContext;
using webAPI_dotnet.Models;

namespace webAPI_dotnet.Service.EmployeeService
{
  public class EmployeeService : IEmployeeInterface
  { 
    private readonly ApplicationDbContext _context;
    public EmployeeService(ApplicationDbContext context)
    {
      _context = context;
    }
    public async Task<ServiceResponse<List<EmployeeModel>>> GetEmployees()
    {
      ServiceResponse<List<EmployeeModel>> serviceResponse = new ServiceResponse<List<EmployeeModel>>();

      try 
      {
        serviceResponse.Data = _context.Employees.ToList();

        if(serviceResponse.Data.Count == 0)
        {
          serviceResponse.Message = "No employees found!";
        }
      }catch (Exception ex)
      {
        serviceResponse.Message = ex.Message;
        serviceResponse.Success = false;
      }

      return serviceResponse;
    }

    public async Task<ServiceResponse<List<EmployeeModel>>> CreateEmployee(EmployeeModel newEmployee)
    {
      ServiceResponse<List<EmployeeModel>> serviceResponse = new ServiceResponse<List<EmployeeModel>>();

      try 
      {
        if(newEmployee == null)
        {
          serviceResponse.Data = null;
          serviceResponse.Message = "Please provide employee data!";
          serviceResponse.Success = false;
          return serviceResponse;
        }

        _context.Employees.Add(newEmployee);
        await _context.SaveChangesAsync();

        serviceResponse.Data = _context.Employees.ToList();
      }catch (Exception ex)
      {
        serviceResponse.Message = ex.Message;
        serviceResponse.Success = false;
      }

      return serviceResponse;

    }

    public async Task<ServiceResponse<EmployeeModel>> GetEmployeeById(int id)
    {
      ServiceResponse<EmployeeModel> serviceResponse = new ServiceResponse<EmployeeModel>();

      try 
      {
        EmployeeModel employee = _context.Employees.FirstOrDefault(e => e.Id == id);

        if(employee == null)
        {
          serviceResponse.Data = null;
          serviceResponse.Message = "Employee not found!";
          serviceResponse.Success = false;
          return serviceResponse;
        }

        serviceResponse.Data = employee;
      }catch (Exception ex)
      {
        serviceResponse.Message = ex.Message;
        serviceResponse.Success = false;
      }

      return serviceResponse;
    }

    public Task<ServiceResponse<List<EmployeeModel>>> UpdateEmployee(EmployeeModel updatedEmployee)
    {
      throw new NotImplementedException();
    }

    public Task<ServiceResponse<List<EmployeeModel>>> DeleteEmployee(int id)
    {
      throw new NotImplementedException();
    }

    public Task<ServiceResponse<List<EmployeeModel>>> DeactivateEmployee(int id)
    {
      throw new NotImplementedException();
    }
  }
}
