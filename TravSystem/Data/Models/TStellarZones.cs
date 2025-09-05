namespace TravSystem.Models;

public class TStellarZones
{
    public int Id { get; set; }
    public int TStellarTypeId { get; set; }
    public int InnerZoneLow { get; set; }
    public int InnerZoneHigh { get; set; }
    public int HabitableZone { get; set; }
    public string StarType { get; set; } = string.Empty; // e.g. "B", "A", "M", etc

    public TStellarTypes? TStellarType { get; set; } // Navigation property to TStellarTypes
}
