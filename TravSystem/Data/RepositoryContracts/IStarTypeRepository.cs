using TravSystem.Models;

namespace TravSystem.Data.Repositories;

public interface IStarTypeRepository
{
    Task<List<StarType>> GetAll();
    Task<StarType?> GetByID(int id);
    Task<StarType> Update(StarType entity);
}
