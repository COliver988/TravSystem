using TravSystem.Data.Repositories;
using TravSystem.Models;

namespace TravSystem.Services;

public class TPlanetGenService : ITPlanetGenService
{
    private Random _random;
    private IUtilitlityService _utilityService;
    private ITStarportRepository _starportRepository;
    ITAtmopshereRepository _atmosphereRepository;
    ITBaseRepository _baseRepository;
    ITGovernmentRepository _governmentRepository;
    ITLawLevelRepository _lawLevelRepository;

    public TPlanetGenService(ITStarportRepository starportRepository, 
        IUtilitlityService utilityService, 
        ITBaseRepository baseRepository,
        ITAtmopshereRepository tAtmopshereRepository,
        ITGovernmentRepository tGovernmentRepository,
        ITLawLevelRepository tLawLevelRepository)
    {
        _starportRepository = starportRepository;
        _utilityService = utilityService;
        _baseRepository = baseRepository;
        _atmosphereRepository = tAtmopshereRepository;
        _governmentRepository = tGovernmentRepository;
        _lawLevelRepository = tLawLevelRepository;
    }

    public async Task<TPlanet> GeneratePlanet()
    {
        _random = new Random();
        TPlanet planet = new TPlanet();
        planet.Name = "New Planet";
        planet.Starport = GenerateStarport();
        planet.TStarportId = planet.Starport.Id;
        planet.Size = _utilityService.DieRoll(6, 2) - 2;
        int atmo = _utilityService.DieRoll(6, 2) - 7 + planet.Size;
        TAtmosphere atmosphere = await _atmosphereRepository.GetByHexCode(_utilityService.IntToHex(atmo));
        planet.TAtmosphereId = atmosphere?.Id ?? 0;
        planet.Hydrographics = _utilityService.DieRoll(6, 2) - 7 + atmo;
        planet.Population = _utilityService.DieRoll(6, 2) - 2;
        int govt = _utilityService.DieRoll(6, 2) - 7 + planet.Population;
        TGovernment government = await _governmentRepository.GetByHexCode(_utilityService.IntToHex(govt));
        planet.Government = government;
        planet.TGovernmentId = government?.Id ?? 0;
        int law = _utilityService.DieRoll(6, 2) - 7 + govt;
        TLawLevel lawLevel = await _lawLevelRepository.GetByHexCode(_utilityService.IntToHex(law));
        planet.TLawLevelId = lawLevel?.Id ?? 0;
        planet.TechLevel = GenerateTechLevel(planet);
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

    //TODO: move to system generation?
    private async Task<List<TBase>> GenerateBases(TStarport port)
    {
        List<TBase> bases = new List<TBase>();
        int dieRollNavy = _utilityService.DieRoll(6, 2);
        int dieRollScout = _utilityService.DieRoll(6, 2);
        // set up DMs
        // TODO: configurable? DMs built into TBase table model?
        switch (port.HexCode)
        {
            case "A":
                dieRollScout -= 3;
                break;
            case "B":
                dieRollScout -= 2;
                break;
            case "C":
                dieRollScout -= 1;
                dieRollNavy = 0;
                break;
            case "D":
                dieRollNavy = 0;
                break;
            case "E":
                dieRollNavy = 0;
                dieRollScout = 0;
                break;
            case "X":
                dieRollNavy = 0;
                dieRollScout = 0;
                break;
            default:
                // No bases for other starport types
                break;
        }
        if (dieRollNavy >= 8)
            bases.Add(await _baseRepository.GetByCode("N"));
        if (dieRollScout >= 7)
            bases.Add(await _baseRepository.GetByCode("S"));
        return bases;
    }

    private int GenerateTechLevel(TPlanet planet)
    {
        int techlevel = _utilityService.DieRoll(1, 6);
        if (planet.Starport.HexCode == "A") techlevel += 6;
        else if (planet.Starport.HexCode == "B") techlevel += 4;
        else if (planet.Starport.HexCode == "C") techlevel += 2;
        else if (planet.Starport.HexCode == "D") techlevel += 0;
        else if (planet.Starport.HexCode == "X") techlevel -= 4;

        if (planet.Size <= 4) techlevel++;
        if (planet.Size <= 1) techlevel++;
        if (planet.Hydrographics == 9) techlevel++;
        if (planet.Hydrographics == 10) techlevel += 2;
        if (planet.Population >= 1 && planet.Population <= 5) techlevel++;
        if (planet.Population == 9) techlevel += 2;
        if (planet.Population == 10) techlevel += 4;
        if (planet.Government.HexCode == "0") techlevel++;
        if (planet.Government.HexCode == "5") techlevel++;
        if (planet.Government.HexCode == "D") techlevel -= 2;

        return techlevel;
    }
}
