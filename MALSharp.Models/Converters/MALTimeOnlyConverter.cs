using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MALSharp.Models.Converters;

/// <summary>
/// Converts time in HH:mm format to a <see cref="TimeOnly"/>.
/// </summary>
public class MALTimeOnlyConverter : JsonConverter<TimeOnly>
{
    public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        ConvertHelper.CheckString(reader);
        return TimeOnly.Parse(reader.GetString()!);
    }

    public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("HH:mm"));
    }
}
