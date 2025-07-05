using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MALSharp.Models.Converters;

public abstract class BaseEnumConverter<T> : JsonConverter<T> where T : struct, Enum
{
    public abstract string EnumToString(T value);

    public abstract T StringToEnum(string? value);

    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        ConvertHelper.CheckString(reader);
        return StringToEnum(reader.GetString());
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(EnumToString(value));
    }
}
