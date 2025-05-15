namespace TravSystem.Models;

public class TBase
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string HexCode { get; set; }

    public ICollection<TSystemTBases> SystemBases { get; set; }
}
