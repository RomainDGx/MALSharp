using MALSharp.Models.Anime;
using System.Text.Json;

namespace MALSharp.Models.Converters;

public class RatingConverter : BaseEnumConverter<Rating>
{
    public override Rating StringToEnum(string? value) => value switch
    {
        "g" => Rating.G,
        "pg" => Rating.Pg,
        "pg_13" => Rating.Pg13,
        "r" => Rating.R,
        "r+" => Rating.RPlus,
        "rx" => Rating.Rx,
        _ => throw new JsonException($"Invalid value '{value ?? "null"}' for enum {typeof(Rating).Name}.")
    };

    public override string EnumToString(Rating value) => value switch
    {
        Rating.G => "g",
        Rating.Pg => "pg",
        Rating.Pg13 => "pg_13",
        Rating.R => "r",
        Rating.RPlus => "r+",
        Rating.Rx => "rx",
        _ => throw new JsonException($"Invalid value '{value}' for enum {typeof(Rating).Name}.")
    };
}
