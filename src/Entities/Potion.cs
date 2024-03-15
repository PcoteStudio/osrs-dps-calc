namespace Pcote.OsrsDpsCalc.Entities;

public class Potion
{
  public int Id { get; set; }
  public string Name { get; set; } = "";
  public string Image { get; set; } = "";
  public PlayerCombatSkills SkillBaseBuffs { get; set; } = new PlayerCombatSkills();
  public PlayerCombatSkillsMultipliers SkillsMultipliers { get; set; } = new PlayerCombatSkillsMultipliers();
}
