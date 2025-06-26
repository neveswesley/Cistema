using Cistema.Database;
using Cistema.Models;
using Cistema.Models.DTO;
using Cistema.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cistema.Repositories;

public class TitleRepository : ITitleRepository
{
    private readonly CistemaDbContext _context;

    public TitleRepository(CistemaDbContext context)
    {
        _context = context;
    }

    public async Task<List<TitleInfoDTO>> GetAll()
    {
        var titles = await _context.Titles.Select(t => new TitleInfoDTO
        {
            Name = t.Name,
            Department = t.Department,
            Description = t.Description
        }).ToListAsync();
        return titles;
    }

    public async Task<TitleInfoDTO> GetById(int id)
    {
        var title = await _context.Titles
            .Where(t => t.Id == id)
            .Select(t => new TitleInfoDTO
            {
                Name = t.Name,
                Department = t.Department,
                Description = t.Description
            }).FirstOrDefaultAsync();

        return title;
    }

    public async Task<Title> GetEntityById(int id)
    {
        var title = await _context.Titles.FirstOrDefaultAsync(t => t.Id == id);
        return title;
    }

    public async Task<Title> Add(Title title)
    {
        _context.Titles.Add(title);
        await _context.SaveChangesAsync();
        return title;
    }

    public async Task<Title> Update(Title title)
    {
        _context.Titles.Update(title);
        await _context.SaveChangesAsync();
        return title;
    }

    public async Task Delete(int id)
    {
        var title = await _context.Titles.FindAsync(id);
        if (title != null)
        {
            _context.Titles.Remove(title);
            await _context.SaveChangesAsync();
        }
    }
}