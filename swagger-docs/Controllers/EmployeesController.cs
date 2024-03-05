using swagger_docs.Models;

namespace swagger_docs.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private static List<Employee> employees = new List<Employee>
    {
        new Employee { Id = 1, FirstName = "John", LastName = "Doe", Position = "Developer" },
        new Employee { Id = 2, FirstName = "Jane", LastName = "Smith", Position = "Designer" }
    };

    [HttpGet]
    public ActionResult<IEnumerable<Employee>> GetEmployees()
    {
        return Ok(employees);
    }

    [HttpGet("{id}")]
    public ActionResult<Employee> GetEmployee(int id)
    {
        var employee = employees.Find(e => e.Id == id);

        if (employee == null)
            return NotFound();

        return Ok(employee);
    }

    [HttpPost]
    public ActionResult<Employee> CreateEmployee(Employee employee)
    {
        employee.Id = employees.Count + 1;
        employees.Add(employee);

        return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
    }

    [HttpPut("{id}")]
    public ActionResult<Employee> UpdateEmployee(int id, Employee updatedEmployee)
    {
        var existingEmployee = employees.Find(e => e.Id == id);

        if (existingEmployee == null)
            return NotFound();

        existingEmployee.FirstName = updatedEmployee.FirstName;
        existingEmployee.LastName = updatedEmployee.LastName;
        existingEmployee.Position = updatedEmployee.Position;

        return Ok(existingEmployee);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteEmployee(int id)
    {
        var employee = employees.Find(e => e.Id == id);

        if (employee == null)
            return NotFound();

        employees.Remove(employee);

        return NoContent();
    }
}
