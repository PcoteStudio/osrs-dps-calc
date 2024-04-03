namespace Pcote.OsrsDpsCalc.Entities;

public class Prayer
{
  public string Name { get; set; } = "";
  public string Image { get; set; } = "";
  public PrayerBuffs Buffs { get; set; } = new PrayerBuffs();
}
