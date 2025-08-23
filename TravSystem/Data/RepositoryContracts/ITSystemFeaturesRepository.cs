using TravSystem.Models;

namespace TravSystem.Data.Repositories;

public interface ITSystemFeaturesRepository
{
    Task<List<TSystemFeature>> GetAll();
    Task<TSystemFeature?> GetByID(int id);
    Task Delete(int id);
    Task<TSystemFeature> Upsert(TSystemFeature systemFeature);
}
