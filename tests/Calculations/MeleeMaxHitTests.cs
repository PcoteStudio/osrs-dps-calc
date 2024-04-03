using FluentAssertions;
using Pcote.OsrsDpsCalc.Calculations;
using Pcote.OsrsDpsCalc.Entities;

namespace Pcote.OsrsDpsCalc.Tests.Calculations;

public class MeleeMaxHitTests
{
  readonly Sandbox sandbox = new();
  readonly CalculationOptions options = new();

  [Fact]
  public void Test_MeleeMaxHit_Weapon()
  {
    TestSetup.Initialize();

    EquipmentPiece elderMaul = sandbox.Equipment.First(e => e.Name == "Elder maul");

    options.Player.Equipment.Weapon = elderMaul;

    int maxHit = MeleeMaxHitStrategy.compute(options);
    maxHit.Should().Be(35);
  }

  [Fact]
  public void Test_MeleeMaxHit_WeaponPotion()
  {
    TestSetup.Initialize();

    EquipmentPiece elderMaul = sandbox.Equipment.First(e => e.Name == "Elder maul");
    Potion superCombat = sandbox.Potions.First(p => p.Name == "Super combat");

    options.Player.Equipment.Weapon = elderMaul;
    options.Player.Potions.DrinkPotion(superCombat);

    int maxHit = MeleeMaxHitStrategy.compute(options);
    maxHit.Should().Be(42);
  }

  [Fact]
  public void Test_MeleeMaxHit_WeaponPotionPrayer()
  {
    TestSetup.Initialize();

    EquipmentPiece elderMaul = sandbox.Equipment.First(e => e.Name == "Elder maul");
    Potion superCombat = sandbox.Potions.First(p => p.Name == "Super combat");
    Prayer piety = sandbox.Prayers.First(p => p.Name == "Piety");

    options.Player.Equipment.Weapon = elderMaul;
    options.Player.Prayers.ActivatePrayer(piety);
    options.Player.Potions.DrinkPotion(superCombat);

    int maxHit = MeleeMaxHitStrategy.compute(options);
    maxHit.Should().Be(50);
  }
}
