using Cistema.Database;
using Cistema.Models;
using Cistema.Models.DTO;
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

    public async Task<EmployeeDetailsDTO> GetById(int id)
    {
        var employee = await _context.Employees
            .Where(e => e.Id == id)
            .Select(e => new EmployeeDetailsDTO()
        {
            Id = e.Id,
            PersonalInfo = new PersonalInfoDTO()
            {
                FullName = e.FullName,
                CPF = e.CPF,
                RG = e.RG,
                DateOfBirth = e.DateOfBirth,
                Gender = e.Gender,
                MaritalStatus = e.MaritalStatus,
                Nationality = e.Nationality,
                BirthPlace = e.BirthPlace
            },
            AddressInfo = new AddressInfoDTO()
            {
                CEP = e.Address.CEP,
                Street = e.Address.Street,
                Number = e.Address.Number,
                AddressLine2 = e.Address.AddressLine2,
                Neighborhood = e.Address.Neighborhood,
                City = e.Address.City,
                State = e.Address.State
            },
            ContactInfo = new ContactInfoDTO()
            {
                Phone = e.Contact.Phone,
                Mobile = e.Contact.Mobile,
                Email = e.Contact.Email
            },
            TitleInfo = new TitleInfoDTO()
            {
                Name = e.Title.Name,
                Department = e.Title.Department,
                Description = e.Title.Description
            },
            ContractInfo = new ContractInfoDTO()
            {
                Admission = e.Admission,
                Salary = e.Salary,
                CTPS = e.CTPS,
                PIS = e.PIS,
                Active = e.Active,
                Register = e.Register,
                Creator = e.Creator,
                LastUpdate = e.LastUpdate
            }
        }).FirstOrDefaultAsync();

        return employee;
    }
    
    public async Task<Employee> GetEntityById(int id)
    {
        return await _context.Employees
            .Include(e => e.Contract)  // se quiser incluir propriedades relacionadas
            .FirstOrDefaultAsync(e => e.Id == id);
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