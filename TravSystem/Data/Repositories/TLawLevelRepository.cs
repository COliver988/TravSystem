using Microsoft.EntityFrameworkCore;
using MyEfCoreApp.Data;
using TravSystem.Models;

namespace TravSystem.Data.Repositories;

public class TLawLevelRepository : ITLawLevelRepository
{
    private readonly TravellerDBContext _context;

    public TLawLevelRepository(TravellerDBContext context)
    {
        _context = context;
    }

    public async Task<List<TLawLevel>> GetAll() => await _context.LawLevels.ToListAsync();
    public async Task<TLawLevel?> GetByID(int id) => await _context.LawLevels.Where(s => s.Id == id).FirstOrDefaultAsync();
    public async Task<TLawLevel?> GetByHexCode(string hexcode) => await _context.LawLevels.Where(s => s.HexCode == hexcode).FirstOrDefaultAsync();
    public async Task<TLawLevel> Add(TLawLevel lawlevel)
    {
        _context.LawLevels.Add(lawlevel);
        await _context.SaveChangesAsync();
        return lawlevel;
    }
    public async Task<TLawLevel> Update(TLawLevel lawlevel)
    {
        _context.LawLevels.Update(lawlevel);
        await _context.SaveChangesAsync();
        return lawlevel;
    }

    public async Task Delete(TLawLevel lawlevel)
    {
        _context.LawLevels.Remove(lawlevel);
        await _context.SaveChangesAsync();
    }
}
