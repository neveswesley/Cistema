using Cistema.Models;
using Cistema.Models.DTO;

namespace Cistema.Repositories.Interfaces;

public interface IEmployeeRepository
{
    Task<List<EmployeeReadDTO>> GetAll(int page, int pageSize);
    Task<int> CountAsync();
    Task<EmployeeDetailsDTO> GetById(int id);
    Task<Employee> GetEntityById(int id);
    Task<Employee> Add(Employee employee);
    Task<Employee> Update(Employee employee);
    Task Delete(int id);
    
    
}