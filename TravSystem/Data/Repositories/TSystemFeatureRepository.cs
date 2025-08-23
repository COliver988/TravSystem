using Microsoft.EntityFrameworkCore;
using MyEfCoreApp.Data;
using TravSystem.Models;

namespace TravSystem.Data.Repositories;

public class TSystemFeatureRepository : ITSystemFeaturesRepository
{

    private readonly TravellerDBContext _context;

    public TSystemFeatureRepository(TravellerDBContext context)
    {
        _context = context;
    }

    public async Task<List<TSystemFeature>> GetAll() => await _context.SystemFeatures.ToListAsync();

    public async Task<TSystemFeature?> GetByID(int id) => await _context.SystemFeatures.FindAsync(id) ?? null;

    public async Task<TSystemFeature> Upsert(TSystemFeature systemFeature)
    {
        _context.SystemFeatures.Update(systemFeature);
        await _context.SaveChangesAsync();
        return systemFeature;
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }
}
