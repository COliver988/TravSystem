using Microsoft.EntityFrameworkCore;
using MyEfCoreApp.Data;
using TravSystem.Models;

namespace TravSystem.Data.Repositories;

public class TBaseRepository : ITBaseRepository
{
    private readonly TravellerDBContext _context;

    public TBaseRepository(TravellerDBContext context)
    {
        _context = context;
    }

    public async Task<TBase> Add(TBase tbase)
    {
        _context.Add(tbase);
        await _context.SaveChangesAsync();
        return tbase;
    }

    public Task Delete(TBase tbase)
    {
        _context.Remove(tbase);
        return _context.SaveChangesAsync();
    }

    public async Task<List<TBase>> GetAll() => await _context.Bases.ToListAsync();

    public Task<TBase?> GetByID(int id) => _context.Bases.Where(s => s.Id == id).FirstOrDefaultAsync();
    public Task<TBase?> GetByCode(string code) => _context.Bases.Where(s => s.HexCode == code).FirstOrDefaultAsync();

    public Task<TBase> Update(TBase tbase)
    {
        _context.Update(tbase);
        return _context.SaveChangesAsync().ContinueWith(_ => tbase);
    }
}
