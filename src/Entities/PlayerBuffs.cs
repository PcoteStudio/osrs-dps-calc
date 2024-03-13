using Pcote.OsrsDpsCalc.Enums;

namespace Pcote.OsrsDpsCalc.Entities;

public class PlayerBuffs
{
  public Potion[] Potions { get; set; } = [];
  public bool OnSlayerTask { get; set; }
  public bool InWilderness { get; set; }
  public bool ForinthrySurge { get; set; }
  public int SoulreaperStacks { get; set; }
  public bool KandarinDiary { get; set; }
  public bool ChargeSpell { get; set; }
  public bool MarkOfDarknessSpell { get; set; }
}
