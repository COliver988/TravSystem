using Microsoft.EntityFrameworkCore;
using MyEfCoreApp.Data;
using TravSystem.Models;

namespace TravSystem.Data.Repositories;

public class TGovernmentRepository : ITGovernmentRepository
{
    private readonly TravellerDBContext _context;

    public TGovernmentRepository(TravellerDBContext context)
    {
        _context = context;
    }

    public async Task<List<TGovernment>> GetAll() => await _context.Governments.ToListAsync();
    public async Task<TGovernment?> GetByID(int id) => await _context.Governments.Where(s => s.Id == id).FirstOrDefaultAsync();
    public async Task<TGovernment> Add(TGovernment government)
    {
        _context.Governments.Add(government);
        await _context.SaveChangesAsync();
        return government;
    }
    public async Task<TGovernment> Update(TGovernment government)
    {
        _context.Governments.Update(government);
        await _context.SaveChangesAsync();
        return government;
    }

    public async Task Delete(TGovernment government)
    {
        _context.Governments.Remove(government);
        await _context.SaveChangesAsync();
    }
}
