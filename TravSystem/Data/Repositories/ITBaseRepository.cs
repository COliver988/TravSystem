using TravSystem.Models;

namespace TravSystem.Data.Repositories;

public interface ITBaseRepository
{
    Task<List<TBase>> GetAll();
    Task <TBase?> GetByID(int id);
    Task <TBase?> GetByCode(string code);
    Task<TBase> Add(TBase atmosphere);
    Task<TBase> Update(TBase atmosphere);
    Task Delete(TBase atmosphere);
}
