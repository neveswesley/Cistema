using Cistema.Models;
using Cistema.Models.DTO;

namespace Cistema.Repositories.Interfaces;

public interface IAddressRepository
{
    Task<List<AddressInfoDTO>> GetAll();
    Task<AddressInfoDTO> GetById(int id);
    Task<Address> GetEntityById(int id);

    Task<Address> Create(Address address);
    Task<Address> Update(Address address);
    Task Delete(int id);
}