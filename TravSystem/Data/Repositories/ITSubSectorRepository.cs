using TravSystem.Models;

namespace TravSystem.Data.Repositories;

public interface ITSubSectorRepository
{
    Task<List<TSubSector>> GetAll();
    Task<TSubSector> GetByID(int id);
    Task<TSubSector> Add(TSubSector subsector);
    Task<TSubSector> Update(TSubSector subsector);
    Task Delete(TSubSector subsector);
}
