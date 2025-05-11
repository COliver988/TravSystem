using TravSystem.Models;

namespace TravSystem.Services;

public interface ITradeClassiificationService
{
    public List<TradeClassification> FindTradeClassifications(string uwp);
}
