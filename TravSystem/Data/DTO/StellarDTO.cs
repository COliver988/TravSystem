namespace TravSystem.Data.DTO;

public class StellarDTO
{
    public string Type { get; set; } = string.Empty;
    public string Size { get; set; } = string.Empty;
    public int HabitableOrbit { get; set; } = 4;
    public int StellarTypeId { get; set; }
}
