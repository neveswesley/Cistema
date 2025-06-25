using Cistema.Models;

namespace Cistema.Repositories.Interfaces;

public interface IAddressRepository
{
    Task<List<Address>> GetAll();
    Task<Address> GetById(int id);
    Task<Address> Create(Address address);
    Task<Address> Update(Address address);
    Task Delete(int id);
}