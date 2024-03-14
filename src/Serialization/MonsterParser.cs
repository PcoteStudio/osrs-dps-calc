using Pcote.OsrsDpsCalc.Entities;
using Pcote.OsrsDpsCalc.Contracts;
using Pcote.OsrsDpsCalc.Enums;
using System.Text.Json;

namespace Pcote.OsrsDpsCalc.Serialization;

public static class MonsterParser
{
  private static readonly JsonSerializerOptions _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters = { new ForgivingStringConverter() } };
  public static Monster[] Parse(string json)
  {
    MonsterResponse[] response = JsonSerializer.Deserialize<MonsterResponse[]>(json, _options) ?? [];
    List<Monster> monsters = [];
    foreach (MonsterResponse m in response)
      monsters.Add(MapMonsterResponseToMonster(m));
    return [.. monsters];
  }

  public static Monster[] ParseFile(string filePath)
  {
    return Parse(File.ReadAllText(filePath));
  }

  private static Monster MapMonsterResponseToMonster(MonsterResponse monsterResponse)
  {
    Monster monster = new Monster()
    {
      Id = monsterResponse.Id,
      Name = monsterResponse.Name,
      Image = monsterResponse.Image,
      Version = monsterResponse.Version,
      Level = monsterResponse.Level,
      Size = monsterResponse.Size,
      Speed = monsterResponse.Speed,
      MaxHit = monsterResponse.MaxHit,
      Styles = MapCombatStylesResponseToCombatStyles(monsterResponse.Styles ?? []),
      Skills = MapCombatSkillsResponseToCombatSkills(monsterResponse.Skills),
      Offensive = MapOffensiveResponseToOffensiveStats(monsterResponse.Offensive),
      Defensive = MapDefensiveResponseToDefensiveStats(monsterResponse.Defensive),
      Attributes = MapAttributesResponseToMonsterAttributes(monsterResponse.Attributes),
    };
    return monster;
  }

  private static CombatSkills MapCombatSkillsResponseToCombatSkills(int[] combatSkillsResponse)
  {
    return new CombatSkills()
    {
      Attack = combatSkillsResponse.ElementAtOrDefault(0),
      Defence = combatSkillsResponse.ElementAtOrDefault(1),
      Hitpoints = combatSkillsResponse.ElementAtOrDefault(2),
      Magic = combatSkillsResponse.ElementAtOrDefault(3),
      Range = combatSkillsResponse.ElementAtOrDefault(4),
      Strength = combatSkillsResponse.ElementAtOrDefault(5),
    };
  }

  private static MonsterOffensiveStats MapOffensiveResponseToOffensiveStats(int[] defensiveResponse)
  {
    return new MonsterOffensiveStats()
    {
      Attack = defensiveResponse.ElementAtOrDefault(0),
      Magic = defensiveResponse.ElementAtOrDefault(1),
      MagicStrength = defensiveResponse.ElementAtOrDefault(2),
      Ranged = defensiveResponse.ElementAtOrDefault(3),
      RangedStrength = defensiveResponse.ElementAtOrDefault(4),
      Strength = defensiveResponse.ElementAtOrDefault(5),
    };
  }

  private static OffensiveDefensiveStats MapDefensiveResponseToDefensiveStats(int[] defensiveResponse)
  {
    return new OffensiveDefensiveStats()
    {
      Crush = defensiveResponse.ElementAtOrDefault(0),
      Magic = defensiveResponse.ElementAtOrDefault(1),
      Ranged = defensiveResponse.ElementAtOrDefault(2),
      Slash = defensiveResponse.ElementAtOrDefault(3),
      Stab = defensiveResponse.ElementAtOrDefault(4),
    };
  }

  private static CombatStyleType[] MapCombatStylesResponseToCombatStyles(string[] combatStylesResponse)
  {
    List<CombatStyleType> styles = new List<CombatStyleType>();
    foreach (string s in combatStylesResponse)
    {
      var style = s.ToLower() switch
      {
        "n/a" or "none" => CombatStyleType.None,
        "area of effect" => CombatStyleType.Area,
        "icy breath" => CombatStyleType.IcyBreath,
        "magical melee" => CombatStyleType.MagicalMelee,
        "magical ranged" => CombatStyleType.MagicalMelee,
        "ranged magic" => CombatStyleType.RangedMagic,
        "single and multi-target ranged" => CombatStyleType.Ranged,
        "volcanic flame" => CombatStyleType.VolcanicFlame,
        _ => (CombatStyleType)Enum.Parse(typeof(CombatStyleType), s.Split(' ', '(')[0], true),
      };
      styles.Add(style);
    }
    return [.. styles];
  }

  private static MonsterAttribute[] MapAttributesResponseToMonsterAttributes(string[] attributeResponse)
  {
    List<MonsterAttribute> attributes = new List<MonsterAttribute>();
    foreach (string a in attributeResponse)
      attributes.Add((MonsterAttribute)Enum.Parse(typeof(MonsterAttribute), a, true));
    return [.. attributes];
  }
}
