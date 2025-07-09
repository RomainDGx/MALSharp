using MALSharp.Client.Anime;
using MALSharp.Models.Anime;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MALSharp.Client;

public partial class MALClient
{
    public IAsyncEnumerable<Models.Anime.Anime> SearchAnimeAsync(string search,
                                                                 int limit = 100,
                                                                 int offset = 0,
                                                                 bool nsfw = false,
                                                                 AnimeListFieldsBuilder? fields = null,
                                                                 CancellationToken token = default)
    {
        throw new System.NotImplementedException();
    }

    public Task<Models.Anime.Anime?> GetAnimeAsync(int animeId,
                                                   AnimeFieldsBuilder? fields = null,
                                                   CancellationToken token = default)
    {
        throw new System.NotImplementedException();
    }

    public IAsyncEnumerable<Ranked<Models.Anime.Anime>> GetAnimeRankingAsync(AnimeRankingType rankingType,
                                                                             int limit = 100,
                                                                             int offset = 0,
                                                                             bool nsfw = false,
                                                                             AnimeListFieldsBuilder? fields = null,
                                                                             CancellationToken token = default)
    {
        throw new System.NotImplementedException();
    }

    public IAsyncEnumerable<Models.Anime.Anime> GetSeasonalAnimeAsync(int year,
                                                                      Season season,
                                                                      SeasonalAnimeSort sort,
                                                                      int limit = 100,
                                                                      int offset = 0,
                                                                      bool nsfw = false,
                                                                      AnimeListFieldsBuilder? fields = null,
                                                                      CancellationToken token = default)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Returns suggested anime for the authorized user.
    /// If the user is new comer, this endpoint returns an empty list.
    /// </summary>
    public IAsyncEnumerable<Models.Anime.Anime> GetSuggestedAnimeAsync(int limit = 100,
                                                                       int offset = 0,
                                                                       bool nsfw = false,
                                                                       AnimeListFieldsBuilder? fields = null,
                                                                       CancellationToken token = default)
    {
        throw new System.NotImplementedException();
    }

    public IAsyncEnumerable<AnimeCharacter> GetAnimeCharactersAsync(int animeId,
                                                                    int limit = 500,
                                                                    int offset = 0,
                                                                    CharacterListFieldsBuilder? fields = null,
                                                                    CancellationToken token = default)
    {
        throw new System.NotImplementedException();
    }

    public Task<Character?> GetCharacterAsync(int characterId,
                                              CharacterFieldsBuilder? fields = null,
                                              CancellationToken token = default)
    {
        throw new System.NotImplementedException();
    }
}
