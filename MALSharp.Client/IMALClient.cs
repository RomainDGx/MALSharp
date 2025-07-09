using MALSharp.Client.Anime;
using MALSharp.Client.User;
using MALSharp.Models.Anime;
using MALSharp.Models.Forum;
using MALSharp.Models.User;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MALSharp.Client;

public interface IMALClient
{
    #region Anime
    IAsyncEnumerable<Models.Anime.Anime> SearchAnimeAsync(string search,
                                                          int limit = 100,
                                                          int offset = 0,
                                                          bool nsfw = false,
                                                          AnimeListFieldsBuilder? fields = null,
                                                          CancellationToken token = default);

    Task<Models.Anime.Anime?> GetAnimeAsync(int animeId,
                                            AnimeFieldsBuilder? fields = null,
                                            CancellationToken token = default);

    IAsyncEnumerable<Ranked<Models.Anime.Anime>> GetAnimeRankingAsync(AnimeRankingType rankingType,
                                                                      int limit = 100,
                                                                      int offset = 0,
                                                                      bool nsfw = false,
                                                                      AnimeListFieldsBuilder? fields = null,
                                                                      CancellationToken token = default);

    IAsyncEnumerable<Models.Anime.Anime> GetSeasonalAnimeAsync(int year,
                                                               Season season,
                                                               SeasonalAnimeSort sort,
                                                               int limit = 100,
                                                               int offset = 0,
                                                               bool nsfw = false,
                                                               AnimeListFieldsBuilder? fields = null,
                                                               CancellationToken token = default);

    /// <summary>
    /// Returns suggested anime for the authorized user.
    /// If the user is new comer, this endpoint returns an empty list.
    /// </summary>
    IAsyncEnumerable<Models.Anime.Anime> GetSuggestedAnimeAsync(int limit = 100,
                                                                int offset = 0,
                                                                bool nsfw = false,
                                                                AnimeListFieldsBuilder? fields = null,
                                                                CancellationToken token = default);

    IAsyncEnumerable<AnimeCharacter> GetAnimeCharactersAsync(int animeId,
                                                             int limit = 500,
                                                             int offset = 0,
                                                             CharacterListFieldsBuilder? fields = null,
                                                             CancellationToken token = default);

    Task<Character?> GetCharacterAsync(int characterId,
                                       CharacterFieldsBuilder? fields = null,
                                       CancellationToken token = default);
    #endregion

    #region Forum
    Task<IEnumerable<Category>> GetForumBoardsAsync(CancellationToken token = default);

    Task<TopicDetail?> GetForumTopicDetailAsync(int topicId,
                                                int limit = 100,
                                                int offset = 0,
                                                CancellationToken token = default);

    IAsyncEnumerable<Topic> GetForumTopicsByBoardAsync(int boardId,
                                                       int limit = 100,
                                                       int offset = 0,
                                                       CancellationToken token = default);

    IAsyncEnumerable<Topic> GetForumTopicsBySubboardAsync(int subboardId,
                                                          int limit = 100,
                                                          int offset = 0,
                                                          CancellationToken token = default);

    IAsyncEnumerable<Topic> GetForumTopicsByQuerysync(string query,
                                                      int limit = 100,
                                                      int offset = 0,
                                                      CancellationToken token = default);

    IAsyncEnumerable<Topic> GetForumTopicsByTopicUserNameAsync(string topicUserName,
                                                               int limit = 100,
                                                               int offset = 0,
                                                               CancellationToken token = default);

    IAsyncEnumerable<Topic> GetForumTopicsByUserNameAsync(string userName,
                                                          int limit = 100,
                                                          int offset = 0,
                                                          CancellationToken token = default);
    #endregion

    #region User
    Task<UserInformation> GetMyUserInformationsAsync(UserInformationFieldsBuilder? fields = null,
                                                     CancellationToken token = default);
    #endregion
}
