using MALSharp.Models.Anime;
using MALSharp.Models.Shared;
using NUnit.Framework;
using System;

namespace MALSharp.Client.TestUtils;

public static partial class Generator
{
    public static Models.Anime.Anime GenerateAnimeByFields(ReadOnlySpan<char> fields, bool hasAccessToken)
    {
        var random = new Random();
        var reader = new FieldsReader(fields);
        return GenerateAnime(ref reader, random);
    }

    static Models.Anime.Anime GenerateAnime(ref FieldsReader reader, Random random)
    {
        var anime = new Models.Anime.Anime
        {
            Id = random.Next(),
            Title = GetGuid(),
            MainPicture = GeneratePicture()
        };
        var continueRead = reader.Read();
        while (continueRead)
        {
            var canRead = true;
            Assert.That(reader.TokenType is FieldsTokenType.Field);
            switch (reader.Current)
            {
                case "id":
                case "title":
                case "main_picture":
                    break;
                case "alternative_titles":
                    anime.AlternativeTitles = GenerateAlternativeTitle();
                    break;
                case "start_date":
                    anime.StartDate = new MALDate(DateTime.UtcNow);
                    break;
                case "end_date":
                    anime.StartDate = new MALDate(DateTime.UtcNow);
                    break;
                case "synopsis":
                    anime.Synopsis = GetGuid();
                    break;
                case "mean":
                    anime.Mean = random.Next(1000) / 100f;
                    break;
                case "rank":
                    anime.Rank = random.Next();
                    break;
                case "popularity":
                    anime.Popularity = random.Next();
                    break;
                case "num_list_users":
                    anime.NumListUsers = random.Next();
                    break;
                case "num_scoring_users":
                    anime.NumScoringUsers = random.Next();
                    break;
                case "nsfw":
                    anime.Nsfw = GenerateEnumValue<Nsfw>(random);
                    break;
                case "genres":
                    anime.Genres = GenerateGenres(random);
                    break;
                case "created_at":
                    anime.CreatedAt = DateTime.UtcNow;
                    break;
                case "updated_at":
                    anime.UpdatedAt = DateTime.UtcNow;
                    break;
                case "media_type":
                    anime.AnimeType = GenerateEnumValue<AnimeType>(random);
                    break;
                case "status":
                    anime.Status = GenerateEnumValue<AnimeStatus>(random);
                    break;
                case "my_list_status":
                    if (continueRead = reader.Read() && reader.TokenType is FieldsTokenType.OpenBracket)
                    {
                        anime.MyListStatus = GenerateMyListStatus(ref reader, random);
                    }
                    else
                    {
                        anime.MyListStatus = GenerateAnimeListStatus(random, false);
                    }
                    canRead = false;
                    break;
                case "num_episodes":
                    anime.NumEpisodes = random.Next();
                    break;
                case "start_season":
                    anime.StartSeason = GenerateAnimeSeason(random);
                    break;
                case "broadcast":
                    anime.Broadcast = GenerateBroadcast(random);
                    break;
                case "source":
                    anime.Source = GenerateEnumValue<AnimeSource>(random);
                    break;
                case "average_episode_duration":
                    anime.AverageEpisodeDuration = TimeSpan.FromSeconds(random.NextDouble());
                    break;
                case "rating":
                    anime.Rating = GenerateEnumValue<Rating>(random);
                    break;
                case "studios":
                    anime.Studios = GenerateStudios(random);
                    break;
                case "related_anime":
                    if (continueRead = reader.Read() && reader.TokenType is FieldsTokenType.OpenBracket)
                    {
                        anime.RelatedAnime = [];
                        for (int i = 0; i < 5; i++)
                        {
                            anime.RelatedAnime.Add(new Relation<Models.Anime.Anime>
                            {
                                Node = GenerateAnime(ref reader, random),
                                RelationType = GenerateEnumValue<RelationType>(random),
                                RelationTypeFormatted = GetGuid()
                            });
                        }
                    }
                    else
                    {
                        anime.RelatedAnime = GenerateList(() => new Relation<Models.Anime.Anime>
                        {
                            Node = GenerateAnime(false),
                            RelationType = GenerateEnumValue<RelationType>(random),
                            RelationTypeFormatted = GetGuid()
                        });
                    }
                    canRead = false;
                    break;
                case "related_manga":
                    throw new NotImplementedException();
                case "recommendations":
                    if (continueRead = reader.Read() && reader.TokenType is FieldsTokenType.OpenBracket)
                    {
                        anime.Recommendations = [];
                        for (int i = 0; i < 5; i++)
                        {
                            anime.Recommendations.Add(new Recommendation<Models.Anime.Anime>
                            {
                                Node = GenerateAnime(ref reader, random),
                                NumRecommendations = i,
                            });
                        }
                    }
                    else
                    {
                        anime.Recommendations = GenerateList(i => new Recommendation<Models.Anime.Anime>
                        {
                            Node = GenerateAnime(false),
                            NumRecommendations = i,
                        });
                    }
                    canRead = false;
                    break;
                default:
                    throw new InvalidOperationException($"Invalid field '{reader.Current}' for {anime.GetType().Name}.");
            }

            if (canRead)
            {
                continueRead = reader.Read();
            }
        }
        return anime;
    }

    static AnimeListStatus GenerateMyListStatus(ref FieldsReader reader, Random random)
    {
        var status = new AnimeListStatus
        {
            Status = GenerateEnumValue<WatchingStatus>(random),
            Score = random.Next(10),
            NumEpisodesWatched = random.Next(),
            IsRewatching = GetRadomBoolean(random),
            UpdatedAt = DateTime.UtcNow
        };
        while (reader.Read() && reader.TokenType != FieldsTokenType.CloseBracket)
        {
            switch (reader.Current)
            {
                case "status":
                case "score":
                case "num_episodes_watched":
                case "is_rewatching":
                case "updated_at":
                    break;
                case "start_date":
                    status.StartDate = new(DateTime.UtcNow);
                    break;
                case "finish_date":
                    status.StartDate = new(DateTime.UtcNow);
                    break;
                case "priority":
                    status.Priority = random.Next();
                    break;
                case "num_times_rewatched":
                    status.NumTimesRewatched = random.Next();
                    break;
                case "rewatch_value":
                    status.RewatchValue = random.Next();
                    break;
                case "tags":
                    status.Tags = GenerateList(GetGuid);
                    break;
                case "comments":
                    status.Comments = GetGuid();
                    break;
                default:
                    throw new InvalidOperationException($"Invalid field '{reader.Current}' for {status.GetType().Name}.");
            }
        }
        return status;
    }
}
