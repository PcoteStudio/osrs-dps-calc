namespace Pcote.OsrsDpsCalc.Entities;

public class Player : EquipmentStats
{
  public string Name { get; set; } = "";
  public CombatStyle Style { get; set; } = new CombatStyle();
  public PlayerCombatSkills Skills { get; set; } = new PlayerCombatSkills();
  public PlayerCombatSkills Boosts { get; set; } = new PlayerCombatSkills();
  public PlayerEquipment Equipment { get; set; } = new PlayerEquipment();
  public PlayerPrayers Prayers { get; set; } = new PlayerPrayers();
  public PlayerBuffs Buffs { get; set; } = new PlayerBuffs();
  public Spell? Spell { get; set; }
}
