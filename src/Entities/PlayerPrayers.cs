namespace Pcote.OsrsDpsCalc.Entities;

public class PlayerPrayers
{
  private List<Prayer> _prayers = [];
  public List<Prayer> Prayers { get => _prayers; }
  public PrayerBuffs Buffs { get; set; } = new PrayerBuffs();

  public List<Prayer> ActivatePrayer(Prayer prayer)
  {
    for (int i = 0; i < _prayers.Count; i++)
    {
      if (!isCompatible(prayer, _prayers[i]))
      {
        Buffs -= _prayers[i].Buffs;
        _prayers.RemoveAt(i);
        i--;
      }
    }
    Buffs += prayer.Buffs;
    _prayers.Add(prayer);
    return _prayers;
  }

  public List<Prayer> DeactivatePrayer(Prayer prayer)
  {
    if (_prayers.Contains(prayer))
    {
      Buffs -= prayer.Buffs;
      _prayers.Remove(prayer);
    }
    return _prayers;
  }

  /// <summary>
  /// Two prayers are compatible if they buff the same combat style without affecting the same multipliers.
  /// </summary>
  /// <param name="newPrayer">Newly activated prayer</param>
  /// <param name="activatedPrayer">Already activated prayer</param>
  /// <returns>True if both prayers can be activated at the same time</returns>
  private bool isCompatible(Prayer newPrayer, Prayer activatedPrayer)
  {
    // If they affect the same multipliers
    if (newPrayer.Buffs.MagicAccuracyMultiplier != 1 && activatedPrayer.Buffs.MagicAccuracyMultiplier != 1
    || newPrayer.Buffs.MagicStrengthMultiplier != 1 && activatedPrayer.Buffs.MagicStrengthMultiplier != 1
    || newPrayer.Buffs.MeleeAccuracyMultiplier != 1 && activatedPrayer.Buffs.MeleeAccuracyMultiplier != 1
    || newPrayer.Buffs.MeleeStrengthMultiplier != 1 && activatedPrayer.Buffs.MeleeStrengthMultiplier != 1
    || newPrayer.Buffs.RangedAccuracyMultiplier != 1 && activatedPrayer.Buffs.RangedAccuracyMultiplier != 1
    || newPrayer.Buffs.RangedStrengthMultiplier != 1 && activatedPrayer.Buffs.RangedStrengthMultiplier != 1
    || newPrayer.Buffs.DefenceMultiplier != 1 && activatedPrayer.Buffs.DefenceMultiplier != 1)
      return false;

    // If they affect different styles
    if ((newPrayer.Buffs.MagicAccuracyMultiplier != 1 || newPrayer.Buffs.MagicStrengthMultiplier != 1)
    && (activatedPrayer.Buffs.RangedAccuracyMultiplier != 1 || activatedPrayer.Buffs.RangedStrengthMultiplier != 1
    || activatedPrayer.Buffs.MeleeAccuracyMultiplier != 1 || activatedPrayer.Buffs.MeleeStrengthMultiplier != 1)
    || (newPrayer.Buffs.MeleeAccuracyMultiplier != 1 || newPrayer.Buffs.MeleeStrengthMultiplier != 1)
    && (activatedPrayer.Buffs.RangedAccuracyMultiplier != 1 || activatedPrayer.Buffs.RangedStrengthMultiplier != 1
    || activatedPrayer.Buffs.MagicAccuracyMultiplier != 1 || activatedPrayer.Buffs.MagicStrengthMultiplier != 1)
    || (newPrayer.Buffs.RangedAccuracyMultiplier != 1 || newPrayer.Buffs.RangedStrengthMultiplier != 1)
    && (activatedPrayer.Buffs.MeleeAccuracyMultiplier != 1 || activatedPrayer.Buffs.MeleeStrengthMultiplier != 1
    || activatedPrayer.Buffs.MagicAccuracyMultiplier != 1 || activatedPrayer.Buffs.MagicStrengthMultiplier != 1))
      return false;

    return true;
  }
}
