
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InMemoryDbAspNet6WebAPI;
public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> GetEmployees();

    Task<Employee> FindEmployeeAsync(int id);

    Task<Employee> AddEmployeeAsync(Employee employee);

    Task<Employee> DeleteEmployeeAsync(int id);

    Task<Employee> UpdateEmployeeAsync(Employee employee);
}
