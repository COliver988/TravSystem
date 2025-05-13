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
        int tech = _utilityService.HexToInt(uwp[8]);
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
        if (t.Size != null && !convertToIntList(t.Size).Contains(size))
            return null;
        if (t.Atmo != null && !convertToIntList(t.Atmo).Contains(atmo))
            return null;
        if (t.Hydro != null && !convertToIntList(t.Hydro).Contains(hydro))
            return null;
        if (t.Population != null && !convertToIntList(t.Population).Contains(pop))
            return null;
        if (t.Government != null && !convertToIntList(t.Government).Contains(govt))
            return null;
        if (t.LawLevel != null && !convertToIntList(t.LawLevel).Contains(law))
            return null;
        if (t.TechLevel != null && !convertToIntList(t.TechLevel).Contains(tech))
            return null;
        return t;
    }
    private List<int> convertToIntList(string codes)
    {
        return codes
            .Split(',') // Split the string by commas
            .Select(code => int.Parse(code.Trim())) // Trim whitespace and parse each substring to an integer
            .ToList(); // Convert the result to a List<int>
    }
}
