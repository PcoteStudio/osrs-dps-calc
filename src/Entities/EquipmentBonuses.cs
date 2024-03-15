namespace Pcote.OsrsDpsCalc.Entities;

public class EquipmentBonuses
{
  public int Strength { get; set; }
  public int MagicStrength { get; set; }
  public int Prayer { get; set; }
  public int RangedStrength { get; set; }

  public static EquipmentBonuses operator +(EquipmentBonuses a, EquipmentBonuses b)
  {
    return new EquipmentBonuses()
    {
      Strength = a.Strength + b.Strength,
      MagicStrength = a.MagicStrength + b.MagicStrength,
      Prayer = a.Prayer + b.Prayer,
      RangedStrength = a.RangedStrength + b.RangedStrength,
    };
  }

  public static EquipmentBonuses operator -(EquipmentBonuses a, EquipmentBonuses b)
  {
    return new EquipmentBonuses()
    {
      Strength = a.Strength - b.Strength,
      MagicStrength = a.MagicStrength - b.MagicStrength,
      Prayer = a.Prayer - b.Prayer,
      RangedStrength = a.RangedStrength - b.RangedStrength,
    };
  }
}
