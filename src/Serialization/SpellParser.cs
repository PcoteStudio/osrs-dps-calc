using System.Text.Json;
using Pcote.OsrsDpsCalc.Contracts;
using Pcote.OsrsDpsCalc.Entities;
using Pcote.OsrsDpsCalc.Enums;

namespace Pcote.OsrsDpsCalc.Serialization;

public static class SpellParser
{
  private static readonly JsonSerializerOptions _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters = { new ForgivingStringConverter() } };
  public static Spell[] Parse(string json)
  {
    SpellResponse[] response = JsonSerializer.Deserialize<SpellResponse[]>(json, _options) ?? [];
    List<Spell> spells = [];
    foreach (SpellResponse m in response)
      spells.Add(MapSpellResponseToSpell(m));
    return [.. spells];
  }

  public static Spell[] ParseFile(string filePath)
  {
    return Parse(File.ReadAllText(filePath));
  }

  public static Spell MapSpellResponseToSpell(SpellResponse spellResponse)
  {
    Spell spell = new Spell()
    {
      Name = spellResponse.Name,
      Image = spellResponse.Image,
      MaxHit = spellResponse.MaxHit,
      Spellbook = (Spellbook)Enum.Parse(typeof(Spellbook), spellResponse.Spellbook, true)
    };
    return spell;
  }
}