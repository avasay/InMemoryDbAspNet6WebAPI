﻿
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;

namespace InMemoryDbAspNet6WebAPI;
public class EmployeeRepository : IEmployeeRepository
{
    private readonly EmployeeDBContext _dbContext;

    public EmployeeRepository(EmployeeDBContext dBContext)
    {
        _dbContext = dBContext;
    }

    public async Task<IEnumerable<Employee>> GetEmployeesAsync()
    {
        var query = (from employees in _dbContext.Employees
                      select employees).ToListAsync();
        return await query;
    }

    public async Task<Employee> GetEmployeeByIdAsync(int id)
    {
        Employee employee = await _dbContext.Employees.FindAsync(id);
        return employee;

    }

    public async Task<Employee> GetEmployeeByEmailAsync(string email)
    {
        var employee = (from x in _dbContext.Employees
                    where x.Email == email
                    select x).FirstOrDefault();
                    
        //Employee employee = await _dbContext.Employees.FindAsync(id);
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
        var employee = await GetEmployeeByIdAsync(id);
        if(employee == null)
        {
            return employee;
        }
        _dbContext.Employees.Remove(employee);
        await _dbContext.SaveChangesAsync();

        return employee;

    }

    public async Task<Employee> UpdateEmployeeAsync(int id, Employee employee)
    {
        var employeeQuery = await GetEmployeeByIdAsync(id);
        if(employeeQuery == null)
        {
            return employeeQuery;
        }
        
        _dbContext.Entry(employeeQuery).CurrentValues.SetValues(employee);
        await _dbContext.SaveChangesAsync();

        return employeeQuery;
    }

    public async Task<Employee> UpdateEmployeePatchAsync(int id, JsonPatchDocument employeeDocument)
    {
        var employeeQuery = await GetEmployeeByIdAsync(id);
        if (employeeQuery == null)
        {
            return employeeQuery;
        }
        employeeDocument.ApplyTo(employeeQuery);
        await _dbContext.SaveChangesAsync();

        return employeeQuery;
    }
}
