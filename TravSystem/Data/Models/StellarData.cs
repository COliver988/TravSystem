using System.ComponentModel;

namespace TravSystem.Models;

public class StellarData
{
    public int Id { get; set; }
    [DisplayName("Star Type")]
    public int StarTypeId { get; set; }
    [DisplayName("Stellar Type")]
    public int StellarTypeId { get; set; }
    public decimal Magnitude { get; set; }
    public decimal Luminosity { get; set; }
    public int Temperature { get; set; }
    public decimal Radius { get; set; }
    public decimal Mass { get; set; }

    public StarType StarType { get; set; }
    public TStellarTypes StellarType { get; set; }
}
