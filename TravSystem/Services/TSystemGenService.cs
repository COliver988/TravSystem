using NuGet.Packaging;
using System.ComponentModel;
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
    private readonly ITStellarZonesRepository _stellarZonesRepository;
    private readonly IUtilitlityService _utility;
    private readonly ITCapturedAndEmptyRepository _capturedAndEmptyRepository;
    private List<TSystemFeature> _features;

    public TSystemGenService(ITPlanetRepository planetRepository,
        ITSystemRepository systemRepository,
        ITSubSectorRepository subSectorRepository,
        ITStellarTypeRepository stellarTypeRepository,
        ITSystemFeaturesRepository systemFeaturesRepository,
        IUtilitlityService utilitlityService,
        ITStellarZonesRepository tStellarZonesRepository,
        ITCapturedAndEmptyRepository tCapturedAndEmptyRepository)
    {
        _planetRepository = planetRepository;
        _systemRepository = systemRepository;
        _subSectorRepository = subSectorRepository;
        _stellarTypeRepository = stellarTypeRepository;
        _systemFeaturesRepository = systemFeaturesRepository;
        _stellarZonesRepository = tStellarZonesRepository;
        _capturedAndEmptyRepository = tCapturedAndEmptyRepository;
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
        await _planetRepository.Update(mainPlanet);
        newSystem.Planets = new List<TPlanet>() { mainPlanet };

        // check for empty orbits (will remove existing orbits)
        int emptyOrbits = await findEmptyOrbits();

        newSystem.PlanetoidBelts = GeneratePlanetoidBelts(newSystem);

        _systemRepository.Add(newSystem);
        // add the main planet to the new system
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
        int roll = _utility.DieRoll(6, 2) + dm;
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

        // type
        TSystemFeature feature = rollSystemFeature(DM);
        string type = feature.PrimaryType;
        // size
        feature = rollSystemFeature(DM);
        string size = feature.PrimarySize;

        // get the stellar type
        TStellarZones? stellarZones = await _stellarZonesRepository.GetBySizeAndType(size, type);
        return new StellarDTO()
        {
            Type = type,
            Size = size,
            HabitableOrbit = stellarZones != null ? stellarZones.HabitableZone : 4,
        };
    }

    private async Task<int> findEmptyOrbits()
    {
        int results = 0;
        List<TCapturedAndEmpty?> capturedAndEmpty = await _capturedAndEmptyRepository.GetAll();
        if (capturedAndEmpty == null || capturedAndEmpty.Count == 0) { return results; }
        int minD6 = capturedAndEmpty.Min(c => c != null ? c.DieRoll : 0);
        int maxD6 = capturedAndEmpty.Max(c => c != null ? c.DieRoll : 0);
        if (minD6 == 0 && maxD6 == 0) { return results; }
        int d6 = _utility.DieRoll(maxD6, 1);
        if (d6 < minD6) { d6 = minD6; }
        TCapturedAndEmpty? match = capturedAndEmpty.FirstOrDefault(c => c != null && c.DieRoll == d6);
        if (match == null || !match.EmptyOrbits) { return results;};
        // we have empty orbits; how many?
        d6 = _utility.DieRoll(maxD6, 1);
        if (d6 < minD6) { d6 = minD6; }
        return capturedAndEmpty.First(c => c != null && c.DieRoll == d6)?.EmptyOrbitsQty ?? 0;
    }

    private int GeneratePlanetoidBelts(TSystem newSystem)
    {
        return 0;
    }
}