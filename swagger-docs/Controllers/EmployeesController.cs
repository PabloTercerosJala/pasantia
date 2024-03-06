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
        new Employee { Id = 0, FirstName = "John", LastName = "Doe", Position = "Developer" },
        new Employee { Id = 1, FirstName = "Jane", LastName = "Smith", Position = "Designer" }
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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
    public ActionResult<Employee> UpdateEmployee(int id, Employee updatedEmployee)
    {
        if (Request.ContentType != null && !Request.ContentType.Contains("application/json"))
        {
            return StatusCode(StatusCodes.Status415UnsupportedMediaType, "Unsupported media type. Please use 'application/json'.");
        }

        var existingEmployee = employees.Find(e => e.Id == id);

        if (existingEmployee == null)
        {
            employees.Add(updatedEmployee);
            return CreatedAtAction(nameof(UpdateEmployee), new { id = updatedEmployee.Id }, updatedEmployee);
        }

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
