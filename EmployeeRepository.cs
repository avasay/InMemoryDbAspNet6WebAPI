
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace InMemoryDbAspNet6WebAPI;
public class EmployeeRepository : IEmployeeRepository
{
    private readonly EmployeeDBContext _dbContext;

    public EmployeeRepository(EmployeeDBContext dBContext)
    {
        _dbContext = dBContext;
    }

    public async Task<IEnumerable<Employee>> GetEmployees()
    {
        var query = (from employees in _dbContext.Employees
                      select employees).ToListAsync();
        return await query;
    }

    public async Task<Employee> FindEmployeeAsync(int id)
    {
        Employee employee = await _dbContext.Employees.FindAsync(id);
        return employee;

    }

    public async Task<Employee> AddEmployeeAsync(Employee employee)
    {
        _dbContext.Employees.Add(employee);
        await _dbContext.SaveChangesAsync();

        return employee;
    }

    public async Task<Employee> DeleteEmployeeAsync(int id)
    {
        var employee = await FindEmployeeAsync(id);
        if(employee == null)
        {
            return employee;
        }
        _dbContext.Employees.Remove(employee);
        await _dbContext.SaveChangesAsync();

        return employee;

    }

  
    public async Task<Employee> UpdateEmployeeAsync(Employee employee)
    {
        _dbContext.Entry(employee).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();

        return employee;
    }
}
