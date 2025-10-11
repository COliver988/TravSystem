namespace TravSystem.Models;

public class TSettings
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string StellarDensity { get; set; } = "Normal"; // Normal, Sparse, Dense

    // range as in 0-7
    public string StellerSolo { get; set; }
    public string StellerBinary { get; set; }
    public string StellerTrinary { get; set; }

    // range: 1-9
    public string GasGiantPresent { get; set; }
    public int GasGiantCount { get; set; } = 0;
    public string PlanetoidBeltPresent { get; set; }
    public int PlanetoidBeltCount { get; set; } = 0;
}
