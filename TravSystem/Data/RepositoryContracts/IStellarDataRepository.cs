using TravSystem.Data.Models;

namespace TravSystem.Data;

public interface IStellarDataRepository
{
    Task<List<StellarData>> GetAllAsync();
    Task<StellarData> GetByIdAsync(int id);
    Task<StellarData> AddAsync(StellarData stellarData);
    Task UpdateAsync(StellarData stellarData);
    Task DeleteAsync(StellarData stellarData);
}
