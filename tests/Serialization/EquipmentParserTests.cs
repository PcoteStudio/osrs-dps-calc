using Pcote.OsrsDpsCalc.Entities;
using Pcote.OsrsDpsCalc.Enums;
using Pcote.OsrsDpsCalc.Serialization;

namespace Pcote.OsrsDpsCalc.Tests.Serialization;

public class EquipmentParserTests
{
  [Fact]
  public void Test_ParseFile_GameData()
  {
    string filePath = Directory.GetCurrentDirectory() + "\\..\\..\\..\\data\\equipment.json";
    List<EquipmentPiece> equipments = EquipmentParser.ParseFile(filePath);
    Assert.True(equipments.Count >= 4560);
  }

  [Fact]
  public void Test_ParseFile_FileNotFound()
  {
    string filePath = Directory.GetCurrentDirectory() + "\\..\\..\\..\\data\\randomfilepath.json";

    Assert.Throws<FileNotFoundException>(() => EquipmentParser.ParseFile(filePath));
  }

  [Fact]
  public void Test_Parse_MissingAttributes()
  {
    string json = "[{\"id\":1279}]";
    List<EquipmentPiece> equipments = EquipmentParser.Parse(json);

    List<EquipmentPiece> expectedEquipments = [new EquipmentPiece() { Id = 1279 }];
    Assert.Equivalent(expectedEquipments, equipments);
  }

  [Fact]
  public void Test_Parse_FullIronSword()
  {
    string json = "[{\"name\":\"Iron sword\",\"id\":1279,\"version\":\"\",\"slot\":\"weapon\",\"image\":\"Iron sword.png\",\"speed\":4,"
    + "\"category\":\"Stab Sword\",\"bonuses\":{\"str\":7,\"ranged_str\":0,\"magic_str\":0,\"prayer\":0},\"offensive\":{\"stab\":6,\"slash\":4,"
    + "\"crush\":-2,\"magic\":0,\"ranged\":0},\"defensive\":{\"stab\":0,\"slash\":2,\"crush\":1,\"magic\":0,\"ranged\":0},\"isTwoHanded\":false}]";
    List<EquipmentPiece> equipments = EquipmentParser.Parse(json);

    List<EquipmentPiece> expectedEquipments = [new EquipmentPiece() {
      Name = "Iron sword",
      Id= 1279,
      Version = "",
      Slot = EquipmentSlot.Weapon,
      Image = "Iron sword.png",
      Speed = 4,
      Category = EquipmentCategory.StabSword,
      Bonuses = new EquipmentBonuses() { Strength = 7 },
      Offensive = new OffensiveDefensiveStats() { Stab = 6, Slash = 4, Crush = -2 },
      Defensive = new OffensiveDefensiveStats() { Slash = 2, Crush = 1},
      IsTwoHanded = false,
    }];
    Assert.Equivalent(expectedEquipments, equipments);
  }
}
