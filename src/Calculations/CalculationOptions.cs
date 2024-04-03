using Pcote.OsrsDpsCalc.Entities;

namespace Pcote.OsrsDpsCalc.Calculations;

public class CalculationOptions
{
  public Player Player { get; set; } = new Player();
  public Monster Monster { get; set; } = new Monster();
}
