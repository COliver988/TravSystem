using TravSystem.Models;

namespace TravSystem.Data.Repositories;

public interface IStellarDataRepository
{
    Task<List<StellarData>> GetAllAsync();
    Task<StellarData> GetByIdAsync(int id);
    Task<StellarData> AddAsync(StellarData stellarData);
    Task UpdateAsync(StellarData stellarData);
    Task DeleteAsync(StellarData stellarData);
}
