namespace demowebapp.Helpers;

public static class AccountValidation
{
    public static bool IsValidAccountType(string? accountType)
    {
        if (string.IsNullOrWhiteSpace(accountType))
        {
            return false;
        }

        var trimmed = accountType.Trim();
        return trimmed.Equals("Savings", StringComparison.OrdinalIgnoreCase) ||
               trimmed.Equals("Current", StringComparison.OrdinalIgnoreCase);
    }
}
