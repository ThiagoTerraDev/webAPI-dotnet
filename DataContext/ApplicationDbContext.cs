using Microsoft.EntityFrameworkCore;
using webAPI_dotnet.Models;

namespace webAPI_dotnet.DataContext
{
    public class ApplicationDbContext : DbContext
    {
      public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
      {
      }

      public DbSet<EmployeeModel> Employees { get; set; }
    }
}
