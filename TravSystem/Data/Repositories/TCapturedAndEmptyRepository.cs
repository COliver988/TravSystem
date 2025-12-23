
using Microsoft.EntityFrameworkCore;
using MyEfCoreApp.Data;
using TravSystem.Models;

namespace TravSystem.Data.Repositories;

public class CapturedAndEmptyRepository : ITCapturedAndEmptyRepository
{
    private TravellerDBContext _context;

    public CapturedAndEmptyRepository(TravellerDBContext dbContext)
    {
        _context = dbContext;
    }

    public async Task<TCapturedAndEmpty> Add(TCapturedAndEmpty capturedAndEmpty)
    {
        _context.CapturedAndEmpty.Add(capturedAndEmpty);
        await _context.SaveChangesAsync();
        return capturedAndEmpty;
    }

    public Task<TCapturedAndEmpty> Delete(TCapturedAndEmpty capturedAndEmpty)
    {
        throw new NotImplementedException();
    }

    public async Task<List<TCapturedAndEmpty>> GetAll() => await _context.CapturedAndEmpty.ToListAsync();

    public async Task<TCapturedAndEmpty> GetByID(int id) => await _context.CapturedAndEmpty.FindAsync(id);

    public async Task<TCapturedAndEmpty> Update(TCapturedAndEmpty capturedAndEmpty)
    {
        _context.CapturedAndEmpty.Update(capturedAndEmpty);
        await _context.SaveChangesAsync();
        return capturedAndEmpty;
    }
}
