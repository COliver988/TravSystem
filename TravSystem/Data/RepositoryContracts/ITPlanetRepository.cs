using TravSystem.Models;

namespace TravSystem.Data.Repositories;

public interface ITPlanetRepository
{
    Task<TPlanet?> GetByID(int id);
    Task<List<TPlanet>> GetAll();
    Task<List<TPlanet>> GetBySubsectorID(int id);
    Task<TPlanet> Add(TPlanet planet);
    Task<TPlanet> Update(TPlanet planet);
    Task Delete(TPlanet planet);

}
