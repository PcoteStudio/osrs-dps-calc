using Pcote.OsrsDpsCalc.Serialization;

namespace Pcote.OsrsDpsCalc.Entities;

public class Sandbox
{
  public List<EquipmentPiece> Equipment { get; } = [];
  public List<Monster> Monsters { get; } = [];
  public List<Potion> Potions { get; } = [];
  public List<Prayer> Prayers { get; } = [];
  public List<Spell> Spells { get; } = [];

  public Sandbox()
  {
    string dataDirectory = Directory.GetCurrentDirectory() + "\\..\\..\\..\\data\\";
    Equipment = EquipmentParser.ParseFile(dataDirectory + "equipment.json");
    Monsters = MonsterParser.ParseFile(dataDirectory + "monsters.json");
    Potions = PotionParser.ParseFile(dataDirectory + "potions.json");
    Prayers = PrayerParser.ParseFile(dataDirectory + "prayers.json");
    Spells = SpellParser.ParseFile(dataDirectory + "spells.json");
  }
}
