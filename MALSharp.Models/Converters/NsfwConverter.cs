using MALSharp.Models.Shared;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MALSharp.Models.Converters;

public class NsfwConverter : JsonConverter<Nsfw>
{
    public override Nsfw Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        ConvertHelper.CheckString(reader);
        return StringToEnum(reader.GetString());
    }

    public override void Write(Utf8JsonWriter writer, Nsfw value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(EnumToString(value));
    }

    public static Nsfw StringToEnum(string? value) => value switch
    {
        "white" => Nsfw.White,
        "gray" => Nsfw.Gray,
        "black" => Nsfw.Black,
        _ => throw new ArgumentException($"Invalid value '{value ?? "null"}' for enum {typeof(Nsfw).Name}.")
    };

    public static string EnumToString(Nsfw value) => value switch
    {
        Nsfw.White => "white",
        Nsfw.Gray => "gray",
        Nsfw.Black => "black",
        _ => throw new ArgumentException($"Invalid value '{value}' for enum {typeof(Nsfw).Name}.")
    };
}
