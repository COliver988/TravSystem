using TravSystem.Models;

namespace TravSystem.Data.Repositories;

public interface ITPlanetRepository
{
    Task <TPlanet?> GetByID(int id);
    Task<List<TPlanet>> GetBySubsectorID(int id);
    Task<TPlanet> Add(TPlanet planet);
    TPlanet Update(TPlanet planet);

}
