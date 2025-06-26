using Cistema.Models;
using Cistema.Models.DTO;

namespace Cistema.Repositories.Interfaces;

public interface ITitleRepository
{
    Task<List<TitleInfoDTO>> GetAll();
    Task<TitleInfoDTO> GetById(int id);
    Task<Title> GetEntityById(int id);
    Task<Title> Add(Title title);
    Task<Title> Update(Title title);
    Task Delete(int id);
}