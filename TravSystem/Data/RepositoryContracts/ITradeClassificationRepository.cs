using TravSystem.Models;

namespace TravSystem.Data.Repositories;

public interface ITradeClassificationRepository
{
    public Task<TradeClassification> Add(TradeClassification tradeClassification);
    public Task Delete(TradeClassification tradeClassification);
    public Task<List<TradeClassification>> GetAll();
    public Task<TradeClassification?> GetByID(int id);
    public Task<TradeClassification> Update(TradeClassification tradeClassification);
}
