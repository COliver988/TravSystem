using TravSystem.Models;

namespace TravSystem.Data.Repositories;

public interface ITAtmopshereRepository
{
    Task<List<TAtmosphere>> GetAll();
    Task <TAtmosphere?> GetByID(int id);
    Task<TAtmosphere> Add(TAtmosphere atmosphere);
    Task<TAtmosphere> Update(TAtmosphere atmosphere);
    Task Delete(TAtmosphere atmosphere);

}
