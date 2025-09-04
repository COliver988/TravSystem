using Microsoft.EntityFrameworkCore;
using MyEfCoreApp.Data;
using TravSystem.Data.DTO;
using TravSystem.Models;

namespace TravSystem.Data.Repositories;

public class TStellarTypeRepository : ITStellarTypeRepository
{
    private readonly TravellerDBContext _context;
    public TStellarTypeRepository(TravellerDBContext context)
    {
        _context = context;
    }

    public async Task<TStellarTypes> Add(TStellarTypes stellarType)
    {
        _context.Add(stellarType);
        await _context.SaveChangesAsync();
        return stellarType;
    }

    public async Task Delete(TStellarTypes stellarType)
    {
        _context.Remove(stellarType);
        await _context.SaveChangesAsync();
    }

    public async Task<List<TStellarTypes>> GetAll() => await _context.StellarTypes.ToListAsync();

    public async Task<TStellarTypes?> GetByID(int id) => await _context.StellarTypes
        .Include(st => st.StellarZones)
        .Where(st => st.Id == id)
        .FirstOrDefaultAsync();

    public async Task<StellarDTO?> GetByTypeAndSize(string type, string size)
    { 
        TStellarTypes stellarType = await _context.StellarTypes.Where(s => s.Size == size).FirstOrDefaultAsync();
        if (stellarType == null) return null;
        TStellarZones zone = await _context.StellarZones
            .Where(z => z.TStellarTypeId == stellarType.Id && z.StarType == type && z.Zone == "H")
            .FirstOrDefaultAsync();
        if (zone == null) return null;
        StellarDTO dto = new StellarDTO() { Type = type, Size = size, HabitableOrbit = zone.Orbit, StellarTypeId = stellarType.Id };
        return dto;
    }

    public async Task<TStellarTypes> Update(TStellarTypes stellarType)
    {
        _context.Update(stellarType);
        await _context.SaveChangesAsync();
        return stellarType;
    }
}
