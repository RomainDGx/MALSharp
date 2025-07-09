using MALSharp.Client.Manga;
using MALSharp.Models.Manga;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace MALSharp.Client;

public partial class MALClient
{
    public async IAsyncEnumerable<Models.Manga.Manga> SearchMangaAsync(string search,
                                                                       int limit = 100,
                                                                       int offset = 0,
                                                                       bool nsfw = false,
                                                                       MangaListFieldsBuilder? fields = null,
                                                                       [EnumeratorCancellation] CancellationToken token = default)
    {
        var uri = new MALUriBuilder("manga")
            .Add("q", search)
            .AddLimit(limit, 100)
            .AddOffset(offset)
            .AddNsfw(nsfw)
            .AddFields(fields, _options.ExplicitFields)
            .Build();

        await foreach (var manga in ExecuteListRequestAsync<NodePayload<Models.Manga.Manga>>(uri, limit, token))
        {
            yield return manga.Node;
        }
    }

    public Task<Models.Manga.Manga?> GetMangaAsync(int mangaId,
                                                   MangaFieldsBuilder? fields = null,
                                                   CancellationToken token = default)
    {
        try
        {
            var uri = new MALUriBuilder($"manga/{CheckPositive(mangaId, nameof(mangaId))}")
                .AddFields(fields, _options.ExplicitFields)
                .Build();

            return ExecuteRequestAsync<Models.Manga.Manga?>(HttpMethod.Get, uri, token);
        }
        catch (MALClientException e) when (e.StatusCode is System.Net.HttpStatusCode.NotFound)
        {
            return Task.FromResult<Models.Manga.Manga?>(null);
        }
        catch
        {
            throw;
        }
    }

    public IAsyncEnumerable<Ranked<Models.Manga.Manga>> GetMangaRanking(MangaRankingType rankingType,
                                                                        int limit = 100,
                                                                        int offset = 0,
                                                                        bool nsfw = false,
                                                                        MangaListFieldsBuilder? fields = null,
                                                                        CancellationToken token = default)
    {
        var uri = new MALUriBuilder("manga/ranking")
            .Add("ranking_type", rankingType switch
            {
                MangaRankingType.All => "all",
                MangaRankingType.Manga => "manga",
                MangaRankingType.Novels => "novels",
                MangaRankingType.Oneshots => "oneshots",
                MangaRankingType.Doujin => "doujin",
                MangaRankingType.Manhwa => "manhwa",
                MangaRankingType.Manhua => "manhua",
                MangaRankingType.ByPopularity => "bypopularity",
                MangaRankingType.Favorite => "favorite",
                _ => throw new InvalidEnumArgumentException(nameof(rankingType), (int)rankingType, typeof(MangaRankingType))
            })
            .AddLimit(limit, 500)
            .AddOffset(offset)
            .AddNsfw(nsfw)
            .AddFields(fields, _options.ExplicitFields)
            .Build();

        return ExecuteListRequestAsync<Ranked<Models.Manga.Manga>>(uri, limit, token);
    }
}
