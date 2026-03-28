using Microsoft.EntityFrameworkCore;
using MyEfCoreApp.Data;
using TravSystem.Models;

namespace TravSystem.Data.Repositories;

public class ITOrbitDistanceRepository : ITOrbitalDistanceRepository
{

    private readonly TravellerDBContext _context;

    public ITOrbitDistanceRepository(TravellerDBContext context)
    {
        _context = context;
    }

    public async Task<TOrbitalDistance> Add(TOrbitalDistance orbitDistance)
    {
        _context.OrbitalDistances.Add(orbitDistance);
        await _context.SaveChangesAsync();
        return orbitDistance;
    }

    public async Task Delete(TOrbitalDistance orbitDistance)
    {
        _context.OrbitalDistances.Remove(orbitDistance);
        await _context.SaveChangesAsync();
    }

    public async Task<List<TOrbitalDistance>> GetAll() => await _context.OrbitalDistances.ToListAsync();

    public async Task<TOrbitalDistance> GetByID(int id) => await _context.OrbitalDistances.Where(p => p.Id == id).FirstOrDefaultAsync();

    public async Task<TOrbitalDistance> GetByOrbit(int orbit) => await _context.OrbitalDistances.Where(p => p.Orbit == orbit).FirstOrDefaultAsync();

    public async Task<TOrbitalDistance> Update(TOrbitalDistance orbitDistance)
    {
        _context.OrbitalDistances.Update(orbitDistance);
        await _context.SaveChangesAsync();
        return orbitDistance;
    }
}
