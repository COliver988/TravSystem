using TravSystem.Models;

namespace TravSystem.Data.Repositories;

public interface ITStarportRepository
{
    Task<List<TStarport>> GetAll();
    Task<TStarport> GetByID(int id);
    Task<TStarport> Add(TStarport starport);
    Task<TStarport> Update(TStarport starport);
    Task Delete(TStarport starport);
}
