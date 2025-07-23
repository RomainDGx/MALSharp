using MALSharp.Models.Anime;
using MALSharp.Models.Manga;
using MALSharp.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MALSharp.Client.TestUtils;

public static partial class Generator
{
    public static MALClientOptions GenerateMALClientOptions() => new() { ClientId = GetGuid() };

    public static Models.Anime.Anime GenerateAnime(bool detailed = false)
    {
        var random = new Random();
        var anime = new Models.Anime.Anime
        {
            Id = random.Next(),
            Title = GetGuid(),
            MainPicture = GeneratePicture(),
            AlternativeTitles = GenerateAlternativeTitle(),
            StartDate = GenerateMALDate(),
            EndDate = GenerateMALDate(),
            Synopsis = GetGuid(),
            Mean = random.Next(1000) / 100f,
            Rank = random.Next(),
            Popularity = random.Next(),
            NumListUsers = random.Next(),
            Nsfw = GenerateEnumValue<Nsfw>(random),
            Genres = GenerateGenres(random),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            AnimeType = GenerateEnumValue<AnimeType>(random),
            Status = GenerateEnumValue<AnimeStatus>(random),
            MyListStatus = GenerateAnimeListStatus(random),
            NumEpisodes = random.Next(),
            StartSeason = GenerateAnimeSeason(random),
            Broadcast = GenerateBroadcast(random),
            Source = GenerateEnumValue<AnimeSource>(random),
            AverageEpisodeDuration = TimeSpan.FromSeconds(random.Next(30 * 60)),
            Rating = GenerateEnumValue<Rating>(random),
            Studios = GenerateStudios(random),
        };
        if (detailed)
        {
            anime.Pictures = GenerateList(GeneratePicture);
            anime.Background = GetGuid();
            anime.RelatedAnime = GenerateList(() => new Relation<Models.Anime.Anime>
            {
                Node = GenerateAnime(),
                RelationType = GenerateEnumValue<RelationType>(random),
                RelationTypeFormatted = GetGuid()
            });
            anime.RelatedManga = GenerateList(() => new Relation<Models.Manga.Manga>
            {
                Node = GenerateManga(),
                RelationType = GenerateEnumValue<RelationType>(random),
                RelationTypeFormatted = GetGuid()
            });
            anime.Recommendations = GenerateList(value => new Recommendation<Models.Anime.Anime>
            {
                Node = GenerateAnime(),
                NumRecommendations = value
            });
            anime.Statistics = new AnimeStatistics
            {
                Status = new AnimeStatisticsStatus
                {
                    Watching = random.Next(),
                    Completed = random.Next(),
                    On_hold = random.Next(),
                    Dropped = random.Next(),
                    PlanToWatch = random.Next()
                },
                NumListUsers = random.Next()
            };
            anime.Videos = GenerateList(() => new Video
            {
                Id = random.Next(),
                Title = GetGuid(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Thumbnail = new Uri(GetGuid(), UriKind.Relative),
                Url = new Uri(GetGuid(), UriKind.Relative)
            });
        }
        return anime;
    }

    public static Models.Manga.Manga GenerateManga(bool detailed = false)
    {
        var random = new Random();
        var manga = new Models.Manga.Manga
        {
            Id = random.Next(),
            Title = GetGuid(),
            MainPicture = GeneratePicture(),
            AlternativeTitles = GenerateAlternativeTitle(),
            StartDate = new MALDate(DateTime.UtcNow),
            EndDate = new MALDate(DateTime.UtcNow),
            Synopsis = GetGuid(),
            Mean = random.Next(1000) / 100f,
            Rank = random.Next(),
            Popularity = random.Next(),
            NumListUsers = random.Next(),
            NumScoringUsers = random.Next(),
            Nsfw = GenerateEnumValue<Nsfw>(random),
            Genres = GenerateGenres(random),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            MangaType = GenerateEnumValue<MangaType>(random),
            Status = GenerateEnumValue<MangaStatus>(random),
            MyListStatus = GenerateMangaListStatus(random),
            NumVolumes = random.Next(),
            NumChapters = random.Next(),
            Authors = GenerateList(() => new AuthorRole
            {
                Author = new Author
                {
                    Id = random.Next(),
                    FirstName = GetGuid(),
                    LastName = GetGuid()
                },
                Role = GetGuid()
            })
        };
        if (detailed)
        {
            manga.Pictures = GenerateList(GeneratePicture);
            manga.Background = GetGuid();
            manga.RelatedAnime = GenerateList(() => new Relation<Models.Anime.Anime>
            {
                Node = GenerateAnime(),
                RelationType = GenerateEnumValue<RelationType>(random),
                RelationTypeFormatted = GetGuid()
            });
            manga.RelatedManga = GenerateList(() => new Relation<Models.Manga.Manga>
            {
                Node = GenerateManga(),
                RelationType = GenerateEnumValue<RelationType>(random),
                RelationTypeFormatted = GetGuid()
            });
            manga.Recommendations = GenerateList(value => new Recommendation<Models.Manga.Manga>
            {
                Node = GenerateManga(),
                NumRecommendations = value
            });
            manga.Serialization = GenerateList(() => new SerializationItem
            {
                Magazine = new Magazine
                {
                    Id = random.Next(),
                    Name = GetGuid()
                },
                Role = GetGuid()
            });
        }
        return manga;
    }

    public static List<T> GenerateList<T>(Func<T> generate, int count = 5)
        => Enumerable.Range(1, count).Select(_ => generate()).ToList();

    public static List<T> GenerateList<T>(Func<int, T> generate, int count = 5)
        => Enumerable.Range(1, count).Select(generate).ToList();

    #region Private generators
    static string GetGuid() => Guid.NewGuid().ToString();

    static Picture GeneratePicture() => new()
    {
        Medium = new Uri(GetGuid(), UriKind.Relative),
        Large = new Uri(GetGuid(), UriKind.Relative)
    };

    static AlternativeTitles GenerateAlternativeTitle() => new()
    {
        English = GetGuid(),
        Japan = GetGuid(),
        Synonyms = GenerateList(GetGuid)
    };

    static MALDate GenerateMALDate() => new(DateTime.UtcNow);

    static bool GetRadomBoolean(Random random) => random.Next(1) is 1;

    static List<Genre> GenerateGenres(Random random) => GenerateList(() => new Genre
    {
        Id = random.Next(),
        Name = GetGuid()
    });

    static AnimeListStatus GenerateAnimeListStatus(Random random, bool detailed = true)
    {
        var status = new AnimeListStatus
        {
            Status = GenerateEnumValue<WatchingStatus>(random),
            Score = random.Next(),
            NumEpisodesWatched = random.Next(),
            IsRewatching = GetRadomBoolean(random),
            UpdatedAt = DateTime.UtcNow
        };
        if (detailed)
        {
            status.StartDate = GenerateMALDate();
            status.FinishDate = GenerateMALDate();
            status.Priority = random.Next(3);
            status.NumTimesRewatched = random.Next();
            status.RewatchValue = random.Next();
            status.Tags = GenerateList(GetGuid);
            status.Comments = GetGuid();
        }
        return status;
    }

    static MangaListStatus GenerateMangaListStatus(Random random, bool detailed = true)
    {
        var status = new MangaListStatus
        {
            Status = GenerateEnumValue<ReadingStatus>(random),
            Score = random.Next(),
            NumVolumesRead = random.Next(),
            NumChaptersRead = random.Next(),
            IsRereading = GetRadomBoolean(random),
            UpdatedAt = DateTime.UtcNow
        };
        if (detailed)
        {
            status.StartDate = GenerateMALDate();
            status.FinishDate = GenerateMALDate();
            status.Priority = random.Next(2);
            status.NumTimesReread = random.Next();
            status.RereadValue = random.Next();
            status.Tags = GenerateList(GetGuid);
            status.Comments = GetGuid();
        }
        return status;
    }

    static AnimeSeason GenerateAnimeSeason(Random random) => new()
    {
        Season = GenerateEnumValue<Season>(random),
        Year = random.Next()
    };

    static Broadcast GenerateBroadcast(Random random) => new()
    {
        DayOfTheWeek = GenerateEnumValue<DayOfTheWeek>(random),
        StartTime = TimeOnly.FromDateTime(DateTime.UtcNow)
    };

    static List<Studio> GenerateStudios(Random random) => GenerateList(() => new Studio
    {
        Id = random.Next(),
        Name = GetGuid()
    });

    static T GenerateEnumValue<T>(Random random) where T : struct, Enum
    {
        var values = Enum.GetValues<T>();
        return values[random.Next(values.Length - 1)];
    }
    #endregion
}
