namespace Pcote.OsrsDpsCalc.Entities;

public class Player : EquipmentStats
{
  public string Name { get; set; } = "";
  public CombatStyle Style { get; set; } = new CombatStyle();
  public PlayerCombatSkills Skills { get; set; } = new PlayerCombatSkills() { Attack = 99, Defence = 99, Hitpoints = 99, Magic = 99, Mining = 99, Prayer = 99, Ranged = 99, Strength = 99 };
  public PlayerEquipment Equipment { get; set; } = new PlayerEquipment();
  public PlayerPrayers Prayers { get; set; } = new PlayerPrayers();
  public PlayerPotions Potions { get; set; } = new PlayerPotions();
  public PlayerBuffs Buffs { get; set; } = new PlayerBuffs();
  public Spell? Spell { get; set; }
}
