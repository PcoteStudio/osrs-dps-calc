using FluentAssertions;
using Pcote.OsrsDpsCalc.Entities;

namespace Pcote.OsrsDpsCalc.Tests.Entities;

public class PlayerPrayersTests
{
  readonly Sandbox sandbox = new();
  readonly PlayerPrayers playerPrayers = new();

  [Fact]
  public void Test_PlayerPrayers_ActivatePrayer()
  {
    TestSetup.Initialize();
    Prayer prayer = sandbox.Prayers.First();
    playerPrayers.ActivatePrayer(prayer);
    playerPrayers.Buffs.Should().BeEquivalentTo(prayer.Buffs);
    playerPrayers.Prayers.Should().BeEquivalentTo(new List<Prayer>([prayer]));
  }

  [Fact]
  public void Test_PlayerPrayers_ActivateCompatiblePrayers()
  {
    TestSetup.Initialize();
    Prayer superStrength = sandbox.Prayers.First(p => p.Name == "Superhuman Strength");
    List<Prayer> activatedPrayers1 = playerPrayers.ActivatePrayer(superStrength);
    playerPrayers.Buffs.Should().BeEquivalentTo(superStrength.Buffs);
    playerPrayers.Prayers.Should().BeEquivalentTo(new List<Prayer>([superStrength]));
    playerPrayers.Prayers.Should().BeEquivalentTo(new List<Prayer>(activatedPrayers1));

    Prayer improvedReflexes = sandbox.Prayers.First(p => p.Name == "Improved Reflexes");
    List<Prayer> activatedPrayers2 = playerPrayers.ActivatePrayer(improvedReflexes);
    playerPrayers.Buffs.Should().BeEquivalentTo(improvedReflexes.Buffs + superStrength.Buffs);
    playerPrayers.Prayers.Should().BeEquivalentTo(new List<Prayer>([superStrength, improvedReflexes]));
    playerPrayers.Prayers.Should().BeEquivalentTo(new List<Prayer>(activatedPrayers2));
  }

  [Fact]
  public void Test_PlayerPrayers_ActivateIncompatiblePrayers()
  {
    TestSetup.Initialize();
    Prayer piety = sandbox.Prayers.First(p => p.Name == "Piety");
    List<Prayer> activatedPrayers1 = playerPrayers.ActivatePrayer(piety);
    playerPrayers.Buffs.Should().BeEquivalentTo(piety.Buffs);
    playerPrayers.Prayers.Should().BeEquivalentTo(new List<Prayer>([piety]));
    playerPrayers.Prayers.Should().BeEquivalentTo(new List<Prayer>(activatedPrayers1));

    Prayer rigour = sandbox.Prayers.First(p => p.Name == "Rigour");
    List<Prayer> activatedPrayers2 = playerPrayers.ActivatePrayer(rigour);
    playerPrayers.Buffs.Should().BeEquivalentTo(rigour.Buffs);
    playerPrayers.Prayers.Should().BeEquivalentTo(new List<Prayer>([rigour]));
    playerPrayers.Prayers.Should().BeEquivalentTo(new List<Prayer>(activatedPrayers2));
  }
}
