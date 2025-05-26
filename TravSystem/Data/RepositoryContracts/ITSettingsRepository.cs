using TravSystem.Models;

namespace TravSystem.Data.Repositories;

public interface ITSettingsRepository
{
    Task <List<TSettings>> GetAll();
    Task<TSettings?> GetByID(int id);
    Task<TSettings?> Update(TSettings tsettings);
    Task<TSettings> Add(TSettings tsettings);
    Task Delete(TSettings tsettings);
}
