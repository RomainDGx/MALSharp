using MALSharp.Models.Anime;
using System.Text.Json;

namespace MALSharp.Models.Converters;

public class RoleConverter : BaseEnumConverter<Role, RoleConverter>, IEnumConverter<Role>
{
    public static Role Parse(string? value) => value switch
    {
        "Main" => Role.Main,
        "Supporting" => Role.Supporting,
        _ => throw new JsonException($"Invalid value '{value ?? "null"}' for enum {typeof(Role).Name}.")
    };

    public static string Format(Role value) => value switch
    {
        Role.Main => "Main",
        Role.Supporting => "Supporting",
        _ => throw new JsonException($"Invalid value '{value}' for enum {typeof(Role).Name}.")
    };
}
