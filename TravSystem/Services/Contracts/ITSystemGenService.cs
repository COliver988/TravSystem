using TravSystem.Models;

namespace TravSystem.Services;

public interface ITSystemGenService
{
    // Generates a new system with an existing main planet (continuation star system)
    Task<TSystem> GenerateSystemFromMainPlanet(int id);

    // Generates a system based on an existing system ID (brand new system)
    Task<TSystem> GenerateSystemFromSystem(int id);
}
