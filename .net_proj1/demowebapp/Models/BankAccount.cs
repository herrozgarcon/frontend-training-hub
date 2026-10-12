using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace demowebapp.Models;

public class BankAccount
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string AccountHolderName { get; set; } = string.Empty;

    [Required]
    [MaxLength(30)]
    public string AccountNumber { get; set; } = string.Empty;

    [Precision(18, 2)]
    [Range(typeof(decimal), "0", "9999999999999999.99")]
    public decimal Balance { get; set; }

    [Required]
    [MaxLength(20)]
    public string AccountType { get; set; } = string.Empty;
}