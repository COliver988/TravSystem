using Microsoft.EntityFrameworkCore;
using MyEfCoreApp.Data;
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
        .Where(st => st.Id == id)
        .FirstOrDefaultAsync();

    public async Task<TStellarTypes> Update(TStellarTypes stellarType)
    {
        _context.Update(stellarType);
        await _context.SaveChangesAsync();
        return stellarType;
    }
}
