using System.ComponentModel.DataAnnotations;
using webAPI_dotnet.Enums;

namespace webAPI_dotnet.Models
{
    public class EmployeeModel
    {
      [Key]
      public int Id { get; set; }
      public string Name { get; set; }
      public string LastName { get; set; }
      public DepartmentEnum Department { get; set; }
      public bool Active { get; set; }
      public ShiftEnum Shift { get; set; }
      public DateTime CreatedAt { get; set; } = DateTime.Now.ToLocalTime();
      public DateTime UpdatedAt { get; set; } = DateTime.Now.ToLocalTime();
    }
}
