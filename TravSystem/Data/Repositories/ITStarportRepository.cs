using TravSystem.Models;

namespace TravSystem.Data.Repositories;

public interface ITStarportRepository
{
    Task<List<TStarport>> GetAll();
    Task<TStarport> GetByID(int id);
}
