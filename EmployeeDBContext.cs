
using Microsoft.EntityFrameworkCore;

namespace InMemoryDbAspNet6WebAPI;
public class EmployeeDBContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options)
        : base(options)
    {

    }
}
