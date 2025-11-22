using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravSystem.Models;

[Table("CapturedAndEmpty")]
public class TCapturedAndEmpty
{
    public int Id {  get; set; }

    [DisplayName("Die Roll")]
    public int DieRoll { get; set; }
    [DisplayName("Captured Planet")]
    public bool Captures { get; set; }
    [DisplayName("Captured Planet Qty")]
    public int CapturedQty { get; set; }

    [DisplayName("Empty Orbits?")]
    public bool EmptyOrbits { get; set; }

    [DisplayName("Empty Orbit Qty")]
    public int EmptyOrbitsQty { get; set; }
}
