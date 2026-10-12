using System.ComponentModel.DataAnnotations;

namespace demowebapp.DTO;

public class CreateAccountDto
{
    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string AccountHolderName { get; set; } = string.Empty;

    [Required]
    [StringLength(30, MinimumLength = 1)]
    public string AccountNumber { get; set; } = string.Empty;

    [Range(typeof(decimal), "0", "9999999999999999.99")]
    public decimal Balance { get; set; }

    [Required]
    public string AccountType { get; set; } = string.Empty;
}