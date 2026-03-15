namespace TravSystem.Models;

public class TStellarTypes
{
    public int Id { get; set; }

    // Supergirant, main sequence, etc
    public string Type { get; set; }

    // i1, 1b, II, etc
    public string Size { get; set; }
    
    public string FullDisplayName => $"{Size} {Type}";

    public List<TStellarZones> StellarZones { get; set; } = new List<TStellarZones>();
}
