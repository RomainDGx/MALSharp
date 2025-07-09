using MALSharp.Client.Anime;
using MALSharp.Models.Anime;
using MALSharp.Models.Converters;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace MALSharp.Client;

public partial class MALClient
{
    public async IAsyncEnumerable<Models.Anime.Anime> SearchAnimeAsync(string search,
                                                                       int limit = 100,
                                                                       int offset = 0,
                                                                       bool nsfw = false,
                                                                       AnimeListFieldsBuilder? fields = null,
                                                                       [EnumeratorCancellation] CancellationToken token = default)
    {
        var uri = new MALUriBuilder("anime")
            .Add("q", search)
            .AddLimit(limit, 100)
            .AddOffset(offset)
            .AddNsfw(nsfw)
            .AddFields(fields, _options.ExplicitFields)
            .Build();

        await foreach (var node in ExecuteListRequestAsync<NodePayload<Models.Anime.Anime>>(uri, limit, token))
        {
            yield return node.Node;
        }
    }

    public Task<Models.Anime.Anime?> GetAnimeAsync(int animeId,
                                                   AnimeFieldsBuilder? fields = null,
                                                   CancellationToken token = default)
    {
        try
        {
            var uri = new MALUriBuilder($"anime/{CheckPositive(animeId, nameof(animeId))}")
                .AddFields(fields, _options.ExplicitFields)
                .Build();

            return ExecuteRequestAsync<Models.Anime.Anime?>(HttpMethod.Get, uri, token);
        }
        catch (MALClientException e) when (e.StatusCode is HttpStatusCode.NotFound)
        {
            return Task.FromResult<Models.Anime.Anime?>(null);
        }
        catch
        {
            throw;
        }
    }

    public IAsyncEnumerable<Ranked<Models.Anime.Anime>> GetAnimeRankingAsync(AnimeRankingType rankingType,
                                                                             int limit = 100,
                                                                             int offset = 0,
                                                                             bool nsfw = false,
                                                                             AnimeListFieldsBuilder? fields = null,
                                                                             CancellationToken token = default)
    {
        var uri = new MALUriBuilder("anime/ranking")
            .AddLimit(limit, 500)
            .AddOffset(offset)
            .AddNsfw(nsfw)
            .AddFields(fields, _options.ExplicitFields)
            .Add("ranking_type", rankingType switch
            {
                AnimeRankingType.All => "all",
                AnimeRankingType.Airing => "airing",
                AnimeRankingType.Upcoming => "upcoming",
                AnimeRankingType.Tv => "tv",
                AnimeRankingType.Ova => "ova",
                AnimeRankingType.Movie => "movie",
                AnimeRankingType.Special => "special",
                AnimeRankingType.ByPopularity => "bypopularity",
                AnimeRankingType.Favorite => "favorite",
                _ => throw new InvalidEnumArgumentException(nameof(rankingType), (int)rankingType, typeof(AnimeRankingType))
            })
            .Build();

        return ExecuteListRequestAsync<Ranked<Models.Anime.Anime>>(uri, limit, token);
    }

    public async IAsyncEnumerable<Models.Anime.Anime> GetSeasonalAnimeAsync(int year,
                                                                            Season season,
                                                                            SeasonalAnimeSort sort,
                                                                            int limit = 100,
                                                                            int offset = 0,
                                                                            bool nsfw = false,
                                                                            AnimeListFieldsBuilder? fields = null,
                                                                            [EnumeratorCancellation] CancellationToken token = default)
    {
        var uri = new MALUriBuilder($"anime/season/{CheckPositive(year, nameof(year))}/{new SeasonConverter().EnumToString(season)}")
            .Add("sort", sort switch
            {
                SeasonalAnimeSort.AnimeScore => "anime_score",
                SeasonalAnimeSort.AnimeNumListUsers => "anime_num_list_users",
                _ => throw new InvalidEnumArgumentException(nameof(SeasonalAnimeSort), (int)sort, typeof(SeasonalAnimeSort))
            })
            .AddLimit(limit, 500)
            .AddOffset(offset)
            .AddNsfw(nsfw)
            .AddFields(fields, _options.ExplicitFields)
            .Build();

        await foreach (var anime in ExecuteListRequestAsync<NodePayload<Models.Anime.Anime>>(uri, limit, token))
        {
            yield return anime.Node;
        }
    }

    public async IAsyncEnumerable<Models.Anime.Anime> GetSuggestedAnimeAsync(int limit = 100,
                                                                             int offset = 0,
                                                                             bool nsfw = false,
                                                                             AnimeListFieldsBuilder? fields = null,
                                                                             [EnumeratorCancellation] CancellationToken token = default)
    {
        var uri = new MALUriBuilder("anime/suggestions")
            .AddLimit(limit, 100)
            .AddOffset(offset)
            .AddNsfw(nsfw)
            .AddFields(fields, _options.ExplicitFields)
            .Build();

        await foreach (var anime in ExecuteListRequestAsync<NodePayload<Models.Anime.Anime>>(uri, limit, token))
        {
            yield return anime.Node;
        }
    }

    public IAsyncEnumerable<AnimeCharacter> GetAnimeCharactersAsync(int animeId,
                                                                    int limit = 100,
                                                                    int offset = 0,
                                                                    CharacterListFieldsBuilder? fields = null,
                                                                    CancellationToken token = default)
    {
        var uri = new MALUriBuilder($"anime/{CheckPositive(animeId, nameof(animeId))}/characters")
            .AddLimit(limit, 500)
            .AddOffset(offset)
            .AddFields(fields, _options.ExplicitFields)
            .Build();

        return ExecuteListRequestAsync<AnimeCharacter>(uri, limit, token);
    }

    public Task<Character?> GetCharacterAsync(int characterId,
                                             CharacterFieldsBuilder? fields = null,
                                             CancellationToken token = default)
    {
        try
        {
            var uri = new MALUriBuilder($"characters/{CheckPositive(characterId, nameof(characterId))}")
                .AddFields(fields, _options.ExplicitFields)
                .Build();

            return ExecuteRequestAsync<Character?>(HttpMethod.Get, uri, token);
        }
        catch (MALClientException e) when (e.StatusCode is HttpStatusCode.NotFound)
        {
            return Task.FromResult<Character?>(null);
        }
        catch
        {
            throw;
        }
    }
}
