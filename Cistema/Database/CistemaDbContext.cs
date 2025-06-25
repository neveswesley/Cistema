using Cistema.Models;
using Microsoft.EntityFrameworkCore;

namespace Cistema.Database;

public class CistemaDbContext : DbContext
{
    public CistemaDbContext(DbContextOptions<CistemaDbContext> options) : base(options)
    {
        
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Title> Titles { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Contact> Contacts { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .HasOne(t => t.Title)
            .WithMany(e => e.Employees)
            .HasForeignKey(te => te.TitleId);

        modelBuilder.Entity<Employee>()
            .HasOne(a => a.Address)
            .WithOne(e => e.Employee)
            .HasForeignKey<Address>(ae => ae.EmployeeId);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Contact)
            .WithOne(c => c.Employee)
            .HasForeignKey<Contact>(ec => ec.EmployeeId);
    }
}