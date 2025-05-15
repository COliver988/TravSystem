namespace TravSystem.Models;

public class TSystemTBases
{
    public int Id { get; set; }
    public int TSystemId { get; set; }
    public TSystem? TSystem { get; set; }
    public int TBaseId { get; set; }
    public TBase? TBase { get; set; }
}
