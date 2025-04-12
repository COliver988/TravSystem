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

    public async Task<TPlanet?> GetByID(int id) => await _context.Planets.Where(p => p.PlanetId == id).FirstOrDefaultAsync();

    public Task<List<TPlanet>> GetBySubsectorID(int id) => _context.Planets.Where(p => p.SubSectorId == id).ToListAsync();

    public TPlanet Update(TPlanet planet)
    {
        _context.Planets.Update(planet);
        return planet;
    }
}
