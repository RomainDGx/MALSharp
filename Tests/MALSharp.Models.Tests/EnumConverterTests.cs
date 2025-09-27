using MALSharp.Models.Anime;
using MALSharp.Models.Converters;
using MALSharp.Models.Manga;
using MALSharp.Models.Shared;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
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
        => InnerTest<AnimeSourceConverter, AnimeSource>(value, result);

    [Test]
    public void AnimeSourceConverter_parsing_error_tests()
        => ErrorInnerTests<AnimeSourceConverter, AnimeSource>();

    [TestCase(AnimeStatus.FinishedAiring, "finished_airing")]
    [TestCase(AnimeStatus.CurrentlyAiring, "currently_airing")]
    [TestCase(AnimeStatus.NotYetAired, "not_yet_aired")]
    public void AnimeStatusConverter_tests(AnimeStatus value, string strValue)
        => InnerTest<AnimeStatusConverter, AnimeStatus>(value, strValue);

    [Test]
    public void AnimeStatusConverter_parsing_error_tests()
        => ErrorInnerTests<AnimeStatusConverter, AnimeStatus>();

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
        => InnerTest<AnimeTypeConverter, AnimeType>(value, strValue);

    [Test]
    public void AnimeTypeConverter_parsing_error_tests()
        => ErrorInnerTests<AnimeTypeConverter, AnimeType>();

    [TestCase(DayOfTheWeek.Monday, "monday")]
    [TestCase(DayOfTheWeek.Tuesday, "tuesday")]
    [TestCase(DayOfTheWeek.Wednesday, "wednesday")]
    [TestCase(DayOfTheWeek.Thursday, "thursday")]
    [TestCase(DayOfTheWeek.Friday, "friday")]
    [TestCase(DayOfTheWeek.Saturday, "saturday")]
    [TestCase(DayOfTheWeek.Sunday, "sunday")]
    [TestCase(DayOfTheWeek.Other, "other")]
    public void DayOfTheWeekConverter_tests(DayOfTheWeek value, string strValue)
        => InnerTest<DayOfTheWeekConverter, DayOfTheWeek>(value, strValue);

    [Test]
    public void DayOfTheWeekConverter_parsing_error_tests()
        => ErrorInnerTests<DayOfTheWeekConverter, DayOfTheWeek>();

    [TestCase(MangaStatus.Finished, "finished")]
    [TestCase(MangaStatus.CurrentlyPublishing, "currently_publishing")]
    [TestCase(MangaStatus.NotYetPublished, "not_yet_published")]
    public void MangaStatusConverter_tests(MangaStatus value, string strValue)
        => InnerTest<MangaStatusConverter, MangaStatus>(value, strValue);

    [Test]
    public void MangaStatusConverter_parsing_error_tests()
        => ErrorInnerTests<MangaStatusConverter, MangaStatus>();

    [TestCase(MangaType.Unknown, "unknown")]
    [TestCase(MangaType.Manga, "manga")]
    [TestCase(MangaType.Novel, "novel")]
    [TestCase(MangaType.OneShot, "one_shot")]
    [TestCase(MangaType.Doujinshi, "doujinshi")]
    [TestCase(MangaType.Manhwa, "manhwa")]
    [TestCase(MangaType.Manhua, "manhua")]
    [TestCase(MangaType.Oel, "oel")]
    [TestCase(MangaType.LightNovel, "light_novel")]
    public void MangaTypeConverter_tests(MangaType value, string strValue)
        => InnerTest<MangaTypeConverter, MangaType>(value, strValue);

    [Test]
    public void MangaTypeConverter_parsing_error_tests()
        => ErrorInnerTests<MangaTypeConverter, MangaType>();

    [TestCase(Nsfw.White, "white")]
    [TestCase(Nsfw.Gray, "gray")]
    [TestCase(Nsfw.Black, "black")]
    public void NsfwConverter_tests(Nsfw value, string strValue)
        => InnerTest<NsfwConverter, Nsfw>(value, strValue);

    [Test]
    public void NsfwConverter_parsing_error_tests()
        => ErrorInnerTests<NsfwConverter, Nsfw>();

    [TestCase(Rating.G, "g")]
    [TestCase(Rating.Pg, "pg")]
    [TestCase(Rating.Pg13, "pg_13")]
    [TestCase(Rating.R, "r")]
    [TestCase(Rating.RPlus, "r+")]
    [TestCase(Rating.Rx, "rx")]
    public void RatingConverter_tests(Rating value, string strValue)
        => InnerTest<RatingConverter, Rating>(value, strValue);

    [Test]
    public void RatingConverter_parsing_error_tests()
        => ErrorInnerTests<RatingConverter, Rating>();

    [TestCase(ReadingStatus.Reading, "reading")]
    [TestCase(ReadingStatus.Completed, "completed")]
    [TestCase(ReadingStatus.OnHold, "on_hold")]
    [TestCase(ReadingStatus.Dropped, "dropped")]
    [TestCase(ReadingStatus.PlanToRead, "plan_to_read")]
    public void ReadingStatusConverter_tests(ReadingStatus value, string strValue)
        => InnerTest<ReadingStatusConverter, ReadingStatus>(value, strValue);

    [Test]
    public void ReadingStatusConverter_parsing_error_tests()
        => ErrorInnerTests<ReadingStatusConverter, ReadingStatus>();

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
        => InnerTest<RelationTypeConverter, RelationType>(value, strValue);

    [Test]
    public void RelationTypeConverter_parsing_error_tests()
        => ErrorInnerTests<RelationTypeConverter, RelationType>();

    [TestCase(Role.Main, "Main")]
    [TestCase(Role.Supporting, "Supporting")]
    public void RoleConverter_tests(Role value, string strValue)
    => InnerTest<RoleConverter, Role>(value, strValue);

    [Test]
    public void RoleConverter_parsing_error_tests()
        => ErrorInnerTests<RoleConverter, Role>();

    [TestCase(Season.Winter, "winter")]
    [TestCase(Season.Spring, "spring")]
    [TestCase(Season.Summer, "summer")]
    [TestCase(Season.Fall, "fall")]
    public void SeasonConverter_tests(Season value, string strValue)
        => InnerTest<SeasonConverter, Season>(value, strValue);

    [Test]
    public void SeasonConverter_parsing_error_tests()
        => ErrorInnerTests<SeasonConverter, Season>();

    [TestCase(WatchingStatus.Watching, "watching")]
    [TestCase(WatchingStatus.Completed, "completed")]
    [TestCase(WatchingStatus.OnHold, "on_hold")]
    [TestCase(WatchingStatus.Dropped, "dropped")]
    [TestCase(WatchingStatus.PlanToWatch, "plan_to_watch")]
    public void WatchingStatusConverter_tests(WatchingStatus value, string strValue)
    => InnerTest<WatchingStatusConverter, WatchingStatus>(value, strValue);

    [Test]
    public void WatchingStatusConverter_parsing_error_tests()
        => ErrorInnerTests<WatchingStatusConverter, WatchingStatus>();

    #region Internal test methods
    static void InnerTest<T, U>(U value, string strValue)
        where T : BaseEnumConverter<U>, new()
        where U : struct, Enum
    {
        var formatMethod = typeof(T).GetMethod("Format", BindingFlags.Public | BindingFlags.Static, [typeof(U)]);
        Assert.That(formatMethod, Is.Not.Null);
        Assert.That(formatMethod!.Invoke(null, [value]), Is.EqualTo(strValue));

        var parseMethod = typeof(T).GetMethod("Parse", BindingFlags.Public | BindingFlags.Static, [typeof(string)]);
        Assert.That(parseMethod, Is.Not.Null);
        Assert.That(parseMethod!.Invoke(null, [strValue]), Is.EqualTo(value));

        ShouldWorkWithUtf8JsonReaderAndWriter(new T(), value);
        ShouldWorkWithJsonSerializer(new T(), value);
    }

    static void ShouldWorkWithUtf8JsonReaderAndWriter<T>(BaseEnumConverter<T> converter, T value) where T : struct, Enum
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

    static void ErrorInnerTests<T, U>()
        where T : BaseEnumConverter<U>, new()
        where U : struct, Enum
    {
        static U GetInvalidEnumValue()
        {
            var values = Enum.GetValues(typeof(U)).Cast<int>().ToHashSet();
            int candidate = -1;
            while (values.Contains(candidate))
            {
                candidate--;
            }
            return (U)Enum.ToObject(typeof(U), candidate);
        }

        CheckExcetion(() =>
        {
            var formatMethod = typeof(T).GetMethod("Format", BindingFlags.Public | BindingFlags.Static, [typeof(U)]);
            Assert.That(formatMethod, Is.Not.Null);
            formatMethod!.Invoke(null, [GetInvalidEnumValue()]);
        });

        var parseMethod = typeof(T).GetMethod("Parse", BindingFlags.Public | BindingFlags.Static, [typeof(string)]);
        Assert.That(parseMethod, Is.Not.Null);
        CheckExcetion(() => parseMethod!.Invoke(null, [null]));
        CheckExcetion(() => parseMethod!.Invoke(null, [""]));
    }

    static void CheckExcetion(Action action)
    {
        try
        {
            action();
        }
        catch (Exception e)
        {
            Assert.That(e, Is.AssignableTo<TargetInvocationException>());
            Assert.That(e.InnerException, Is.Not.Null.And.AssignableTo<JsonException>());
            return;
        }
        Assert.Fail("No error throws");
    }
    #endregion
}
