using Pcote.OsrsDpsCalc.Entities;
using Pcote.OsrsDpsCalc.Enums;
using Pcote.OsrsDpsCalc.Serialization;

namespace Pcote.OsrsDpsCalc.Tests;

public class MonsterParserTests
{
  [Fact]
  public void Test_ParseFile_GameData()
  {
    string filePath = Directory.GetCurrentDirectory() + "\\..\\..\\..\\data\\monsters.json";
    Monster[] monsters = MonsterParser.ParseFile(filePath);
    Assert.True(monsters.Length >= 2250);
  }

  [Fact]
  public void Test_ParseFile_FileNotFound()
  {
    string filePath = Directory.GetCurrentDirectory() + "\\..\\..\\..\\data\\randomfilepath.json";

    Assert.Throws<FileNotFoundException>(() => MonsterParser.ParseFile(filePath));
  }

  [Fact]
  public void Test_Parse_MissingAttributes()
  {
    string json = "[{\"id\":7402}]";
    Monster[] monsters = MonsterParser.Parse(json);

    Monster[] expectedMonsters = [new Monster() { Id = 7402 }];
    Assert.Equivalent(expectedMonsters, monsters);
  }

  [Fact]
  public void Test_Parse_FullAbhorrentSpectre()
  {
    string json = "[{\"id\":7402,\"name\":\"Abhorrent spectre\",\"version\":\"\",\"image\":\"Abhorrent spectre.png\",\"level\":253,"
    + "\"speed\":4,\"style\":[\"Magic\"],\"size\":3,\"max_hit\":\"31\",\"skills\":[1,180,250,300,1,1],\"offensive\":[0,0,0,0,0,0]," +
    "\"defensive\":[40,0,30,40,40],\"attributes\":[\"spectral\",\"undead\"]}]";
    Monster[] monsters = MonsterParser.Parse(json);

    Monster[] expectedMonsters = [new Monster() {
      Id = 7402,
      Name = "Abhorrent spectre",
      Version = "",
      Image = "Abhorrent spectre.png",
      Level = 253,
      Speed = 4,
      Size = 3,
      Styles = [CombatStyleType.Magic],
      MaxHit = "31",
      Skills = new CombatSkills() { Attack = 1, Defence = 180, Hitpoints = 250, Magic = 300, Range = 1, Strength = 1 },
      Offensive = new MonsterOffensiveStats(),
      Defensive = new OffensiveDefensiveStats() { Crush = 40, Magic = 0, Ranged = 30, Slash = 40, Stab = 40 },
      Attributes = [MonsterAttribute.Spectral, MonsterAttribute.Undead]
    }];
    Assert.Equivalent(expectedMonsters, monsters);
  }
}
