using System.ComponentModel.DataAnnotations;

namespace demowebapp2.Models;

public class Employee
{
    public int Id { get; set; }

    [Required]
    public string FullName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Department { get; set; } = string.Empty;

    [Required]
    public string JobTitle { get; set; } = string.Empty;

    [Range(typeof(decimal), "0.01", "9999999999999999999999999999")]
    public decimal Salary { get; set; }
}
