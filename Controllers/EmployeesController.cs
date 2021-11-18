using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InMemoryDbAspNet6WebAPI.Controllers;

[Route("api/v2/[controller]")]
[ApiController]
public class EmployeesController : Controller
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeesController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    // GET: api/v2/Employees/
    [HttpGet]
    public async Task<IEnumerable<Employee>> GetEmployees()
    {
        return await _employeeRepository.GetEmployees();
    }

    // GET: api/v2/Employees/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployee([FromRoute] int id)
    {
        var employee = await _employeeRepository.FindEmployeeAsync(id);
        if (employee == null)
        {
            return NotFound();
        }
        return Ok(employee);
    }

    // POST: api/v2/Employees
    [HttpPost]
    public async Task<IActionResult> PostEmployee([FromBody] Employee employee)
    {
        await _employeeRepository.AddEmployeeAsync(employee);
        return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
    }

    // DELETE: api/v2/Employees/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
    {
        var employee = await _employeeRepository.DeleteEmployeeAsync(id);
        if (employee == null)
        {
            return NotFound();
        }
        return Ok(employee);
    }



    // PUT: api/v2/Employees/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutEmployee([FromRoute] int id, [FromBody] Employee employee)
    {
        if (id != employee.Id)
        {
            return BadRequest();
        }
        await _employeeRepository.UpdateEmployeeAsync(employee);
        return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
    }

}
