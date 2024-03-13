using System.Text.Json.Serialization;

namespace Pcote.OsrsDpsCalc.Contracts;

public partial class SpellResponse
{
  [JsonPropertyName("name")]
  public string Name { get; set; } = "";

  [JsonPropertyName("image")]
  public string Image { get; set; } = "";

  [JsonPropertyName("max_hit")]
  public int MaxHit { get; set; } = 0;

  [JsonPropertyName("spellbook")]
  public string Spellbook { get; set; } = "";
}
