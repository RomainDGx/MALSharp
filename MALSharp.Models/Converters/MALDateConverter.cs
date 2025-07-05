using MALSharp.Models.Shared;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MALSharp.Models.Converters;

public class MALDateConverter : JsonConverter<MALDate>
{
    public override MALDate Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        ConvertHelper.CheckString(reader);
        var strDate = reader.GetString();
        if (MALDate.TryParse(strDate, out var date))
        {
            return date;
        }
        throw new JsonException($"Invalid value '{strDate ?? "null"}' for {typeof(MALDate).Name}.");
    }

    public override void Write(Utf8JsonWriter writer, MALDate value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}
