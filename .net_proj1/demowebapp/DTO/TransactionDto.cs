using System.ComponentModel.DataAnnotations;

namespace demowebapp.DTO;

public class TransactionDto
{
    [Range(typeof(decimal), "0.01", "9999999999999999.99")]
    public decimal Amount { get; set; }
}