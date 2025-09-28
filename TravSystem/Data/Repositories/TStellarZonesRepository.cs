using Microsoft.EntityFrameworkCore;
using MyEfCoreApp.Data;
using TravSystem.Models;

namespace TravSystem.Data.Repositories;

public class TStellarZonesRepository : ITStellarZonesRepository
{
    private readonly TravellerDBContext _context;
    public TStellarZonesRepository(TravellerDBContext context)
    {
        _context = context;
    }

    public async Task<TStellarZones?> GetBySizeAndType(string size, string type)
    {
        return await _context.StellarZones
        .Include(z => z.TStellarType)
        .Include(z => z.StarType)
        .Where(z => z.TStellarType != null && z.TStellarType.Size == size
                 && z.StarType != null && z.StarType.Type == type)
        .FirstOrDefaultAsync();
    }
}
