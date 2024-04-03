
using System.Text.Json;
using Pcote.OsrsDpsCalc.Contracts;
using Pcote.OsrsDpsCalc.Entities;
using Pcote.OsrsDpsCalc.Enums;

namespace Pcote.OsrsDpsCalc.Serialization;

public static class EquipmentParser
{
  private static readonly JsonSerializerOptions _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters = { new ForgivingStringConverter() } };
  public static List<EquipmentPiece> Parse(string json)
  {
    List<EquipmentResponse> response = JsonSerializer.Deserialize<List<EquipmentResponse>>(json, _options) ?? [];
    List<EquipmentPiece> equipments = [];
    foreach (EquipmentResponse m in response)
      equipments.Add(MapEquipmentResponseToEquipmentPiece(m));
    return equipments;
  }

  public static List<EquipmentPiece> ParseFile(string filePath)
  {
    return Parse(File.ReadAllText(filePath));
  }

  private static EquipmentPiece MapEquipmentResponseToEquipmentPiece(EquipmentResponse equipmentResponse)
  {
    EquipmentPiece equipment = new EquipmentPiece()
    {
      Id = equipmentResponse.Id,
      Name = equipmentResponse.Name,
      Image = equipmentResponse.Image,
      Version = equipmentResponse.Version,
      Speed = equipmentResponse.Speed,
      IsTwoHanded = equipmentResponse.IsTwoHanded,
      Category = MapCategoryResponseToEquipmentCategory(equipmentResponse.Category),
      Slot = MapSlotResponseToEquipmentSlot(equipmentResponse.Slot),
      Offensive = MapEquipmentStatsResponseToOffensiveDefensiveStats(equipmentResponse.Offensive),
      Defensive = MapEquipmentStatsResponseToOffensiveDefensiveStats(equipmentResponse.Defensive),
      Bonuses = MapBonusesResponseToEquipmentBonuses(equipmentResponse.Bonuses),
    };
    return equipment;
  }

  private static EquipmentCategory MapCategoryResponseToEquipmentCategory(string categoryResponse)
  {
    if (!Enum.TryParse(categoryResponse.Replace(" ", ""), true, out EquipmentCategory category))
      category = EquipmentCategory.None;
    return category;
  }

  private static EquipmentSlot MapSlotResponseToEquipmentSlot(string slotResponse)
  {
    if (!Enum.TryParse(slotResponse.Replace(" ", ""), true, out EquipmentSlot slot))
      slot = EquipmentSlot.None;
    return slot;
  }

  private static OffensiveDefensiveStats MapEquipmentStatsResponseToOffensiveDefensiveStats(EquipmentStatsReponse offensiveResponse)
  {
    return new OffensiveDefensiveStats()
    {
      Crush = offensiveResponse.Crush ?? 0,
      Magic = offensiveResponse.Magic ?? 0,
      Ranged = offensiveResponse.Ranged ?? 0,
      Slash = offensiveResponse.Slash ?? 0,
      Stab = offensiveResponse.Stab ?? 0,
    };
  }

  private static EquipmentBonuses MapBonusesResponseToEquipmentBonuses(BonusesResponse bonusesResponse)
  {
    return new EquipmentBonuses()
    {
      MagicStrength = bonusesResponse.MagicStr ?? 0,
      Prayer = bonusesResponse.Prayer ?? 0,
      RangedStrength = bonusesResponse.RangedStr ?? 0,
      Strength = bonusesResponse.Str ?? 0,
    };
  }
}

