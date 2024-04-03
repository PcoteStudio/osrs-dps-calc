namespace Pcote.OsrsDpsCalc.Entities;

public class PrayerBuffs
{
  public double MeleeAccuracyMultiplier { get; set; } = 1;
  public double MeleeStrengthMultiplier { get; set; } = 1;
  public double RangedAccuracyMultiplier { get; set; } = 1;
  public double RangedStrengthMultiplier { get; set; } = 1;
  public double MagicAccuracyMultiplier { get; set; } = 1;
  public double MagicStrengthMultiplier { get; set; } = 1;
  public double DefenceMultiplier { get; set; } = 1;

  public static PrayerBuffs operator +(PrayerBuffs a, PrayerBuffs b)
  {
    return new PrayerBuffs()
    {
      MagicAccuracyMultiplier = a.MagicAccuracyMultiplier + b.MagicAccuracyMultiplier - 1,
      MagicStrengthMultiplier = a.MagicStrengthMultiplier + b.MagicStrengthMultiplier - 1,
      MeleeAccuracyMultiplier = a.MeleeAccuracyMultiplier + b.MeleeAccuracyMultiplier - 1,
      MeleeStrengthMultiplier = a.MeleeStrengthMultiplier + b.MeleeStrengthMultiplier - 1,
      RangedAccuracyMultiplier = a.RangedAccuracyMultiplier + b.RangedAccuracyMultiplier - 1,
      RangedStrengthMultiplier = a.RangedStrengthMultiplier + b.RangedStrengthMultiplier - 1,
      DefenceMultiplier = a.DefenceMultiplier + b.DefenceMultiplier - 1,
    };
  }

  public static PrayerBuffs operator -(PrayerBuffs a, PrayerBuffs b)
  {
    return new PrayerBuffs()
    {
      MagicAccuracyMultiplier = a.MagicAccuracyMultiplier - b.MagicAccuracyMultiplier + 1,
      MagicStrengthMultiplier = a.MagicStrengthMultiplier - b.MagicStrengthMultiplier + 1,
      MeleeAccuracyMultiplier = a.MeleeAccuracyMultiplier - b.MeleeAccuracyMultiplier + 1,
      MeleeStrengthMultiplier = a.MeleeStrengthMultiplier - b.MeleeStrengthMultiplier + 1,
      RangedAccuracyMultiplier = a.RangedAccuracyMultiplier - b.RangedAccuracyMultiplier + 1,
      RangedStrengthMultiplier = a.RangedStrengthMultiplier - b.RangedStrengthMultiplier + 1,
      DefenceMultiplier = a.DefenceMultiplier - b.DefenceMultiplier + 1,
    };
  }
}
