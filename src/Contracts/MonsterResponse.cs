using System.Text.Json.Serialization;

namespace Pcote.OsrsDpsCalc.Contracts;

public partial class MonsterResponse
{
  [JsonPropertyName("id")]
  public int Id { get; set; }
  [JsonPropertyName("name")]
  public string Name { get; set; } = "";
  [JsonPropertyName("version")]
  public string Version { get; set; } = "";
  [JsonPropertyName("image")]
  public string Image { get; set; } = "";
  [JsonPropertyName("level")]
  public int Level { get; set; }
  [JsonPropertyName("speed")]
  public int Speed { get; set; }
  [JsonPropertyName("style")]
  public string[] Styles { get; set; } = [];
  [JsonPropertyName("size")]
  public int Size { get; set; }
  [JsonPropertyName("max_hit")]
  public string MaxHit { get; set; } = "0";
  [JsonPropertyName("skills")]
  public int[] Skills { get; set; } = [];
  [JsonPropertyName("offensive")]
  public int[] Offensive { get; set; } = [];
  [JsonPropertyName("defensive")]
  public int[] Defensive { get; set; } = [];
  [JsonPropertyName("attributes")]
  public string[] Attributes { get; set; } = [];
}
