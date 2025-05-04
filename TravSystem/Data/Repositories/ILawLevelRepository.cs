using TravSystem.Models;

namespace TravSystem.Data.Repositories;

public interface ITLawLevelRepository
{
    Task<List<TLawLevel>> GetAll();
    Task<TLawLevel> GetByID(int id);
    Task<TLawLevel> GetByHexCode(string hexcode);
    Task<TLawLevel> Add(TLawLevel lawlevel);
    Task<TLawLevel> Update(TLawLevel lawlevel);
    Task Delete(TLawLevel lawlevel);
}
