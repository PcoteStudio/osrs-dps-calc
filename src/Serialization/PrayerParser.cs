using System.Text.Json;
using Pcote.OsrsDpsCalc.Contracts;
using Pcote.OsrsDpsCalc.Entities;
using Pcote.OsrsDpsCalc.Enums;

namespace Pcote.OsrsDpsCalc.Serialization;

public static class PrayerParser
{
  private static readonly JsonSerializerOptions _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters = { new ForgivingStringConverter() } };
  public static List<Prayer> Parse(string json)
  {
    List<PrayerResponse> response = JsonSerializer.Deserialize<List<PrayerResponse>>(json, _options) ?? [];
    List<Prayer> prayers = [];
    foreach (PrayerResponse p in response)
      prayers.Add(MapPrayerResponseToPrayer(p));
    return [.. prayers];
  }

  public static List<Prayer> ParseFile(string filePath)
  {
    return Parse(File.ReadAllText(filePath));
  }

  private static Prayer MapPrayerResponseToPrayer(PrayerResponse prayerResponse)
  {
    Prayer prayer = new Prayer()
    {
      Name = prayerResponse.Name,
      Image = prayerResponse.Image,
      Buffs = new PrayerBuffs() { DefenceMultiplier = prayerResponse.DefenceMultiplier },
    };
    switch (prayerResponse.CombatStyle.ToLower())
    {
      case "magic":
        prayer.Buffs.MagicAccuracyMultiplier = prayerResponse.AccuracyMultiplier;
        prayer.Buffs.MagicStrengthMultiplier = prayerResponse.StrengthMultiplier;
        break;
      case "melee":
        prayer.Buffs.MeleeAccuracyMultiplier = prayerResponse.AccuracyMultiplier;
        prayer.Buffs.MeleeStrengthMultiplier = prayerResponse.StrengthMultiplier;
        break;
      case "ranged":
        prayer.Buffs.RangedAccuracyMultiplier = prayerResponse.AccuracyMultiplier;
        prayer.Buffs.RangedStrengthMultiplier = prayerResponse.StrengthMultiplier;
        break;
    }
    return prayer;
  }
}
