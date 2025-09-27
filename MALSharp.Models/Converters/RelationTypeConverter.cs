using MALSharp.Models.Shared;
using System.Text.Json;

namespace MALSharp.Models.Converters;

public class RelationTypeConverter : BaseEnumConverter<RelationType>
{
    public static RelationType Parse(string? value) => value switch
    {
        "sequel" => RelationType.Sequel,
        "prequel" => RelationType.Prequel,
        "alternative_setting" => RelationType.AlternativeSetting,
        "alternative_version" => RelationType.AlternativeVersion,
        "side_story" => RelationType.SideStory,
        "parent_story" => RelationType.ParentStory,
        "summary" => RelationType.Summary,
        "full_story" => RelationType.FullStory,
        "spin_off" => RelationType.SpinOff,
        "character" => RelationType.Character,
        "other" => RelationType.Other,
        _ => throw new JsonException($"Invalid value '{value ?? "null"}' for enum {typeof(RelationType).Name}.")
    };

    public static string Format(RelationType value) => value switch
    {
        RelationType.Sequel => "sequel",
        RelationType.Prequel => "prequel",
        RelationType.AlternativeSetting => "alternative_setting",
        RelationType.AlternativeVersion => "alternative_version",
        RelationType.SideStory => "side_story",
        RelationType.ParentStory => "parent_story",
        RelationType.Summary => "summary",
        RelationType.FullStory => "full_story",
        RelationType.SpinOff => "spin_off",
        RelationType.Character => "character",
        RelationType.Other => "other",
        _ => throw new JsonException($"Invalid value '{value}' for enum {typeof(RelationType).Name}.")
    };

    protected override RelationType ParseCore(string? value) => Parse(value);

    protected override string FormatCore(RelationType value) => Format(value);
}
