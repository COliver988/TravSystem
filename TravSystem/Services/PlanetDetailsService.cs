using TravSystem.Data.Repositories;
using TravSystem.Models;

namespace TravSystem.Services;

public class PlanetDetailsService : IPlanetDetailsService
{
    private readonly ITradeClassiificationService _tradeClassificationService;
    private readonly ITravellerWorldMapForm8 _travellerWorldMapForm8;
    private readonly IStellarDataRepository _stellarDataRepository;
    ITStellarTypeRepository _stellarTypeRepository;
    private readonly IStarTypeRepository _starTypeRepository;
    private readonly ITOrbitDistanceRepository _orbitalDistanceRepository;

    public PlanetDetailsService(ITradeClassiificationService tradeClassificationService,
        IStellarDataRepository stellarDataRepository,
        IStarTypeRepository starTypeRepository,
        ITStellarTypeRepository stellarTypeRepository,
        ITravellerWorldMapForm8 travellerWorldMapForm8,
        ITOrbitDistanceRepository orbitalDistanceRepository)
    {
        _tradeClassificationService = tradeClassificationService;
        _stellarDataRepository = stellarDataRepository;
        _starTypeRepository = starTypeRepository;
        _starTypeRepository = starTypeRepository;
        _orbitalDistanceRepository = orbitalDistanceRepository;
        _travellerWorldMapForm8 = travellerWorldMapForm8;
    }

    public async Task<Dictionary<string, List<string>>> GetDetails(TPlanet planet)
    {
        Dictionary<string, List<string>> results = new Dictionary<string, List<string>>();
        List<TradeClassification> trades = await loadTradeClassifications(planet);
        results.Add("Trade Classifications", trades.Select(x => x.Name).ToList()) ;
        string orbitInfo = await GetOrbitalInfo(planet);
        results.Add("Orbital info", new List<string>() { orbitInfo });

        return results;
    }
    
    public async Task<string> GetOrbitalInfo(TPlanet planet)
    {
        if (planet == null || planet.System == null || planet.Orbit == null)
            return "";

        TOrbitalDistance? orbitalDistance = await _orbitalDistanceRepository.GetByOrbit(planet.Orbit);
        if (orbitalDistance == null)
            return "";

        StarType? starType = await _starTypeRepository.GetByID(planet.System.StarTypeIds.FirstOrDefault());
        if (starType == null)
            return "";

        TStellarTypes? stellarType = await _stellarTypeRepository.GetByID(planet.System.TStellarTypeIds.FirstOrDefault());
        if (stellarType == null)
            return "";

        int days = await calculateDays(starType.Id, stellarType.Id, orbitalDistance.AU);
        return $"Period: {days} days; AU: {orbitalDistance.AU}"; ;
    }

    private async Task<List<TradeClassification>> loadTradeClassifications(TPlanet planet)
    {
        List<TradeClassification> tradeClassifications = await _tradeClassificationService.FindTradeClassifications(planet.UWP);
        if (tradeClassifications.Count == 0)
            tradeClassifications = new List<TradeClassification>() { new TradeClassification() { Name = "none" } };
        return tradeClassifications;
    }
    
    private async Task<int> calculateDays(int starTypeId, int stellarTypeId, decimal au)
    {
        StellarData? stellarData = await _stellarDataRepository.GetByTypeAndSize(starTypeId, stellarTypeId);
        decimal a3 = (decimal)Math.Pow((double)au, 3);
        return (int)((Math.Sqrt((double)(a3 / stellarData.Mass))) * 365);
    }
}
