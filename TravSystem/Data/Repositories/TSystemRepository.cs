using Microsoft.EntityFrameworkCore;
using MyEfCoreApp.Data;
using TravSystem.Models;

namespace TravSystem.Data.Repositories;

public class TSystemRepository : ITSystemRepository
{
    private readonly TravellerDBContext _context;

    public TSystemRepository(TravellerDBContext context)
    {
        _context = context;
    }

    public async Task<TSystem> Add(TSystem tsystem)
    {
        _context.Systems.Add(tsystem);
        await _context.SaveChangesAsync();
        return tsystem;
    }

    public async Task Delete(TSystem tsystem)
    {
        _context.Systems.Remove(tsystem);
        await _context.SaveChangesAsync();
    }

    public async Task<List<TSystem>> GetAll() =>
        await _context.Systems
        .Include(s => s.SubSector)
        .Include(s => s.SystemBases)
        .ThenInclude(sb => sb.TBase)
        .ToListAsync();

    public async Task<TSystem?> GetByID(int id) =>
        await _context.Systems
        .Include(s => s.SubSector)
        .Include(s => s.Planets)
          .ThenInclude(p => p.LawLevel)
        .Include(s => s.Planets)
          .ThenInclude(p => p.Atmosphere)
        .Include(s => s.Planets)
          .ThenInclude(p => p.Government)
        .Include(s => s.Planets)
          .ThenInclude(p => p.Starport)
        .Include(s => s.Planets)
          .ThenInclude(p => p.TravelCode)
        .Include(s => s.SystemBases)
        .ThenInclude(sb => sb.TBase)
        .Where(s => s.Id == id).FirstOrDefaultAsync();

    public async Task<List<int>> GetSystemBaseIds(int systemId)
    {
        return await _context.SystemTBases.Where(st => st.TSystemId == systemId)
            .AsNoTracking()
            .Select(st => st.TBaseId)
            .ToListAsync();
    }

    public async Task<TSystem> Update(TSystem tsystem)
    {
        _context.Systems.Update(tsystem);
        await _context.SaveChangesAsync();
        return tsystem;
    }
}
