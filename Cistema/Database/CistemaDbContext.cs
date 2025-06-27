using Cistema.Models;
using Cistema.Models.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cistema.Database;

public class CistemaDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{
    public CistemaDbContext(DbContextOptions<CistemaDbContext> options) : base(options)
    {
        
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Title> Titles { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }


    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employee>()
            .HasOne(t => t.Title)
            .WithMany(e => e.Employees)
            .HasForeignKey(te => te.TitleId);

        modelBuilder.Entity<Employee>()
            .HasOne(a => a.Address)
            .WithOne(e => e.Employee)
            .HasForeignKey<Address>(ae => ae.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Contact)
            .WithOne(c => c.Employee)
            .HasForeignKey<Contact>(c => c.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Employee>()
            .Property(e => e.Salary)
            .HasPrecision(18, 2);
    }
}