using System.Buffers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Pcote.OsrsDpsCalc.Serialization;

public sealed class ForgivingStringConverter : JsonConverter<string>
{
  public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    return reader.TokenType switch
    {
      JsonTokenType.False => "false",
      JsonTokenType.True => "true",
      JsonTokenType.Number => Encoding.UTF8.GetString(reader.HasValueSequence ? reader.ValueSequence.ToArray() : reader.ValueSpan),
      _ => reader.GetString(),
    };
  }

  public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
  {
    writer.WriteStringValue(value);
  }
}
