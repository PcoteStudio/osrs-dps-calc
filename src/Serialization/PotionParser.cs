using System.Text.Json;
using Pcote.OsrsDpsCalc.Contracts;
using Pcote.OsrsDpsCalc.Entities;

namespace Pcote.OsrsDpsCalc.Serialization;

public static class PotionParser
{
  private static readonly JsonSerializerOptions _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters = { new ForgivingStringConverter() } };
  public static Potion[] Parse(string json)
  {
    PotionResponse[] response = JsonSerializer.Deserialize<PotionResponse[]>(json, _options) ?? [];
    List<Potion> potions = [];
    foreach (PotionResponse m in response)
      potions.Add(MapPotionResponseToPotion(m));
    return [.. potions];
  }

  public static Potion[] ParseFile(string filePath)
  {
    return Parse(File.ReadAllText(filePath));
  }

  private static Potion MapPotionResponseToPotion(PotionResponse potionResponse)
  {
    Potion potion = new Potion()
    {
      Id = potionResponse.Id,
      Name = potionResponse.Name,
      Image = potionResponse.Image,
      SkillBaseBuffs = MapSkillBuffResponseToSkillBaseBuffs(potionResponse.SkillBaseBuffs),
      SkillsMultipliers = MapSkilMultipliersResponseToSkillMultipliers(potionResponse.SkillMultipliers),
    };
    return potion;
  }

  private static PlayerCombatSkills MapSkillBuffResponseToSkillBaseBuffs(SkillResponse skillBaseBuffResponse)
  {
    return new PlayerCombatSkills()
    {
      Attack = (int)(skillBaseBuffResponse?.Attack ?? 0),
      Defence = (int)(skillBaseBuffResponse?.Defence ?? 0),
      Hitpoints = (int)(skillBaseBuffResponse?.Hitpoints ?? 0),
      Magic = (int)(skillBaseBuffResponse?.Magic ?? 0),
      Mining = (int)(skillBaseBuffResponse?.Mining ?? 0),
      Prayer = (int)(skillBaseBuffResponse?.Prayer ?? 0),
      Ranged = (int)(skillBaseBuffResponse?.Ranged ?? 0),
      Strength = (int)(skillBaseBuffResponse?.Strength ?? 0),
    };
  }

  private static PlayerCombatSkillsMultipliers MapSkilMultipliersResponseToSkillMultipliers(SkillResponse skillsMultipliersResponse)
  {
    return new PlayerCombatSkillsMultipliers()
    {
      Attack = skillsMultipliersResponse?.Attack ?? 0,
      Defence = skillsMultipliersResponse?.Defence ?? 0,
      Hitpoints = skillsMultipliersResponse?.Hitpoints ?? 0,
      Magic = skillsMultipliersResponse?.Magic ?? 0,
      Mining = skillsMultipliersResponse?.Mining ?? 0,
      Prayer = skillsMultipliersResponse?.Prayer ?? 0,
      Ranged = skillsMultipliersResponse?.Ranged ?? 0,
      Strength = skillsMultipliersResponse?.Strength ?? 0,
    };
  }
}
