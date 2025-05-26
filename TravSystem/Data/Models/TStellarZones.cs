namespace TravSystem.Models;

public class TStellarZones
{
    public int Id { get; set; }
    public int TStellarTypeId { get; set; }
    public int Orbit { get; set; }
    public string Zone { get; set; } = string.Empty; // e.g. "Inner", "Middle", "Outer"

    public TStellarTypes? TStellarType { get; set; } // Navigation property to TStellarTypes
}
