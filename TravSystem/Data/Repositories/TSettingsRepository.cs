using Microsoft.EntityFrameworkCore;
using MyEfCoreApp.Data;
using TravSystem.Models;

namespace TravSystem.Data.Repositories;

public class TSettingsRepository : ITSettingsRepository
{
    private readonly TravellerDBContext _context;
    public TSettingsRepository(TravellerDBContext context)
    {
        _context = context;
    }

    public async Task<TSettings> Add(TSettings tsettings)
    {
        _context.Settings.Add(tsettings);
        await _context.SaveChangesAsync();
        return tsettings;
    }

    public async Task<List<TSettings>> GetAll() =>
        await _context.Settings.ToListAsync();

    public async Task<TSettings?> GetByID(int id) => await _context.Settings
        .Where(s => s.Id == id)
        .FirstOrDefaultAsync();

    public async Task<TSettings?> Update(TSettings tsettings)
    {
        _context.Settings.Update(tsettings);
        await _context.SaveChangesAsync();
        return tsettings;
    }

    public async Task? Delete(TSettings tsettings)
    {
        _context.Settings.Remove(tsettings);
        await _context.SaveChangesAsync();
    }
}
