using Pcote.OsrsDpsCalc.Entities;
using Pcote.OsrsDpsCalc.Serialization;

namespace Pcote.OsrsDpsCalc.Tests.Serialization;

public class PrayerParserTests
{
  [Fact]
  public void Test_ParseFile_GameData()
  {
    string filePath = Directory.GetCurrentDirectory() + "\\..\\..\\..\\data\\prayers.json";
    List<Prayer> prayers = PrayerParser.ParseFile(filePath);

    Assert.True(prayers.Count >= 19);
  }

  [Fact]
  public void Test_ParseFile_FileNotFound()
  {
    string filePath = Directory.GetCurrentDirectory() + "\\..\\..\\..\\data\\randomfilepath.json";

    Assert.Throws<FileNotFoundException>(() => PrayerParser.ParseFile(filePath));
  }

  [Fact]
  public void Test_Parse_MissingAttributes()
  {
    string json = "[{ \"combatStyle\": \"magic\" }]";
    List<Prayer> prayers = PrayerParser.Parse(json);

    List<Prayer> expectedPrayers = [new Prayer() {
      Name = "",
      Image = "",
      Buffs = new PrayerBuffs() {
        MagicAccuracyMultiplier = 1,
        MagicStrengthMultiplier = 1,
        MeleeAccuracyMultiplier = 1,
        MeleeStrengthMultiplier = 1,
        RangedAccuracyMultiplier = 1,
        RangedStrengthMultiplier = 1,
        DefenceMultiplier = 1
      }
    }];
    Assert.Equivalent(expectedPrayers, prayers);
  }

  [Fact]
  public void Test_Parse_FullAugury()
  {
    string json = "[{\"name\": \"Augury\", \"image\": \"Augury.png\", \"combatStyle\": \"magic\","
+ "\"accuracyMultiplier\": 1.25, \"strengthMultiplier\": 1, \"defenceMultiplier\": 1.25}]";
    List<Prayer> prayers = PrayerParser.Parse(json);

    List<Prayer> expectedPrayers = [new Prayer() {
      Name = "Augury",
      Image = "Augury.png",
      Buffs = new PrayerBuffs() {
        MagicAccuracyMultiplier = 1.25,
        MagicStrengthMultiplier = 1,
        DefenceMultiplier = 1.25
      }
    }];
    Assert.Equivalent(expectedPrayers, prayers);
  }
}
