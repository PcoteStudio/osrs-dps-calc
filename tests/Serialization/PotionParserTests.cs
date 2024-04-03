using Pcote.OsrsDpsCalc.Entities;
using Pcote.OsrsDpsCalc.Serialization;

namespace Pcote.OsrsDpsCalc.Tests.Serialization;

public class PotionParserTests
{
  [Fact]
  public void Test_ParseFile_GameData()
  {
    string filePath = Directory.GetCurrentDirectory() + "\\..\\..\\..\\data\\potions.json";
    List<Potion> equipments = PotionParser.ParseFile(filePath);
    Assert.True(equipments.Count >= 16);
  }

  [Fact]
  public void Test_ParseFile_FileNotFound()
  {
    string filePath = Directory.GetCurrentDirectory() + "\\..\\..\\..\\data\\randomfilepath.json";

    Assert.Throws<FileNotFoundException>(() => PotionParser.ParseFile(filePath));
  }

  [Fact]
  public void Test_Parse_MissingAttributes()
  {
    string json = "[{\"id\":2428}]";
    List<Potion> potions = PotionParser.Parse(json);

    List<Potion> expectedPotions = [new Potion() {
      Id= 2428,
      Name = "",
      Image = "",
      SkillBaseBuffs = new PlayerCombatSkills() {
        Attack = 0,
        Defence = 0,
        Hitpoints = 0,
        Magic = 0,
        Mining = 0,
        Prayer = 0,
        Ranged = 0,
        Strength = 0,
      },
      SkillsMultipliers = new PlayerCombatSkillsMultipliers() {
        Attack = 1,
        Defence = 1,
        Hitpoints = 1,
        Magic = 1,
        Mining = 1,
        Prayer = 1,
        Ranged = 1,
        Strength = 1,
      },
    }];
    Assert.Equivalent(expectedPotions, potions);
  }

  [Fact]
  public void Test_Parse_FullAttackPotion()
  {
    string json = "[{\"id\": 2428,\"name\": \"Attack potion\",\"image\": \"Attack potion.png\","
    + "\"skillBaseBuffs\": { \"attack\": 3 },\"skillMultipliers\": { \"attack\": 1.1 }}]";
    List<Potion> potions = PotionParser.Parse(json);

    List<Potion> expectedPotions = [new Potion() {
      Id= 2428,
      Name = "Attack potion",
      Image = "Attack potion.png",
      SkillBaseBuffs = new PlayerCombatSkills() {
        Attack = 3,
        Defence = 0,
        Hitpoints = 0,
        Magic = 0,
        Mining = 0,
        Prayer = 0,
        Ranged = 0,
        Strength = 0,
      },
      SkillsMultipliers = new PlayerCombatSkillsMultipliers() {
        Attack = 1.1,
        Defence = 1,
        Hitpoints = 1,
        Magic = 1,
        Mining = 1,
        Prayer = 1,
        Ranged = 1,
        Strength = 1,
      },
    }];
    Assert.Equivalent(expectedPotions, potions);
  }
}
