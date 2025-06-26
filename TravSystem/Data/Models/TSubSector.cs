using System.ComponentModel.DataAnnotations;

namespace TravSystem.Models;

public class TSubSector
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<TSystem> Systems { get; set; }
}
