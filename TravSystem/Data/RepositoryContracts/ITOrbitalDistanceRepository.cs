
using TravSystem.Models;

namespace TravSystem.Data.Repositories;

public interface ITOrbitalDistanceRepository
{
    Task<List<TOrbitalDistance>> GetAll();
    Task<TOrbitalDistance> GetByID(int id);
    Task<TOrbitalDistance> GetByOrbit(int orbit);
    Task<TOrbitalDistance> Add(TOrbitalDistance orbitDistance);
    Task<TOrbitalDistance> Update(TOrbitalDistance orbitDistance);
    Task Delete(TOrbitalDistance orbitDistance);
}
