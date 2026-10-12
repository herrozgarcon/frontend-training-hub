using Microsoft.EntityFrameworkCore;
using demowebapp2.Models;

namespace demowebapp2.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employee>()
            .HasIndex(e => e.Email)
            .IsUnique();

        modelBuilder.Entity<Employee>()
            .Property(e => e.Salary)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Employee>()
            .Property(e => e.Email)
            .HasMaxLength(255);

        modelBuilder.Entity<Employee>()
            .Property(e => e.FullName)
            .HasMaxLength(100);

        modelBuilder.Entity<Employee>()
            .Property(e => e.Department)
            .HasMaxLength(100);

        modelBuilder.Entity<Employee>()
            .Property(e => e.JobTitle)
            .HasMaxLength(100);
    }
}