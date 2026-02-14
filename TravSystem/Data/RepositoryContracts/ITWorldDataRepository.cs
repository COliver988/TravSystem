using TravSystem.Models;

namespace TravSystem.Data.Repositories;

public interface ITWorldDataRepository
{
    Task<List<TWorldData>> GetAll();
    Task<TWorldData?> GetByID(int id);
    Task<TWorldData?> GetByHexCode(string hexcode);
    Task<TWorldData> Add(TWorldData worldData);
    Task<TWorldData> Update(TWorldData worldData);
    Task Delete(TWorldData worldData);
}
