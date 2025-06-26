using Cistema.Models;
using Cistema.Models.DTO;

namespace Cistema.Repositories.Interfaces;

public interface IContactRepository
{
    Task<List<ContactInfoDTO>> GetAll();
    Task<ContactInfoDTO> GetById(int id);
    Task<Contact> GetEntityById(int id);

    Task<Contact> Add(Contact contact);
    Task<Contact> Update(Contact contact);
    Task Delete(int id);
}