using MALSharp.Models.Converters;
using MALSharp.Models.Shared;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace MALSharp.Models.Tests;

[TestFixture]
public class EnumConverterTests
{
    [TestCase(Nsfw.White, "white")]
    [TestCase(Nsfw.Gray, "gray")]
    [TestCase(Nsfw.Black, "black")]
    public void NsfwConverter_tests(Nsfw value, string strValue)
        => InnerTest(new NsfwConverter(), value, strValue);

    [Test]
    public void NsfwConverter_parsing_error_tests()
        => ErrorInnerTests(new NsfwConverter());

    [TestCase(RelationType.Sequel, "sequel")]
    [TestCase(RelationType.Prequel, "prequel")]
    [TestCase(RelationType.AlternativeSetting, "alternative_setting")]
    [TestCase(RelationType.AlternativeVersion, "alternative_version")]
    [TestCase(RelationType.SideStory, "side_story")]
    [TestCase(RelationType.ParentStory, "parent_story")]
    [TestCase(RelationType.Summary, "summary")]
    [TestCase(RelationType.FullStory, "full_story")]
    [TestCase(RelationType.SpinOff, "spin_off")]
    [TestCase(RelationType.Character, "character")]
    [TestCase(RelationType.Other, "other")]
    public void RelationTypeConverter_tests(RelationType value, string strValue)
        => InnerTest(new RelationTypeConverter(), value, strValue);

    [Test]
    public void RelationTypeConverter_parsing_error_tests()
        => ErrorInnerTests(new RelationTypeConverter());

    static void InnerTest<T>(BaseEnumConverter<T> converter, T value, string strValue) where T : struct, Enum
    {
        Assert.That(converter.EnumToString(value), Is.EqualTo(strValue));
        Assert.That(converter.StringToEnum(strValue), Is.EqualTo(value));
        ShouldWorkWithUtf8JsonReaderAndWriter(converter, value);
        ShouldWorkWithJsonSerializer(converter, value);
    }

    static void ShouldWorkWithUtf8JsonReaderAndWriter<T>(BaseEnumConverter<T> converter, T value) where T: struct, Enum
    {
        var options = new JsonSerializerOptions();
        using var stream = new MemoryStream();
        using (var writer = new Utf8JsonWriter(stream))
        {
            converter.Write(writer, value, options);
            writer.Flush();
        }
        var reader = new Utf8JsonReader(stream.ToArray());
        Assert.That(reader.Read(), Is.True);
        Assert.That(reader.TokenType, Is.EqualTo(JsonTokenType.String));
        Assert.That(converter.Read(ref reader, typeof(T), options), Is.EqualTo(value));
    }

    static void ShouldWorkWithJsonSerializer<T>(BaseEnumConverter<T> converter, T value) where T : struct, Enum
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(converter);
        var json = JsonSerializer.Serialize(value, options);
        var deserialized = JsonSerializer.Deserialize<T>(json, options);
        Assert.That(deserialized, Is.EqualTo(value));
    }

    static void ErrorInnerTests<T>(BaseEnumConverter<T> converter) where T : struct, Enum
    {
        static T GetInvalidEnumValue()
        {
            var values = Enum.GetValues(typeof(T)).Cast<int>().ToHashSet();
            int candidate = -1;
            while (values.Contains(candidate))
            {
                candidate--;
            }
            return (T)Enum.ToObject(typeof(T), candidate);
        }

        Assert.Throws<JsonException>(() => converter.EnumToString(GetInvalidEnumValue()));
        Assert.Throws<JsonException>(() => converter.StringToEnum(null));
        Assert.Throws<JsonException>(() => converter.StringToEnum(""));
    }
}
