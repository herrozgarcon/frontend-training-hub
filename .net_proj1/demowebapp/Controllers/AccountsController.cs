using demowebapp.Data;
using demowebapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using demowebapp.DTO;
using demowebapp.Helpers;
namespace demowebapp.Controllers;

[ApiController]
[Route("api/accounts")]
public class AccountsController : ControllerBase
{
    private readonly BankingDbContext _context;

    public AccountsController(BankingDbContext context)
    {
        _context = context;
    }

    // GET: /api/accounts
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BankAccount>>> GetAllAccounts()
    {
        var accounts = await _context.BankAccounts
            .AsNoTracking()
            .OrderBy(a => a.Id)
            .ToListAsync();

        return Ok(accounts);
    }

    // GET: /api/accounts/1
    [HttpGet("{id:int}")]
    public async Task<ActionResult<BankAccount>> GetAccountById(int id)
    {
        var account = await _context.BankAccounts
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);

        if (account is null)
        {
            return NotFound(new
            {
                message = "Account not found."
            });
        }

        return Ok(account);
    }
    // POST: /api/accounts
    [HttpPost]
    public async Task<ActionResult<BankAccount>> CreateAccount(
        CreateAccountDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.AccountHolderName))
        {
            return BadRequest(new
            {
                message = "Account holder name is required."
            });
        }

        if (string.IsNullOrWhiteSpace(dto.AccountNumber))
        {
            return BadRequest(new
            {
                message = "Account number is required."
            });
        }

        if (dto.Balance < 0 ||
            dto.Balance > 9999999999999999.99m)
        {
            return BadRequest(new
            {
                message = "Opening balance is invalid."
            });
        }

        if (!AccountValidation.IsValidAccountType(dto.AccountType))
        {
            return BadRequest(new
            {
                message = "Account type must be Savings or Current."
            });
        }

        var accountNumber = dto.AccountNumber.Trim();

        if (await _context.BankAccounts.AnyAsync(
                a => a.AccountNumber == accountNumber))
        {
            return Conflict(new
            {
                message = "Account number already exists."
            });
        }

        var account = new BankAccount
        {
            AccountHolderName = dto.AccountHolderName.Trim(),
            AccountNumber = accountNumber,
            Balance = dto.Balance,
            AccountType = dto.AccountType.Trim().Equals(
                "Savings",
                StringComparison.OrdinalIgnoreCase)
                ? "Savings"
                : "Current"
        };

        _context.BankAccounts.Add(account);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            return Conflict(new
            {
                message = "Account number already exists or the account could not be saved."
            });
        }

        return CreatedAtAction(
            nameof(GetAccountById),
            new { id = account.Id },
            account);
    }

    //update
[HttpPut("{id:int}")]
public async Task<ActionResult<BankAccount>> UpdateAccount(
    int id,
    UpdateAccountDto dto)
{
    if (string.IsNullOrWhiteSpace(dto.AccountHolderName))
    {
        return BadRequest(new
        {
            message = "Account holder name is required."
        });
    }

    if (!AccountValidation.IsValidAccountType(dto.AccountType))
    {
        return BadRequest(new
        {
            message = "Account type must be Savings or Current."
        });
    }

    var account = await _context.BankAccounts
        .FirstOrDefaultAsync(a => a.Id == id);

    if (account is null)
    {
        return NotFound(new
        {
            message = "Account not found."
        });
    }

    account.AccountHolderName = dto.AccountHolderName.Trim();

    account.AccountType = dto.AccountType.Trim().Equals(
        "Savings",
        StringComparison.OrdinalIgnoreCase)
        ? "Savings"
        : "Current";

    await _context.SaveChangesAsync();

    return Ok(account);
}

//delete
[HttpDelete("{id:int}")]
public async Task<IActionResult> DeleteAccount(int id)
{
    var account = await _context.BankAccounts
        .FirstOrDefaultAsync(a => a.Id == id);

    if (account is null)
    {
        return NotFound(new
        {
            message = "Account not found."
        });
    }

    _context.BankAccounts.Remove(account);

    await _context.SaveChangesAsync();

    return NoContent();
}


    //deposit money 
    [HttpPost("{id:int}/deposit")]
public async Task<ActionResult<object>> Deposit(
    int id,
    TransactionDto dto)
{
    if (dto.Amount <= 0 ||
        dto.Amount > 9999999999999999.99m)
    {
        return BadRequest(new
        {
            message = "Deposit amount must be positive and within the supported limit."
        });
    }

    var account = await _context.BankAccounts
        .FirstOrDefaultAsync(a => a.Id == id);

    if (account is null)
    {
        return NotFound(new
        {
            message = "Account not found."
        });
    }

    var newBalance = account.Balance + dto.Amount;

    if (newBalance > 9999999999999999.99m)
    {
        return BadRequest(new
        {
            message = "Resulting balance exceeds the supported limit."
        });
    }

    account.Balance = newBalance;

    await _context.SaveChangesAsync();

    return Ok(new
    {
        message = "Deposit successful.",
        accountId = account.Id,
        balance = account.Balance
    });
}

    //widhdraw money 
    [HttpPost("{id:int}/withdraw")]
public async Task<ActionResult<object>> Withdraw(
    int id,
    TransactionDto dto)
{
    if (dto.Amount <= 0 ||
        dto.Amount > 9999999999999999.99m)
    {
        return BadRequest(new
        {
            message = "Withdrawal amount must be positive and within the supported limit."
        });
    }

    var account = await _context.BankAccounts
        .FirstOrDefaultAsync(a => a.Id == id);

    if (account is null)
    {
        return NotFound(new
        {
            message = "Account not found."
        });
    }

    if (dto.Amount > account.Balance)
    {
        return BadRequest(new
        {
            message = "Insufficient balance."
        });
    }

    account.Balance -= dto.Amount;

    await _context.SaveChangesAsync();

    return Ok(new
    {
        message = "Withdrawal successful.",
        accountId = account.Id,
        balance = account.Balance
    });
}


    //search account
    [HttpGet("search")]
public async Task<ActionResult<IEnumerable<BankAccount>>> SearchAccounts(
    [FromQuery] string accountHolderName)
{
    if (string.IsNullOrWhiteSpace(accountHolderName))
    {
        return BadRequest(new
        {
            message = "Account holder name is required."
        });
    }

    var searchTerm = accountHolderName.Trim();

    var accounts = await _context.BankAccounts
        .AsNoTracking()
        .Where(a => EF.Functions.Like(
            a.AccountHolderName,
            $"%{searchTerm}%"))
        .OrderBy(a => a.Id)
        .ToListAsync();

    return Ok(accounts);
}

}