using Pcote.OsrsDpsCalc.Entities;
using Pcote.OsrsDpsCalc.Enums;
using Pcote.OsrsDpsCalc.Serialization;

namespace Pcote.OsrsDpsCalc.Tests.Serialization;

public class SpellParserTests
{
  [Fact]
  public void Test_ParseFile_GameData()
  {
    string filePath = Directory.GetCurrentDirectory() + "\\..\\..\\..\\data\\spells.json";
    List<Spell> spells = SpellParser.ParseFile(filePath);

    Assert.True(spells.Count >= 61);
  }

  [Fact]
  public void Test_ParseFile_FileNotFound()
  {
    string filePath = Directory.GetCurrentDirectory() + "\\..\\..\\..\\data\\randomfilepath.json";

    Assert.Throws<FileNotFoundException>(() => SpellParser.ParseFile(filePath));
  }

  [Fact]
  public void Test_Parse_MissingAttributes()
  {
    string json = "[{ \"spellbook\": \"standard\" }]";
    List<Spell> spells = SpellParser.Parse(json);

    List<Spell> expectedSpells = [new Spell() {
      Name = "",
      Image = "",
      MaxHit = 0,
      Spellbook = Spellbook.Standard,
    }];
    Assert.Equivalent(expectedSpells, spells);
  }

  [Fact]
  public void Test_Parse_InvalidSpellbook()
  {
    string json = "[{ \"name\": \"My Name\", \"image\": \"My Image.png\", \"max_hit\": 42, \"spellbook\": \"foobar\"}]";

    Assert.Throws<ArgumentException>(() => SpellParser.Parse(json));
  }

  [Fact]
  public void Test_Parse_StandardSpellbook()
  {
    string json = "[{ \"name\": \"Crumble Undead\", \"image\": \"Crumble Undead.png\", \"max_hit\": 15, \"spellbook\": \"standard\"}]";
    List<Spell> spells = SpellParser.Parse(json);

    List<Spell> expectedSpells = [new Spell() { Name = "Crumble Undead", Image = "Crumble Undead.png", MaxHit = 15, Spellbook = Spellbook.Standard }];
    Assert.Equivalent(expectedSpells, spells);
  }

  [Fact]
  public void Test_Parse_ArceuusSpellbook()
  {
    string json = "[{ \"name\": \"Dark Demonbane\", \"image\": \"Dark Demonbane.png\", \"max_hit\": 30, \"spellbook\": \"arceuus\"}]";
    List<Spell> spells = SpellParser.Parse(json);

    List<Spell> expectedSpells = [new Spell() { Name = "Dark Demonbane", Image = "Dark Demonbane.png", MaxHit = 30, Spellbook = Spellbook.Arceuus }];
    Assert.Equivalent(expectedSpells, spells);
  }

  [Fact]
  public void Test_Parse_AncientSpellbook()
  {
    string json = "[{ \"name\": \"Ice Burst\", \"image\": \"Ice Burst.png\", \"max_hit\": 22, \"spellbook\": \"ancient\"}]";
    List<Spell> spells = SpellParser.Parse(json);

    List<Spell> expectedSpells = [new Spell() { Name = "Ice Burst", Image = "Ice Burst.png", MaxHit = 22, Spellbook = Spellbook.Ancient }];
    Assert.Equivalent(expectedSpells, spells);
  }
}
