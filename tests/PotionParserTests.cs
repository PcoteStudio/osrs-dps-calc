using Pcote.OsrsDpsCalc.Entities;
using Pcote.OsrsDpsCalc.Serialization;

namespace Pcote.OsrsDpsCalc.Tests;

public class PotionParserTests
{
  [Fact]
  public void Test_ParseFile_GameData()
  {
    string filePath = Directory.GetCurrentDirectory() + "\\..\\..\\..\\data\\potions.json";
    Potion[] equipments = PotionParser.ParseFile(filePath);
    Assert.True(equipments.Length >= 16);
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
    Potion[] potions = PotionParser.Parse(json);

    Potion[] expectedPotions = [new Potion() { Id = 2428 }];
    Assert.Equivalent(expectedPotions, potions);
  }

  [Fact]
  public void Test_Parse_FullAttackPotion()
  {
    string json = "[{\"id\": 2428,\"name\": \"Attack potion\",\"image\": \"Attack potion.png\","
    + "\"skillBaseBuffs\": { \"attack\": 3 },\"skillMultipliers\": { \"attack\": 1.1 }}]";
    Potion[] potions = PotionParser.Parse(json);

    Potion[] expectedPotions = [new Potion() {
      Id= 2428,
      Name = "Attack potion",
      Image = "Attack potion.png",
      SkillBaseBuffs = new PlayerCombatSkills() { Attack = 3 },
      SkillsMultipliers = new PlayerCombatSkillsMultipliers() { Attack = 1.1 },
    }];
    Assert.Equivalent(expectedPotions, potions);
  }
}
