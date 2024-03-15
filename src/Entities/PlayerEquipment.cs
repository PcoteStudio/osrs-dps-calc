namespace Pcote.OsrsDpsCalc.Entities;

public class PlayerEquipment : EquipmentStats
{
  private List<EquipmentPiece> _pieces = [];
  List<EquipmentPiece> GetPieces { get => _pieces; }

  private EquipmentPiece? _head;
  public EquipmentPiece? Head
  {
    get => _head;
    set => _head = SwapPiece(_head, value);
  }

  private EquipmentPiece? _cape;
  public EquipmentPiece? Cape
  {
    get => _cape;
    set => _cape = SwapPiece(_cape, value);
  }

  private EquipmentPiece? _neck;
  public EquipmentPiece? Neck
  {
    get => _neck;
    set => _neck = SwapPiece(_neck, value);
  }

  private EquipmentPiece? _ammo;
  public EquipmentPiece? Ammo
  {
    get => _ammo;
    set => _ammo = SwapPiece(_ammo, value);
  }

  private EquipmentPiece? _weapon;
  public EquipmentPiece? Weapon
  {
    get => _weapon;
    set => _weapon = SwapPiece(_weapon, value);
  }

  private EquipmentPiece? _body;
  public EquipmentPiece? Body
  {
    get => _body;
    set => _body = SwapPiece(_body, value);
  }

  private EquipmentPiece? _shield;
  public EquipmentPiece? Shield
  {
    get => _shield;
    set => _shield = SwapPiece(_shield, value);
  }

  private EquipmentPiece? _legs;
  public EquipmentPiece? Legs
  {
    get => _legs;
    set => _legs = SwapPiece(_legs, value);
  }

  private EquipmentPiece? _hands;
  public EquipmentPiece? Hands
  {
    get => _hands;
    set => _hands = SwapPiece(_hands, value);
  }

  private EquipmentPiece? _feet;
  public EquipmentPiece? Feet
  {
    get => _feet;
    set => _feet = SwapPiece(_feet, value);
  }

  private EquipmentPiece? ring;
  public EquipmentPiece? Ring
  {
    get => ring;
    set => ring = SwapPiece(ring, value);
  }

  private EquipmentPiece? SwapPiece(EquipmentPiece? oldValue, EquipmentPiece? newValue)
  {
    // TODO Remove set effect
    if (oldValue != null)
    {
      _pieces.Remove(oldValue);
      Bonuses -= oldValue.Bonuses;
      Offensive -= oldValue.Offensive;
      Defensive -= oldValue.Defensive;
    }
    if (newValue != null)
    {
      _pieces.Add(newValue);
      Bonuses += newValue.Bonuses;
      Offensive += newValue.Offensive;
      Defensive += newValue.Defensive;
    }
    // TODO Apply set effect
    return newValue;
  }
}
