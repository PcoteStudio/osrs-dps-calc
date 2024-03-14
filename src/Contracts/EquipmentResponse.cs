using System.Text.Json.Serialization;

namespace Pcote.OsrsDpsCalc.Contracts;

public class EquipmentResponse
{
  [JsonPropertyName("name")]
  public string Name { get; set; } = "";

  [JsonPropertyName("id")]
  public int Id { get; set; }

  [JsonPropertyName("version")]
  public string Version { get; set; } = "";

  [JsonPropertyName("slot")]
  public string Slot { get; set; } = "";

  [JsonPropertyName("image")]
  public string Image { get; set; } = "";

  [JsonPropertyName("speed")]
  public int Speed { get; set; }

  [JsonPropertyName("category")]
  public string Category { get; set; } = "";

  [JsonPropertyName("bonuses")]
  public BonusesResponse Bonuses { get; set; } = new BonusesResponse();

  [JsonPropertyName("offensive")]
  public EquipmentStatsReponse Offensive { get; set; } = new EquipmentStatsReponse();

  [JsonPropertyName("defensive")]
  public EquipmentStatsReponse Defensive { get; set; } = new EquipmentStatsReponse();

  [JsonPropertyName("isTwoHanded")]
  public bool IsTwoHanded { get; set; }
}

public partial class EquipmentStatsReponse
{
  [JsonPropertyName("stab")]
  public int? Stab { get; set; }

  [JsonPropertyName("slash")]
  public int? Slash { get; set; }

  [JsonPropertyName("crush")]
  public int? Crush { get; set; }

  [JsonPropertyName("magic")]
  public int? Magic { get; set; }

  [JsonPropertyName("ranged")]
  public int? Ranged { get; set; }
}

public partial class BonusesResponse
{
  [JsonPropertyName("str")]
  public int? Str { get; set; }

  [JsonPropertyName("ranged_str")]
  public int? RangedStr { get; set; }

  [JsonPropertyName("magic_str")]
  public int? MagicStr { get; set; }

  [JsonPropertyName("prayer")]
  public int? Prayer { get; set; }
}
