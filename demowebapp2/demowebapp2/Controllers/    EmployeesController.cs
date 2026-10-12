using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using demowebapp2.Data;
using demowebapp2.Models;
using System.ComponentModel.DataAnnotations;

namespace demowebapp2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public EmployeesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/employees?department=IT
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees(
        [FromQuery] string? department)
    {
        var query = _context.Employees.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(department))
        {
            query = query.Where(e => e.Department == department);
        }

        var employees = await query
            .OrderBy(e => e.Id)
            .ToListAsync();

        return Ok(employees);
    }

    // GET: api/employees/1
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Employee>> GetEmployee(int id)
    {
        var employee = await _context.Employees.FindAsync(id);

        if (employee == null)
        {
            return NotFound(new { message = "Employee not found." });
        }

        return Ok(employee);
    }

    // POST: api/employees
    [HttpPost]
    public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
    {
        employee.Id = 0;

        var email = employee.Email.Trim();

        if (!new EmailAddressAttribute().IsValid(email))
        {
            return BadRequest(new { message = "Enter a valid email address." });
        }

        employee.Email = email;

        bool emailExists = await _context.Employees
            .AnyAsync(e => e.Email == employee.Email);

        if (emailExists)
        {
            return Conflict(new { message = "An employee with this email already exists." });
        }

        _context.Employees.Add(employee);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            if (await _context.Employees.AnyAsync(
                e => e.Email == employee.Email))
            {
                return Conflict(new { message = "An employee with this email already exists." });
            }

            throw;
        }

        return CreatedAtAction(
            nameof(GetEmployee),
            new { id = employee.Id },
            employee);
    }

    // PUT: api/employees/1
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateEmployee(
        int id,
        Employee employee)
    {
        if (id != employee.Id)
        {
            return BadRequest(new { message = "Route ID and employee ID must match." });
        }

        var existingEmployee = await _context.Employees.FindAsync(id);

        if (existingEmployee == null)
        {
            return NotFound(new { message = "Employee not found." });
        }

        employee.Email = employee.Email.Trim();

        if (!new EmailAddressAttribute().IsValid(employee.Email))
        {
            return BadRequest(new { message = "Enter a valid email address." });
        }

        bool emailExists = await _context.Employees.AnyAsync(
            e => e.Email == employee.Email && e.Id != id);

        if (emailExists)
        {
            return Conflict(new { message = "Another employee already uses this email." });
        }

        existingEmployee.FullName = employee.FullName;
        existingEmployee.Email = employee.Email;
        existingEmployee.Department = employee.Department;
        existingEmployee.JobTitle = employee.JobTitle;
        existingEmployee.Salary = employee.Salary;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            if (await _context.Employees.AnyAsync(
                e => e.Email == employee.Email && e.Id != id))
            {
                return Conflict(new { message = "Another employee already uses this email." });
            }

            throw;
        }

        return Ok(existingEmployee);
    }

    // DELETE: api/employees/1
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        var employee = await _context.Employees.FindAsync(id);

        if (employee == null)
        {
            return NotFound(new { message = "Employee not found." });
        }

        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}