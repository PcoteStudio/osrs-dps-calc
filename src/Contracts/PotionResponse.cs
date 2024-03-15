using System.Text.Json.Serialization;

namespace Pcote.OsrsDpsCalc.Contracts;

public class PotionResponse
{
  [JsonPropertyName("id")]
  public int Id { get; set; }

  [JsonPropertyName("name")]
  public string Name { get; set; } = "";

  [JsonPropertyName("image")]
  public string Image { get; set; } = "";

  [JsonPropertyName("skillBaseBuffs")]
  public SkillResponse SkillBaseBuffs { get; set; } = new SkillResponse();

  [JsonPropertyName("skillMultipliers")]
  public SkillResponse SkillMultipliers { get; set; } = new SkillResponse();
}

public class SkillResponse
{

  [JsonPropertyName("attack")]
  public double? Attack { get; set; }

  [JsonPropertyName("defence")]
  public double? Defence { get; set; }

  [JsonPropertyName("hitpoints")]
  public double? Hitpoints { get; set; }

  [JsonPropertyName("magic")]
  public double? Magic { get; set; }

  [JsonPropertyName("prayer")]
  public double? Prayer { get; set; }

  [JsonPropertyName("mining")]
  public double? Mining { get; set; }

  [JsonPropertyName("ranged")]
  public double? Ranged { get; set; }

  [JsonPropertyName("strength")]
  public double? Strength { get; set; }
}
