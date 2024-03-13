using Pcote.OsrsDpsCalc.Enums;

namespace Pcote.OsrsDpsCalc.Entities;

public class Spell
{
  public string Name { get; set; } = "";
  public string Image { get; set; } = "";
  public int MaxHit { get; set; }
  public Spellbook Spellbook { get; set; }
}
