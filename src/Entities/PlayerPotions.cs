namespace Pcote.OsrsDpsCalc.Entities;

public class PlayerPotions
{
  private List<Potion> _potions = [];
  public List<Potion> Potions { get => _potions; }
  public PlayerCombatSkills SkillBaseBuffs { get; set; } = new PlayerCombatSkills();
  public PlayerCombatSkillsMultipliers SkillsMultipliers { get; set; } = new PlayerCombatSkillsMultipliers();

  public PlayerPotions()
  {
    UpdateBuffs();
  }

  public List<Potion> DrinkPotion(Potion potion)
  {
    _potions.Add(potion);
    UpdateBuffs();
    return _potions;
  }

  public List<Potion> FlushPotion(Potion potion)
  {
    _potions.Remove(potion);
    UpdateBuffs();
    return _potions;
  }

  private void UpdateBuffs()
  {
    SkillBaseBuffs.Attack = _potions.Max(p => (int?)p.SkillBaseBuffs.Attack) ?? 0;
    SkillBaseBuffs.Hitpoints = _potions.Max(p => (int?)p.SkillBaseBuffs.Hitpoints) ?? 0;
    SkillBaseBuffs.Magic = _potions.Max(p => (int?)p.SkillBaseBuffs.Magic) ?? 0;
    SkillBaseBuffs.Strength = _potions.Max(p => (int?)p.SkillBaseBuffs.Strength) ?? 0;
    SkillBaseBuffs.Defence = _potions.Max(p => (int?)p.SkillBaseBuffs.Defence) ?? 0;

    SkillsMultipliers.Attack = Math.Max(1, _potions.Max(p => (double?)p.SkillsMultipliers.Attack) ?? 1);
    SkillsMultipliers.Hitpoints = Math.Max(1, _potions.Max(p => (double?)p.SkillsMultipliers.Hitpoints) ?? 1);
    SkillsMultipliers.Magic = Math.Max(1, _potions.Max(p => (double?)p.SkillsMultipliers.Magic) ?? 1);
    SkillsMultipliers.Strength = Math.Max(1, _potions.Max(p => (double?)p.SkillsMultipliers.Strength) ?? 1);
    SkillsMultipliers.Defence = Math.Max(1, _potions.Max(p => (double?)p.SkillsMultipliers.Defence) ?? 1);
  }
}
