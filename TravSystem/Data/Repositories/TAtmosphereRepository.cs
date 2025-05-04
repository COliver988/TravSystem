using Microsoft.EntityFrameworkCore;
using MyEfCoreApp.Data;
using TravSystem.Models;

namespace TravSystem.Data.Repositories;

public class TAtmosphereRepository : ITAtmopshereRepository
{

    private readonly TravellerDBContext _context;

    public TAtmosphereRepository(TravellerDBContext context)
    {
        _context = context;
    }

    public async Task<TAtmosphere> Add(TAtmosphere atmosphere)
    {
        _context.Add(atmosphere);
        await _context.SaveChangesAsync();
        return atmosphere;
    }

    public async Task Delete(TAtmosphere atmosphere)
    {
        _context.Atmospheres.Remove(atmosphere);
        await _context.SaveChangesAsync();
    }

    public async Task<List<TAtmosphere>> GetAll() => await _context.Atmospheres.ToListAsync();

    public Task<TAtmosphere?> GetByID(int id) => _context.Atmospheres.Where(p => p.Id == id).FirstOrDefaultAsync();
    public Task<TAtmosphere?> GetByHexCode(string hexcode) => _context.Atmospheres.Where(p => p.HexCode == hexcode).FirstOrDefaultAsync();

    public async Task<TAtmosphere> Update(TAtmosphere atmosphere)
    {
        _context.Atmospheres.Update(atmosphere);
        await _context.SaveChangesAsync();
        return atmosphere;
    }
}
