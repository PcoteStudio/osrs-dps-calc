using System.Text.Json.Serialization;

namespace Pcote.OsrsDpsCalc.Contracts;

public class PrayerResponse
{
  [JsonPropertyName("name")]
  public string Name { get; set; } = "";

  [JsonPropertyName("image")]
  public string Image { get; set; } = "";

  [JsonPropertyName("combatStyle")]
  public string CombatStyle { get; set; } = "None";

  [JsonPropertyName("accuracyMultiplier")]
  public double AccuracyMultiplier { get; set; } = 1;

  [JsonPropertyName("strengthMultiplier")]
  public double StrengthMultiplier { get; set; } = 1;

  [JsonPropertyName("defenceMultiplier")]
  public double DefenceMultiplier { get; set; } = 1;
}
