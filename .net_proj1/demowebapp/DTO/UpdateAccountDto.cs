using System.ComponentModel.DataAnnotations;

namespace demowebapp.DTO;

public class UpdateAccountDto
{
    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string AccountHolderName { get; set; } = string.Empty;

    [Required]
    public string AccountType { get; set; } = string.Empty;
}