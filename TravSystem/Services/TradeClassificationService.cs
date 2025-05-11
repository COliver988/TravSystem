using TravSystem.Data.Repositories;
using TravSystem.Models;

namespace TravSystem.Services;

public class TradeClassificationService : ITradeClassiificationService
{
    private readonly ITradeClassificationRepository _repo;
    private readonly IUtilitlityService _utilityService;
    public TradeClassificationService(ITradeClassificationRepository repo, IUtilitlityService utilityService)
    {
        _repo = repo;
        _utilityService = utilityService;
    }

    /// <summary>
    /// returns a list of trade classifications based on the UWP A123456-7 format
    /// </summary>
    /// <param name="uwp"></param>
    /// <returns>list of trade classification records</returns>
    public async Task<List<TradeClassification>> FindTradeClassifications(string uwp)
    {
        List<TradeClassification> tradeClassifications = new List<TradeClassification>();
        List<TradeClassification> allTradeClassifications = await _repo.GetAll();
        int size = _utilityService.HexToInt(uwp[1]);
        int atmo = _utilityService.HexToInt(uwp[2]);
        int hydro = _utilityService.HexToInt(uwp[3]);
        int pop = _utilityService.HexToInt(uwp[4]);
        int govt = _utilityService.HexToInt(uwp[5]);
        int law = _utilityService.HexToInt(uwp[6]);
        int tech = _utilityService.HexToInt(uwp[7]);
        foreach (var t in allTradeClassifications)
        {
            TradeClassification? tc = checkClassification(t, size, atmo, hydro, pop, govt, law, tech);
            if (tc != null)
            {
                tradeClassifications.Add(tc);
            }
        }

        return tradeClassifications;
    }

    private TradeClassification? checkClassification(TradeClassification t, int size, int atmo, int hydro, int pop, int govt, int law, int tech)
    {
        if (t.Size != null && !t.Size.Contains(size.ToString()))
            return null;
        if (t.Atmo != null && !t.Atmo.Contains(atmo.ToString()))
            return null;
        if (t.Hydro != null && !t.Hydro.Contains(hydro.ToString()))
            return null;
        if (t.Population != null && !t.Population.Contains(pop.ToString()))
            return null;
        if (t.Government != null && !t.Government.Contains(govt.ToString()))
            return null;
        if (t.LawLevel != null && !t.LawLevel.Contains(law.ToString()))
            return null;
        if (t.TechLevel != null && !t.TechLevel.Contains(tech.ToString()))
            return null;
        return t;
    }
}
