namespace Pcote.OsrsDpsCalc.Calculations;

public class MeleeMaxHitStrategy : IMaxHitStrategy
{
  public static int compute(CalculationOptions options)
  {
    int strengthLvl = options.Player.Skills.Strength;
    int effectiveStrength = (int)Math.Floor(options.Player.Potions.SkillBaseBuffs.Strength + strengthLvl * options.Player.Potions.SkillsMultipliers.Strength);
    effectiveStrength = (int)Math.Floor(effectiveStrength * options.Player.Prayers.Buffs.MeleeStrengthMultiplier);
    // effectiveStrength += options.player.Style; // TODO Style bonus
    effectiveStrength += 8;
    // TODO Void Bonus

    int baseDamage = (int)Math.Floor(0.5 + effectiveStrength * ((options.Player.Equipment.Bonuses.Strength + 64) / 640d));

    // TODO special attacks / passive effects

    return baseDamage;
  }
}
