using System.ComponentModel;

namespace TravSystem.Models;

public class TWorldData
{
    public int Id { get; set; }

    [DisplayName("World Size")]
    public required string WorldSize { get; set; }
    public double Volume { get; set; }
    public double Mass { get; set; }

    [DisplayName("Surface Area")]
    public double SurfaceArea { get; set; }

    [DisplayName("Surface Gravity")]
    public double SurfaceGravity { get; set; }

    [DisplayName("Escape Velocity (m/s)")]
    public double EscapeVelocity { get; set; }
}
