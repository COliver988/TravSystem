namespace TravSystem.Models;

public class TStellarTypes
{
    public int Id { get; set; }

    // Supergirant, amin sequence, etc
    public string Type { get; set; }

    // i1, 1b, II, etc
    public string Size { get; set; }

    public List<TStellarZones> StellarZones { get; set; } = new List<TStellarZones>();
}
