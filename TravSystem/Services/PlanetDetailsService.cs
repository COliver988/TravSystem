using TravSystem.Models;

namespace TravSystem.Services;

public class PlanetDetailsService : IPlanetDetailsService
{
    private readonly ITradeClassiificationService _tradeClassificationService;

    public PlanetDetailsService(ITradeClassiificationService tradeClassificationService)
    {
        _tradeClassificationService = tradeClassificationService;
    }

    public async Task<Dictionary<string, List<string>>> GetDetails(TPlanet planet)
    {
        Dictionary<string, List<string>> results = new Dictionary<string, List<string>>();
        List<TradeClassification> trades = await loadTradeClassifications(planet);
        results.Add("Trade Classifications", trades.Select(x => x.Name).ToList()) ;

        return results;
    }
    
    public async Task<int> GetOrbitalPeriod(TPlanet planet)
    {
        if (planet == null || planet.System == null)
            return 0;


        // 1. get the AU for the planet based on the planet orbit
        return 1;
    }

    private async Task<List<TradeClassification>> loadTradeClassifications(TPlanet planet)
    {
        List<TradeClassification> tradeClassifications = await _tradeClassificationService.FindTradeClassifications(planet.UWP);
        if (tradeClassifications.Count == 0)
            tradeClassifications = new List<TradeClassification>() { new TradeClassification() { Name = "none" } };
        return tradeClassifications;
    }
}
