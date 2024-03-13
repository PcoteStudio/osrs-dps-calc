
using Pcote.OsrsDpsCalc.Enums;

namespace Pcote.OsrsDpsCalc.Entities;

public class CombatStyle
{
  public string Name { get; set; } = "";
  public CombatStyleType Type { get; set; }
  public CombatStyleStance Stance { get; set; }
}
