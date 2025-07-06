using MALSharp.Models.Anime;
using System.Text.Json;

namespace MALSharp.Models.Converters;

public class RoleConverter : BaseEnumConverter<Role>
{
    public override Role StringToEnum(string? value) => value switch
    {
        "Main" => Role.Main,
        "Supporting" => Role.Supporting,
        _ => throw new JsonException($"Invalid value '{value ?? "null"}' for enum {typeof(Role).Name}.")
    };

    public override string EnumToString(Role value) => value switch
    {
        Role.Main => "Main",
        Role.Supporting => "Supporting",
        _ => throw new JsonException($"Invalid value '{value}' for enum {typeof(Role).Name}.")
    };
}
