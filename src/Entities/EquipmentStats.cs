namespace Pcote.OsrsDpsCalc.Entities;

public class EquipmentStats
{
  public EquipmentBonuses Bonuses { get; set; } = new EquipmentBonuses();
  public OffensiveDefensiveStats Offensive { get; set; } = new OffensiveDefensiveStats();
  public OffensiveDefensiveStats Defensive { get; set; } = new OffensiveDefensiveStats();
}
