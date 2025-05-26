using TravSystem.Models;

namespace TravSystem.Data.Repositories;

public interface ITSystemRepository
{
    Task<List<TSystem>> GetAll();
    Task<TSystem?> GetByID(int id);
    Task<TSystem> Add(TSystem tsystem);
    Task<TSystem> Update(TSystem tsystem);
    Task Delete(TSystem tsystem);
    Task<List<int>> GetSystemBaseIds(int systemId);
}
