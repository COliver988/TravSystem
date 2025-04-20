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
}
