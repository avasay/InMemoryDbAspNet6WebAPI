﻿
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InMemoryDbAspNet6WebAPI;
public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> GetEmployeesAsync();

    Task<Employee> GetEmployeeByIdAsync(int id);

    Task<Employee> GetEmployeeByEmailAsync(string email);

    Task<Employee> AddEmployeeAsync(Employee employee);

    Task<Employee> DeleteEmployeeAsync(int id);

    Task<Employee> UpdateEmployeeAsync(int id, Employee employee);

    Task<Employee> UpdateEmployeePatchAsync(int id, JsonPatchDocument employee);
}
