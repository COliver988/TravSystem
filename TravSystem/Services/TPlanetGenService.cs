using TravSystem.Data.Repositories;
using TravSystem.Models;

namespace TravSystem.Services;

public class TPlanetGenService : ITPlanetGenService
{
    private Random _random;
    private IUtilitlityService _utilityService;
    private ITStarportRepository _starportRepository;

    public TPlanetGenService(ITStarportRepository starportRepository, IUtilitlityService utilityService)
    {
        _starportRepository = starportRepository;
        _utilityService = utilityService;
    }

    public async Task<TPlanet> GeneratePlanet()
    {
        _random = new Random();
        TPlanet planet = new TPlanet();
        planet.Name = "New Planet";
        planet.Starport = GenerateStarport();
        planet.TStarportId = planet.Starport.Id;
        return planet;
    }

    private TStarport GenerateStarport()
    {
        var starports = _starportRepository.GetAll().Result;
        int index = _utilityService.DieRoll(6, 2);
        return starports.Where(s => s.DieRollMin <= index && s.DieRollMax >= index)
                        .OrderBy(s => _random.Next())
                        .FirstOrDefault() ?? new TStarport();
    }
}
