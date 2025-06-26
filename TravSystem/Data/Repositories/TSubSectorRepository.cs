using Microsoft.EntityFrameworkCore;
using MyEfCoreApp.Data;
using TravSystem.Models;

namespace TravSystem.Data.Repositories;

public class TSubSectorRepository : ITSubSectorRepository
{

    private readonly TravellerDBContext _context;
    public TSubSectorRepository(TravellerDBContext travellerDBContext)
    {
        this._context = travellerDBContext;
    }

    public async Task<TSubSector> Add(TSubSector subsector)
    {
        _context.SubSectors.Add(subsector);
        await _context.SaveChangesAsync();
        return subsector;
    }

    public async Task Delete(TSubSector subsector)
    {
        _context.SubSectors.Remove(subsector);
        await _context.SaveChangesAsync();
    }

    public async Task<List<TSubSector>> GetAll() => await _context.SubSectors.ToListAsync();

    public async Task<TSubSector> GetByID(int id) => await _context.SubSectors
        .Include(s => s.Systems).FirstOrDefaultAsync(x => x.Id == id);

    public async Task<TSubSector> Update(TSubSector subsector)
    {
        _context.Update(subsector);
        await _context.SaveChangesAsync();
        return subsector;
    }
}
