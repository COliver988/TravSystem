using TravSystem.Models;

namespace TravSystem.Services;

public interface ITradeClassiificationService
{
    public Task<List<TradeClassification>> FindTradeClassifications(string uwp);
}
