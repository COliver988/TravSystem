using TravSystem.Models;

namespace TravSystem.Services;

public interface ITPlanetGenService
{
    Task<TPlanet> GeneratePlanet();
}
