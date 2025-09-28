using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MALSharp.Models.Converters;

public abstract class BaseEnumConverter<T, TConverter> : JsonConverter<T>
    where T : struct, Enum
    where TConverter : IEnumConverter<T>
{
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        ConvertHelper.CheckString(reader);
        return TConverter.Parse(reader.GetString());
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(TConverter.Format(value));
    }
}
