using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MALSharp.Models.Converters;

public abstract class BaseEnumConverter<T> : JsonConverter<T> where T : struct, Enum
{
    protected abstract T ParseCore(string? value);

    protected abstract string FormatCore(T value);

    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        ConvertHelper.CheckString(reader);
        return ParseCore(reader.GetString());
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(FormatCore(value));
    }
}
