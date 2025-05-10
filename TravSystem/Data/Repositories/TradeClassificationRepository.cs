using Microsoft.EntityFrameworkCore;
using MyEfCoreApp.Data;
using TravSystem.Models;

namespace TravSystem.Data.Repositories;

public class TradeClassificationRepository : ITradeClassificationRepository
{
    public TravellerDBContext _context;

    public TradeClassificationRepository(TravellerDBContext context)
    {
        _context = context;
    }

    public async Task<TradeClassification> Add(TradeClassification tradeClassification)
    {
        _context.Add(tradeClassification);
        await _context.SaveChangesAsync();
        return tradeClassification;
    }

    async public Task Delete(TradeClassification tradeClassification)
    {
        _context.TradeClassifications.Remove(tradeClassification);
        await _context.SaveChangesAsync();
    }

    public async Task<List<TradeClassification>> GetAll() => await _context.TradeClassifications.ToListAsync();

    public async Task<TradeClassification?> GetByID(int id) => await _context.TradeClassifications.Where(p => p.Id == id).FirstOrDefaultAsync();

    public async Task<TradeClassification> Update(TradeClassification tradeClassification)
    {
        _context.TradeClassifications.Update(tradeClassification);
        await _context.SaveChangesAsync();
        return tradeClassification;
    }
}
