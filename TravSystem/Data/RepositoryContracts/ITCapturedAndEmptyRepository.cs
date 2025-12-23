using TravSystem.Models;

namespace TravSystem.Data.Repositories;

public interface ITCapturedAndEmptyRepository
{
    Task<List<TCapturedAndEmpty>> GetAll();
    Task<TCapturedAndEmpty> GetByID(int id);
    Task<TCapturedAndEmpty> Add(TCapturedAndEmpty capturedAndEmpty);
    Task<TCapturedAndEmpty> Update(TCapturedAndEmpty capturedAndEmpty);
    Task<TCapturedAndEmpty> Delete(TCapturedAndEmpty capturedAndEmpty);
}
