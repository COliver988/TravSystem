using Microsoft.EntityFrameworkCore;
using MyEfCoreApp.Data;
using TravSystem.Models;

namespace TravSystem.Data.Repositories;

public class StellarDataRepository : IStellarDataRepository
{
    private TravellerDBContext _context;
    
    public StellarDataRepository(TravellerDBContext context)
    {
        _context = context;
    }

    public async Task<StellarData> AddAsync(StellarData stellarData)
    {
        _context.StellarData.Add(stellarData);
        await _context.SaveChangesAsync();
        return stellarData;
    }

    public async Task DeleteAsync(StellarData stellarData)
    {
        _context.StellarData.Remove(stellarData);
        await _context.SaveChangesAsync();
    }

    public async Task<List<StellarData>> GetAllAsync() => await _context.StellarData
        .Include(s => s.StarType)
        .Include(s => s.StellarType)
        .ToListAsync();

    public async Task<StellarData> GetByIdAsync(int id) => await _context.StellarData
        .Include(s => s.StarType)
        .Include(s => s.StellarType)
        .Where(p => p.Id == id).FirstOrDefaultAsync();

    public async Task<StellarData> GetByTypeAndSize(int starTypeId, int stellarTypeId) => await _context.StellarData
        .Where(p => p.StarTypeId == starTypeId && p.StellarTypeId == stellarTypeId).FirstOrDefaultAsync();

    public async Task UpdateAsync(StellarData stellarData)
    {
        await _context.SaveChangesAsync();
    }
}
