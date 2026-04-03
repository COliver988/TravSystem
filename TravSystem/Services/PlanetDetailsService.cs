using TravSystem.Data.Repositories;
using TravSystem.Models;

namespace TravSystem.Services;

public class PlanetDetailsService : IPlanetDetailsService
{
    private readonly ITradeClassiificationService _tradeClassificationService;
    private readonly IStellarDataRepository _stellarDataRepository;
    private readonly ITOrbitDistanceRepository _orbitalDistanceRepository;

    public PlanetDetailsService(ITradeClassiificationService tradeClassificationService,
        IStellarDataRepository stellarDataRepository,
        ITOrbitDistanceRepository orbitalDistanceRepository)
    {
        _tradeClassificationService = tradeClassificationService;
        _stellarDataRepository = stellarDataRepository;
        _orbitalDistanceRepository = orbitalDistanceRepository;
    }

    public async Task<Dictionary<string, List<string>>> GetDetails(TPlanet planet)
    {
        Dictionary<string, List<string>> results = new Dictionary<string, List<string>>();
        List<TradeClassification> trades = await loadTradeClassifications(planet);
        results.Add("Trade Classifications", trades.Select(x => x.Name).ToList()) ;
        int orbitalPeriod = await GetOrbitalPeriod(planet);
        if (orbitalPeriod > 0)
            results.Add("Orbital Period", new List<string>() { orbitalPeriod.ToString() });

        return results;
    }
    
    public async Task<int> GetOrbitalPeriod(TPlanet planet)
    {
        if (planet == null || planet.System == null || planet.Orbit == null)
            return 0;

        TOrbitalDistance? orbitalDistance = await _orbitalDistanceRepository.GetByOrbit(planet.Orbit);
        if (orbitalDistance == null)
            return 0;

        return 0;
    }

    private async Task<List<TradeClassification>> loadTradeClassifications(TPlanet planet)
    {
        List<TradeClassification> tradeClassifications = await _tradeClassificationService.FindTradeClassifications(planet.UWP);
        if (tradeClassifications.Count == 0)
            tradeClassifications = new List<TradeClassification>() { new TradeClassification() { Name = "none" } };
        return tradeClassifications;
    }
}
