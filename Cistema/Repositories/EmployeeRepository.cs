using Cistema.Database;
using Cistema.Models;
using Cistema.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Cistema.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly CistemaDbContext _context;

    public EmployeeRepository(CistemaDbContext context)
    {
        _context = context;
    }

    public async Task<List<Employee>> GetAll()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task<Employee> GetById(int id)
    {
        var employee = await _context.Employees.FirstOrDefaultAsync(a=>a.Id == id);
        return employee;
    }

    public async Task<Employee> Add(Employee employee)
    {
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task<Employee> Update(Employee employee)
    {
        _context.Employees.Update(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task Delete(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee != null)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
    }
}