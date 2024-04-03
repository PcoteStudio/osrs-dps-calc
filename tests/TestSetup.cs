using FluentAssertions;

namespace Pcote.OsrsDpsCalc.Tests;

public static class TestSetup
{
  public static void Initialize()
  {
    AllowFloatingPointPrecisionLoss();
  }
  public static void AllowFloatingPointPrecisionLoss()
  {
    AssertionOptions.AssertEquivalencyUsing(options => options.Using<double>(ctx => ctx.Subject.Should().BeApproximately(ctx.Expectation, 0.00001)).WhenTypeIs<double>());
  }
}
