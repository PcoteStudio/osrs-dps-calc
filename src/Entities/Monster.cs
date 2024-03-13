using Pcote.OsrsDpsCalc.Enums;

namespace Pcote.OsrsDpsCalc.Entities;

public class Monster
{
  public int Id { get; set; }
  public string Name { get; set; } = "";
  public string Image { get; set; } = "";
  public string Version { get; set; } = "";
  public int Level { get; set; }
  public int Size { get; set; }
  public int Speed { get; set; }
  public CombatStyleType[] Styles { get; set; } = [];
  public string MaxHit { get; set; } = "0";
  public CombatSkills Skills { get; set; } = new CombatSkills();
  public MonsterOffensiveStats Offensive { get; set; } = new MonsterOffensiveStats();
  public OffensiveDefensiveStats Defensive { get; set; } = new OffensiveDefensiveStats();
  public MonsterAttribute[] Attributes { get; set; } = [];
}
