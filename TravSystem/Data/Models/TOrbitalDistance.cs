using System.ComponentModel;

namespace TravSystem.Models;

public class TOrbitalDistance
{
    public int Id { get; set; }

    [DisplayName("Orbit Number")]
    public int Orbit { get; set; }

    [DisplayName("Astronomical Units")]
    public decimal AU { get; set; }

    [DisplayName("Millions of KM")]
    public float Kilometers { get; set; }

    [DisplayName("Solar Radii")]
    public int SolarRadii { get; set; }
}
