using MyEfCoreApp.Data;
using TravSystem.Models;

namespace TravSystem.Data.Repositories;
public interface ITStellarZonesRepository
{
    public Task<TStellarZones?> GetBySizeAndType(string size, string type);
}
