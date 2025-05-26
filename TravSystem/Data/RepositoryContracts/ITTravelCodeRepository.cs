using TravSystem.Models;

namespace TravSystem.Data.Repositories;

public interface ITTravelCodeRepository
{
    Task<List<TTravelCode>> GetAll();
    Task<TTravelCode> GetByID(int id);
    Task<TTravelCode> GetByHexCode(string hexcode);
    Task<TTravelCode> Add(TTravelCode travelCode);
    Task<TTravelCode> Update(TTravelCode travelCode);
    Task Delete(TTravelCode travelCode);
}
