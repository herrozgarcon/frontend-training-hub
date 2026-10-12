using demowebapp.Models;
using Microsoft.EntityFrameworkCore;

namespace demowebapp.Data;

public class BankingDbContext : DbContext
{
    public BankingDbContext(
        DbContextOptions<BankingDbContext> options)
        : base(options)
    {
    }

    public DbSet<BankAccount> BankAccounts => Set<BankAccount>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<BankAccount>(entity =>
        {
            entity.HasKey(account => account.Id);

            entity.HasIndex(account => account.AccountNumber)
                  .IsUnique();

            entity.Property(account => account.AccountHolderName)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(account => account.AccountNumber)
                  .IsRequired()
                  .HasMaxLength(30);

            entity.Property(account => account.Balance)
                  .HasPrecision(18, 2);

            entity.Property(account => account.AccountType)
                  .IsRequired()
                  .HasMaxLength(20);

            entity.ToTable(table =>
                table.HasCheckConstraint(
                    "CK_BankAccounts_Balance_NonNegative",
                    "[Balance] >= 0"));
        });
    }
}