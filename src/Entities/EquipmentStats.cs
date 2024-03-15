namespace Pcote.OsrsDpsCalc.Entities;

public class EquipmentStats
{
  public EquipmentBonuses Bonuses { get; set; } = new EquipmentBonuses();
  public OffensiveDefensiveStats Offensive { get; set; } = new OffensiveDefensiveStats();
  public OffensiveDefensiveStats Defensive { get; set; } = new OffensiveDefensiveStats();

  public static EquipmentStats operator +(EquipmentStats a, EquipmentStats b)
  {
    return new EquipmentStats()
    {
      Bonuses = a.Bonuses + b.Bonuses,
      Offensive = a.Offensive + b.Offensive,
      Defensive = a.Defensive + b.Defensive,
    };
  }

  public static EquipmentStats operator -(EquipmentStats a, EquipmentStats b)
  {
    return new EquipmentStats()
    {
      Bonuses = a.Bonuses - b.Bonuses,
      Offensive = a.Offensive - b.Offensive,
      Defensive = a.Defensive - b.Defensive,
    };
  }
}
