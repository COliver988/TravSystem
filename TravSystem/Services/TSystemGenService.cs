using TravSystem.Data.DTO;
using TravSystem.Data.Repositories;
using TravSystem.Models;

namespace TravSystem.Services;

public class TSystemGenService : ITSystemGenService
{
    private readonly ITPlanetRepository _planetRepository;
    private readonly ITSystemRepository _systemRepository;
    private readonly ITSubSectorRepository _subSectorRepository;
    private readonly ITStellarTypeRepository _stellarTypeRepository;
    private readonly ITSystemFeaturesRepository _systemFeaturesRepository;
    private readonly IUtilitlityService _utility;
    private List<TSystemFeature> _features;

    public TSystemGenService(ITPlanetRepository planetRepository, 
        ITSystemRepository systemRepository, 
        ITSubSectorRepository subSectorRepository,
        ITStellarTypeRepository stellarTypeRepository,
        ITSystemFeaturesRepository systemFeaturesRepository,
        IUtilitlityService utilitlityService)
    {
        _planetRepository = planetRepository;
        _systemRepository = systemRepository;
        _subSectorRepository = subSectorRepository;
        _stellarTypeRepository = stellarTypeRepository;
        _systemFeaturesRepository = systemFeaturesRepository;
        _utility = utilitlityService;
    }
    /// <summary>
    /// generate a new system based on a main planet
    /// </summary>
    /// <param name="id"></param>
    /// <returns>the new system</returns>
    public async Task<TSystem> GenerateSystemFromMainPlanet(int id)
    {
        TPlanet? mainPlanet = await _planetRepository.GetByID(id);
        TSystem newSystem = new TSystem();

        // get the system featrures tables loaded
        _features = await _systemFeaturesRepository.GetAll();

        // find the basic nature: solo, binary or whatever
        newSystem.BasicNature = rollSystemFeature().BasicNature.ToString();

        // determine stellar type from main planet
        StellarDTO stellarType = await DetermineStellarType(mainPlanet);
        newSystem.TStellarTypeIds = new List<string>() { stellarType.StellarTypeId.ToString() };
        mainPlanet.Orbit = stellarType.HabitableOrbit;

        _systemRepository.Add(newSystem);
        // add the main planet to the new system
        newSystem.Planets.Add(mainPlanet);
        return newSystem;
    }

    /// <summary>
    /// roll on the system features table to determine the basic nature of the system
    /// </summary>
    /// <param name="dm">DM as required</param>
    /// <returns></returns>
    private TSystemFeature rollSystemFeature(int dm = 0)
    {
        // the range of features to determine the die roll; note that zero is allowed
        int low = _features.Min(f => f.Roll);
        int high = _features.Max(f => f.Roll);

        // roll the dice, then fit within the range
        int roll = _utility.DieRoll(6,2) + dm;
        if (roll < low) roll = low;
        if (roll > high) roll = high;

        return _features.First(f => f.Roll == roll);

    }
    //TODO: implement the complete system generation
    public Task<TSystem> GenerateSystemFromSystem(int id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// get the steller type; we will adjust the planet's orbit to be in the habitable zone
    /// </summary>
    /// <param name="planet">main system planet</param>
    /// <returns></returns>
    private async Task<StellarDTO> DetermineStellarType(TPlanet planet)
    {
        int DM = 0;
        if (planet.Population >= 8) DM += 4;
        else if (_utility.HexToInt(planet.Atmosphere.HexCode[0]) >= 4 && _utility.HexToInt(planet.Atmosphere.HexCode[0]) <= 9) DM += 4;
        TSystemFeature feature = rollSystemFeature(DM);

        //temp for testing - need to figure out data consistency
        string type = "B0";
        string size = "Ia";
        return await _stellarTypeRepository.GetByTypeAndSize(type, size);
        //return await _stellarTypeRepository.GetByTypeAndSize(feature.PrimaryType, feature.PrimarySize);
    }
}
