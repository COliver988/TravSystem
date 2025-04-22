using Microsoft.EntityFrameworkCore;
using MyEfCoreApp.Data;
using TravSystem.Models;

namespace TravSystem.Data.Repositories;

public class TStarportRepository : ITStarportRepository
{
    private readonly TravellerDBContext _context;

    public TStarportRepository(TravellerDBContext context)
    {
        _context = context;
    }

    public async Task<List<TStarport>> GetAll() => await _context.Starports.ToListAsync();
    public async Task<TStarport?> GetByID(int id) => await _context.Starports.Where(s => s.Id == id).FirstOrDefaultAsync();
    public async Task<TStarport> Add(TStarport starport)
    {
        _context.Starports.Add(starport);
        await _context.SaveChangesAsync();
        return starport;
    }
    public async Task<TStarport> Update(TStarport starport)
    {
        _context.Starports.Update(starport);
        await _context.SaveChangesAsync();
        return starport;
    }

    public async Task Delete(TStarport starport)
    {
        _context.Starports.Remove(starport);
        await _context.SaveChangesAsync();
    }

}
