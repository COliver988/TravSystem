using TravSystem.Models;

namespace TravSystem.Data.Repositories;

public interface ITStellarTypeRepository
{
    Task<List<TStellarTypes>> GetAll();
    Task<TStellarTypes?> GetByID(int id);
    Task<TStellarTypes?> GetByTypeAndSize(string type, string size);
    Task<TStellarTypes> Add(TStellarTypes stellarType);
    Task<TStellarTypes> Update(TStellarTypes stellarType);
    Task Delete(TStellarTypes stellarType);
}
