using TravSystem.Models;

namespace TravSystem.Services;

public interface IPlanetDetailsService
{
    Task<Dictionary<string, List<string>>> GetDetails(TPlanet planet);
    Task<string> GetOrbitalInfo(TPlanet planet);
}
