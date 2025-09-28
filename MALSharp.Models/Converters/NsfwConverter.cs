using MALSharp.Models.Shared;
using System.Text.Json;

namespace MALSharp.Models.Converters;

public class NsfwConverter : BaseEnumConverter<Nsfw, NsfwConverter>, IEnumConverter<Nsfw>
{
    public static Nsfw Parse(string? value) => value switch
    {
        "white" => Nsfw.White,
        "gray" => Nsfw.Gray,
        "black" => Nsfw.Black,
        _ => throw new JsonException($"Invalid value '{value ?? "null"}' for enum {typeof(Nsfw).Name}.")
    };

    public static string Format(Nsfw value) => value switch
    {
        Nsfw.White => "white",
        Nsfw.Gray => "gray",
        Nsfw.Black => "black",
        _ => throw new JsonException($"Invalid value '{value}' for enum {typeof(Nsfw).Name}.")
    };
}
