using System.ComponentModel.DataAnnotations.Schema;

namespace TravSystem.Models;

public class TSystem
{
    public int Id { get; set; }
    [ForeignKey("SubSectorId")]
    public int SubSectorId { get; set; }
    public string Name { get; set; }
    public int PlanetoidBelts { get; set; }
    public int GasGiantCount { get; set; }
    public int PopulationModifier { get; set; }

    public ICollection<TPlanet>? Planets { get; set; }
    public TSubSector? SubSector { get; set; }

    public ICollection<TBase?> Bases { get; set; } = new List<TBase>();
    public ICollection<TSystemTBases>? SystemBases { get; set; }
}
