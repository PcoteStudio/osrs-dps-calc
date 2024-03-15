namespace Pcote.OsrsDpsCalc.Entities;

public class OffensiveDefensiveStats
{
  public int Crush { get; set; }
  public int Magic { get; set; }
  public int Ranged { get; set; }
  public int Slash { get; set; }
  public int Stab { get; set; }

  public static OffensiveDefensiveStats operator +(OffensiveDefensiveStats a, OffensiveDefensiveStats b)
  {
    return new OffensiveDefensiveStats()
    {
      Crush = a.Crush + b.Crush,
      Magic = a.Magic + b.Magic,
      Ranged = a.Ranged + b.Ranged,
      Slash = a.Slash + b.Slash,
      Stab = a.Stab + b.Stab,
    };
  }

  public static OffensiveDefensiveStats operator -(OffensiveDefensiveStats a, OffensiveDefensiveStats b)
  {
    return new OffensiveDefensiveStats()
    {
      Crush = a.Crush - b.Crush,
      Magic = a.Magic - b.Magic,
      Ranged = a.Ranged - b.Ranged,
      Slash = a.Slash - b.Slash,
      Stab = a.Stab - b.Stab,
    };
  }
}
