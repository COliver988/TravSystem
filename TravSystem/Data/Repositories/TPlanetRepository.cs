using Microsoft.EntityFrameworkCore;
using MyEfCoreApp.Data;
using TravSystem.Models;

namespace TravSystem.Data.Repositories;

public class TPlanetRepository : ITPlanetRepository
{
    private readonly TravellerDBContext _context;

    public TPlanetRepository(TravellerDBContext context)
    {
        _context = context;
    }

    public async Task<TPlanet> Add(TPlanet planet)
    {
        _context.Planets.Add(planet);
        await _context.SaveChangesAsync();
        return planet;
    }

    public async Task<TPlanet?> GetByID(int id) =>
    await _context.Planets
        .Include(p => p.Atmosphere)
        .Include(p => p.Starport)
        .Include(p => p.Government)
        .Include(p => p.LawLevel)
        .Include(p => p.SubSector)
        .Include(p => p.TravelCode)
        .Include(p => p.System)
        .Where(p => p.Id == id)
        .FirstOrDefaultAsync();


    public Task<List<TPlanet>> GetBySubsectorID(int id) => _context.Planets.Where(p => p.TSubSectorId == id).ToListAsync();
    public Task<List<TPlanet>> GetAll() => _context.Planets
        .Include(p => p.Atmosphere)
        .Include(p => p.Starport)
        .Include(p => p.Government)
        .Include(p => p.SubSector)
        .Include(p => p.LawLevel)
        .Include(p => p.TravelCode)
        .Include(p => p.System)
        .ToListAsync();

    public async Task<TPlanet> Update(TPlanet planet)
    {
        _context.Planets.Update(planet);
        await _context.SaveChangesAsync();
        return planet;
    }

    public async Task Delete(TPlanet planet)
    {
        _context.Planets.Remove(planet);
        await _context.SaveChangesAsync();
    }
}
