using Pcote.OsrsDpsCalc.Enums;

namespace Pcote.OsrsDpsCalc.Entities;

public class EquipmentPiece : EquipmentStats
{
  public string Name { get; set; } = "";
  public int Id { get; set; }
  public string Version { get; set; } = "";
  public EquipmentSlot Slot { get; set; }
  public string Image { get; set; } = "";
  public int Speed { get; set; }
  public EquipmentCategory Category { get; set; }
  public bool IsTwoHanded { get; set; }
}
