using Cistema.Database;
using Cistema.Models;
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

    public async Task<List<Address>> GetAll()
    {
        var addresses = await _context.Addresses.ToListAsync();
        return addresses;
    }

    public async Task<Address> GetById(int id)
    {
        var address = await _context.Addresses.Include(a => a.Employee).FirstOrDefaultAsync(a => a.Id == id);
        return address;
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