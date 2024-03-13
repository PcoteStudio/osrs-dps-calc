namespace Pcote.OsrsDpsCalc.Entities;

public class EquipmentStats
{
  public PlayerBonuses Bonuses { get; set; } = new PlayerBonuses();
  public OffensiveDefensiveStats Offensive { get; set; } = new OffensiveDefensiveStats();
  public OffensiveDefensiveStats Defensive { get; set; } = new OffensiveDefensiveStats();
}
