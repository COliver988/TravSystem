using Microsoft.EntityFrameworkCore;
using MyEfCoreApp.Data;
using TravSystem.Models;

namespace TravSystem.Data.Repositories;

public class StarTypeRepository : IStarTypeRepository
{
    private readonly TravellerDBContext _context;

    public StarTypeRepository(TravellerDBContext context)
    {
        _context = context;
    }

    public async Task<List<StarType>> GetAll() => await _context.StarTypes.ToListAsync();

    public async Task<StarType?> GetByID(int id) => await _context.StarTypes.Where(p => p.Id == id).FirstOrDefaultAsync();

    public async Task<StarType> Update(StarType starType)
    {
        _context.StarTypes.Update(starType);
        await _context.SaveChangesAsync();
        return starType;
    }
}
