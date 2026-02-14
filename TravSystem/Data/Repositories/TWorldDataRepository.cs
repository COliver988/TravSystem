using Microsoft.EntityFrameworkCore;
using MyEfCoreApp.Data;
using TravSystem.Models;

namespace TravSystem.Data.Repositories;

public class TWorldDataRepository : ITWorldDataRepository
{
    private readonly TravellerDBContext _context;

    public TWorldDataRepository(TravellerDBContext context)
    {
        _context = context;
    }

    public async Task<TWorldData> Add(TWorldData worldData)
    {
        _context.Add(worldData);
        await _context.SaveChangesAsync();
        return worldData;
    }

    public Task Delete(TWorldData worldData)
    {
        throw new NotImplementedException();
    }

    public async Task<List<TWorldData>> GetAll() => await _context.WorldData.ToListAsync();

    public async Task<TWorldData?> GetByHexCode(string hexcode) => await _context.WorldData.Where(w => w.WorldSize == hexcode).FirstOrDefaultAsync();

    public async Task<TWorldData?> GetByID(int id) => await _context.WorldData.FindAsync(id);

    public async Task<TWorldData> Update(TWorldData worldData)
    {
        _context.Update(worldData);
        await _context.SaveChangesAsync();
        return worldData;
    }
}
