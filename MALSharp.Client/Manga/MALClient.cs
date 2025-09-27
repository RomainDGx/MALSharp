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
        ArgumentNullException.ThrowIfNull(search);
        if (search.Length > 64)
        {
            throw new ArgumentOutOfRangeException(nameof(search), "Search cannot be longer that 64 characters.");
        }

        var uri = new MALUriBuilder("manga")
            .Add("q", search)
            .AddLimit(limit, 100)
            .AddNsfw(nsfw)
            .AddFields(fields, _options.ExplicitFields);

        await foreach (var manga in ExecuteListRequestAsync<NodePayload<Models.Manga.Manga>>(uri, limit, offset, token))
        {
            yield return manga.Node;
        }
    }

    public async Task<Models.Manga.Manga?> GetMangaAsync(int mangaId,
                                                         MangaFieldsBuilder? fields = null,
                                                         CancellationToken token = default)
    {
        try
        {
            var uri = new MALUriBuilder($"manga/{CheckPositive(mangaId, nameof(mangaId))}")
                .AddFields(fields, _options.ExplicitFields)
                .Build();

            return await ExecuteRequestAsync<Models.Manga.Manga?>(HttpMethod.Get, uri, token).ConfigureAwait(false);
        }
        catch (MALClientException e) when (e.StatusCode is System.Net.HttpStatusCode.NotFound)
        {
            return null;
        }
        catch
        {
            throw;
        }
    }

    public IAsyncEnumerable<Ranked<Models.Manga.Manga>> GetMangaRankingAsync(MangaRankingType rankingType,
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
            .AddNsfw(nsfw)
            .AddFields(fields, _options.ExplicitFields);

        return ExecuteListRequestAsync<Ranked<Models.Manga.Manga>>(uri, limit, offset, token);
    }

    public Task<MangaListStatus> UpdateMyMangaStatusAsync(int mangaId,
                                                        MyMangaListStatusBuilder fields,
                                                        CancellationToken token = default)
    {
        return ExecuteRequestAsync<MangaListStatus>(HttpMethod.Patch,
                                                    $"manga/{CheckPositive(mangaId, nameof(mangaId))}/my_list_status",
                                                    token,
                                                    new FormUrlEncodedContent(fields.Fields));
    }

    public Task DeleteMyMangaListItemAsync(int mangaId,
                                           CancellationToken token = default)
    {
        return ExecuteRequestAsync(HttpMethod.Delete, $"manga/{CheckPositive(mangaId, nameof(mangaId))}/my_list_status", token);
    }

    public async IAsyncEnumerable<UserMangaListItem> GetUserMangaListAsync(string userName = "@me",
                                                                           ReadingStatus? status = null,
                                                                           MangaListSort sort = MangaListSort.MangaTitle,
                                                                           int limit = 100,
                                                                           int offset = 0,
                                                                           bool nsfw = false,
                                                                           UserMangaListFieldsBuilder? fields = null,
                                                                           [EnumeratorCancellation] CancellationToken token = default)
    {
        var uri = new MALUriBuilder($"users/{CheckStringParameter(userName, nameof(userName))}/mangalist")
            .AddReadingStatus(status)
            .Add("sort", sort switch
            {
                MangaListSort.ListScore => "list_score",
                MangaListSort.ListUpdatedAt => "list_updated_at",
                MangaListSort.MangaTitle => "manga_title",
                MangaListSort.MangaStartDate => "manga_start_date",
                MangaListSort.MangaId => "manga_id",
                _ => throw new InvalidEnumArgumentException(nameof(sort), (int)sort, typeof(MangaListSort))
            })
            .AddLimit(limit, 1000)
            .AddNsfw(nsfw)
            .AddFields(fields, _options.ExplicitFields);

        await foreach (var manga in ExecuteListRequestAsync<UserMangaListItem>(uri, limit, offset, token))
        {
            yield return manga;
        }
    }
}
