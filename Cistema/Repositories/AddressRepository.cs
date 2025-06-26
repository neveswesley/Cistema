using Cistema.Database;
using Cistema.Models;
using Cistema.Models.DTO;
using Cistema.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cistema.Repositories;

public class AddressRepository : IAddressRepository
{
    private readonly CistemaDbContext _context;

    public AddressRepository(CistemaDbContext context)
    {
        _context = context;
    }

    public async Task<List<AddressInfoDTO>> GetAll()
    {
        var addresses = await _context.Addresses
            .Select(c => new AddressInfoDTO
            {
                CEP = c.CEP,
                Street = c.Street,
                Number = c.Number,
                AddressLine2 = c.AddressLine2,
                Neighborhood = c.Neighborhood,
                City = c.City,
                State = c.State,
                EmployeeId = c.EmployeeId
            })
            .ToListAsync();
        return addresses;
    }

    public async Task<AddressInfoDTO> GetById(int id)
    {
        var address = await _context.Addresses
            .Where(a=>a.Id == id).Select(c => new AddressInfoDTO()
            {
                CEP = c.CEP,
                Street = c.Street,
                Number = c.Number,
                AddressLine2 = c.AddressLine2,
                Neighborhood = c.Neighborhood,
                City = c.City,
                State = c.State,
                EmployeeId = c.EmployeeId
            })
            .FirstOrDefaultAsync();
        return address;
    }

    public async Task<Address> GetEntityById(int id)
    {
        return await _context.Addresses.FindAsync(id);
    }

    public async Task<Address> Create(Address address)
    {
        _context.Addresses.Add(address);
        await _context.SaveChangesAsync();
        return address;
    }

    public async Task<Address> Update(Address address)
    {
        _context.Addresses.Update(address);
        await _context.SaveChangesAsync();
        return address;
    }

    public async Task Delete(int id)
    {
        var address = await _context.Addresses.FindAsync(id);
        if (address != null)
        {
            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
        }
    }
}