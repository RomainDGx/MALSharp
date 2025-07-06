using MALSharp.Models.Anime;
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
    [TestCase(AnimeSource.Other, "other")]
    [TestCase(AnimeSource.Original, "original")]
    [TestCase(AnimeSource.Manga, "manga")]
    [TestCase(AnimeSource.FourKomaManga, "4_koma_manga")]
    [TestCase(AnimeSource.WebManga, "web_manga")]
    [TestCase(AnimeSource.DigitalManga, "digital_manga")]
    [TestCase(AnimeSource.Novel, "novel")]
    [TestCase(AnimeSource.LightNovel, "light_novel")]
    [TestCase(AnimeSource.VisualNovel, "visual_novel")]
    [TestCase(AnimeSource.Game, "game")]
    [TestCase(AnimeSource.CardGame, "card_game")]
    [TestCase(AnimeSource.Book, "book")]
    [TestCase(AnimeSource.PictureBook, "picture_book")]
    [TestCase(AnimeSource.Radio, "radio")]
    [TestCase(AnimeSource.Music, "music")]
    [TestCase(AnimeSource.MixedMedia, "mixed_media")]
    public void AnimeSourceConverter_tests(AnimeSource value, string result)
        => InnerTest(new AnimeSourceConverter(), value, result);

    [Test]
    public void AnimeSourceConverter_parsing_error_tests()
        => ErrorInnerTests(new AnimeSourceConverter());

    [TestCase(AnimeStatus.FinishedAiring, "finished_airing")]
    [TestCase(AnimeStatus.CurrentlyAiring, "currently_airing")]
    [TestCase(AnimeStatus.NotYetAired, "not_yet_aired")]
    public void AnimeStatusConverter_tests(AnimeStatus value, string strValue)
        => InnerTest(new AnimeStatusConverter(), value, strValue);

    [Test]
    public void AnimeStatusConverter_parsing_error_tests()
        => ErrorInnerTests(new AnimeStatusConverter());

    [TestCase(AnimeType.Unknown, "unknown")]
    [TestCase(AnimeType.Tv, "tv")]
    [TestCase(AnimeType.Ova, "ova")]
    [TestCase(AnimeType.Movie, "movie")]
    [TestCase(AnimeType.Special, "special")]
    [TestCase(AnimeType.Ona, "ona")]
    [TestCase(AnimeType.Music, "music")]
    [TestCase(AnimeType.Pv, "pv")]
    [TestCase(AnimeType.Cm, "cm")]
    [TestCase(AnimeType.TvSpecial, "tv_special")]
    public void AnimeTypeConverter_tests(AnimeType value, string strValue)
        => InnerTest(new AnimeTypeConverter(), value, strValue);

    [Test]
    public void AnimeTypeConverter_parsing_error_tests()
        => ErrorInnerTests(new AnimeTypeConverter());

    [TestCase(DayOfTheWeek.Monday, "monday")]
    [TestCase(DayOfTheWeek.Tuesday, "tuesday")]
    [TestCase(DayOfTheWeek.Wednesday, "wednesday")]
    [TestCase(DayOfTheWeek.Thursday, "thursday")]
    [TestCase(DayOfTheWeek.Friday, "friday")]
    [TestCase(DayOfTheWeek.Saturday, "saturday")]
    [TestCase(DayOfTheWeek.Sunday, "sunday")]
    [TestCase(DayOfTheWeek.Other, "other")]
    public void DayOfTheWeekConverter_tests(DayOfTheWeek value, string strValue)
        => InnerTest(new DayOfTheWeekConverter(), value, strValue);

    [Test]
    public void DayOfTheWeekConverter_parsing_error_tests()
        => ErrorInnerTests(new DayOfTheWeekConverter());

    [TestCase(Nsfw.White, "white")]
    [TestCase(Nsfw.Gray, "gray")]
    [TestCase(Nsfw.Black, "black")]
    public void NsfwConverter_tests(Nsfw value, string strValue)
        => InnerTest(new NsfwConverter(), value, strValue);

    [Test]
    public void NsfwConverter_parsing_error_tests()
        => ErrorInnerTests(new NsfwConverter());

    [TestCase(Rating.G, "g")]
    [TestCase(Rating.Pg, "pg")]
    [TestCase(Rating.Pg13, "pg_13")]
    [TestCase(Rating.R, "r")]
    [TestCase(Rating.RPlus, "r+")]
    [TestCase(Rating.Rx, "rx")]
    public void RatingConverter_tests(Rating value, string strValue)
        => InnerTest(new RatingConverter(), value, strValue);

    [Test]
    public void RatingConverter_parsing_error_tests()
        => ErrorInnerTests(new RatingConverter());

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

    [TestCase(Role.Main, "Main")]
    [TestCase(Role.Supporting, "Supporting")]
    public void RoleConverter_tests(Role value, string strValue)
    => InnerTest(new RoleConverter(), value, strValue);

    [Test]
    public void RoleConverter_parsing_error_tests()
        => ErrorInnerTests(new RoleConverter());

    [TestCase(Season.Winter, "winter")]
    [TestCase(Season.Spring, "spring")]
    [TestCase(Season.Summer, "summer")]
    [TestCase(Season.Fall, "fall")]
    public void SeasonConverter_tests(Season value, string strValue)
        => InnerTest(new SeasonConverter(), value, strValue);

    [Test]
    public void SeasonConverter_parsing_error_tests()
        => ErrorInnerTests(new SeasonConverter());

    [TestCase(WatchingStatus.Watching, "watching")]
    [TestCase(WatchingStatus.Completed, "completed")]
    [TestCase(WatchingStatus.OnHold, "on_hold")]
    [TestCase(WatchingStatus.Dropped, "dropped")]
    [TestCase(WatchingStatus.PlanToWatch, "plan_to_watch")]
    public void WatchingStatusConverter_tests(WatchingStatus value, string strValue)
    => InnerTest(new WatchingStatusConverter(), value, strValue);

    [Test]
    public void WatchingStatusConverter_parsing_error_tests()
        => ErrorInnerTests(new WatchingStatusConverter());

    #region Internal test methods
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
    #endregion
}
