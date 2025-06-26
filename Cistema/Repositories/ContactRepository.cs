using Cistema.Database;
using Cistema.Models;
using Cistema.Models.DTO;
using Cistema.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cistema.Repositories;

public class ContactRepository : IContactRepository
{
    
    private readonly CistemaDbContext _context;

    public ContactRepository(CistemaDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<ContactInfoDTO>> GetAll()
    {
        var contacts = await _context.Contacts
            .Select(c => new ContactInfoDTO
            {
                Phone = c.Phone,
                Mobile = c.Mobile,
                Email = c.Email,
                EmployeeId = c.EmployeeId
            })
            .ToListAsync();
        return contacts;
    }

    public async Task<ContactInfoDTO> GetById(int id)
    {
        var contact = await _context.Contacts
            .Where(a=>a.Id == id)
            .Select(c => new ContactInfoDTO
            {
                Phone = c.Phone,
                Mobile = c.Mobile,
                Email = c.Email,
                EmployeeId = c.EmployeeId
            })
            .FirstOrDefaultAsync();
        return contact;
    }

    public async Task<Contact> GetEntityById(int id)
    {
        return await _context.Contacts.FindAsync(id);
    }

    public async Task<Contact> Add(Contact contact)
    {
        _context.Contacts.Add(contact);
        await _context.SaveChangesAsync();
        return contact;
    }

    public async Task<Contact> Update(Contact contact)
    {
        _context.Contacts.Update(contact);
        await _context.SaveChangesAsync();
        return contact;
    }

    public async Task Delete(int id)
    {
        var contact = await _context.Contacts.FindAsync(id);
        if (contact != null)
        {
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
        }
    }
}