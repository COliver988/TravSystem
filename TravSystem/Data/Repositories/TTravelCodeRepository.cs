using Microsoft.EntityFrameworkCore;
using MyEfCoreApp.Data;
using TravSystem.Models;

namespace TravSystem.Data.Repositories;

public class TTravelCodeRepository : ITTravelCodeRepository
{
    private TravellerDBContext _context;

    public TTravelCodeRepository(TravellerDBContext dbContext)
    {
        _context = dbContext;
    }
    public async Task<TTravelCode> Add(TTravelCode travelCode)
    {
        _context.TravelCodes.Add(travelCode);
        await _context.SaveChangesAsync();
        return travelCode;
    }

    public async Task Delete(TTravelCode travelCode)
    {
        _context.TravelCodes.Remove(travelCode);
        await _context.SaveChangesAsync();
    }

    public async Task<List<TTravelCode>> GetAll() => await _context.TravelCodes.ToListAsync();

    async public Task<TTravelCode> GetByHexCode(string hexcode) => await _context.TravelCodes.Where(t => t.Code == hexcode).FirstOrDefaultAsync();

    public async Task<TTravelCode> GetByID(int id) => await _context.TravelCodes.Where(t => t.Id == id).FirstOrDefaultAsync();

    public async Task<TTravelCode> Update(TTravelCode travelCode)
    {
        _context.TravelCodes.Update(travelCode);
        await _context.SaveChangesAsync();
        return travelCode;
    }
}
