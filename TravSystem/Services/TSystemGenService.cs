using TravSystem.Data.Repositories;
using TravSystem.Models;

namespace TravSystem.Services;

public class TSystemGenService : ITSystemGenService
{
    private ITPlanetRepository _planetRepository;
    private ITSystemRepository _systemRepository;
    private ITSubSectorRepository _subSectorRepository;
    private readonly ITStellarTypeRepository _stellarTypeRepository;

    public TSystemGenService(ITPlanetRepository planetRepository, 
        ITSystemRepository systemRepository, 
        ITSubSectorRepository subSectorRepository,
        ITStellarTypeRepository stellarTypeRepository)
    {
        _planetRepository = planetRepository;
        _systemRepository = systemRepository;
        _subSectorRepository = subSectorRepository;
        _stellarTypeRepository = stellarTypeRepository;
    }
    public async Task<TSystem> GenerateSystemFromMainPlanet(int id)
    {
        TPlanet? mainPlanet = await _planetRepository.GetByID(id);
        TSystem newSystem = new TSystem();
        newSystem.Planets.Add(mainPlanet);

        // determine stellar type from main planet
        TStellarTypes stellarType = await DetermineStellarType(mainPlanet);
        

        _systemRepository.Add(newSystem);
        return newSystem;
    }

    public Task<TSystem> GenerateSystemFromSystem(int id)
    {
        throw new NotImplementedException();
    }

    private async Task<TStellarTypes> DetermineStellarType(TPlanet planet)
    {
        // logic to determine stellar type based on main planet characteristics
        // this is a placeholder implementation
        var stellarTypes = await _stellarTypeRepository.GetAll();
        return stellarTypes.FirstOrDefault() ?? new TStellarTypes();
    }
}
