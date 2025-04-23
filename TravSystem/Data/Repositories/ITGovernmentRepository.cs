using TravSystem.Models;

namespace TravSystem.Data.Repositories;

public interface ITGovernmentRepository
{
    Task<List<TGovernment>> GetAll();
    Task<TGovernment> GetByID(int id);
    Task<TGovernment> Add(TGovernment government);
    Task<TGovernment> Update(TGovernment government);
    Task Delete(TGovernment starport);
}
