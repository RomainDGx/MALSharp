using MALSharp.Models.Shared;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MALSharp.Models.Converters;

public class RelationTypeConverter : JsonConverter<RelationType>
{
    public override RelationType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        ConvertHelper.CheckString(reader);
        return StringToEnum(reader.GetString());
    }

    public override void Write(Utf8JsonWriter writer, RelationType value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(EnumToString(value));
    }

    public static RelationType StringToEnum(string? value) => value switch
    {
        "sequel" => RelationType.Sequel,
        "prequel" => RelationType.Prequel,
        "alternative_setting" => RelationType.AlternativeSetting,
        "alternative_version" => RelationType.AlternativeVersion,
        "side_story" => RelationType.SideStory,
        "parent_story" => RelationType.ParentStory,
        "summary" => RelationType.Summary,
        "full_story" => RelationType.FullStory,
        "spin_off" => RelationType.SideStory,
        "character" => RelationType.Character,
        "other" => RelationType.Other,
        _ => throw new JsonException($"Invalid value '{value ?? "null"}' for enum {typeof(RelationType).Name}.")
    };

    public static string EnumToString(RelationType value) => value switch
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
        _ => throw new ArgumentException($"Invalid value '{value}' for enum {typeof(RelationType).Name}.")
    };
}
