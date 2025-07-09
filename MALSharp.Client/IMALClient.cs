using MALSharp.Client.Anime;
using MALSharp.Client.Manga;
using MALSharp.Client.User;
using MALSharp.Models.Anime;
using MALSharp.Models.Forum;
using MALSharp.Models.Manga;
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

    #region Anime list
    /// <summary>
    /// Add specified anime to my anime list.
    /// If specified anime already exists, update its status.
    /// This endpoint updates only values specified by the parameter.
    /// </summary>
    /// <param name="score">Value between 0 and 10.</param>
    /// <param name="priority">Value between 0 and 2.</param>
    /// <param name="rewatchValue">Value between 0 and 5.</param>
    /// <returns>An updated <see cref="AnimeListStatus"/>.</returns>
    Task<AnimeListStatus> UpdateMyAnimeListStatusAsync(int animeId,
                                                       WatchingStatus? status = null,
                                                       bool? isRewatching = null,
                                                       int? score = null,
                                                       int? numWatchedEpisodes = null,
                                                       int? priority = null,
                                                       int? numTimesRewatched = null,
                                                       int? rewatchValue = null,
                                                       string? tags = null,
                                                       string? comments = null,
                                                       CancellationToken token = default);

    /// <summary>
    /// If the specified anime does not exist in user's anime list, throw an error.
    /// So be careful when retrying.
    /// </summary>
    Task DeleteMyAnimeListItemAsync(int animeId, CancellationToken token = default);

    /// <param name="status">Filters returned anime list by these statuses. To return all anime, don't specify this field.</param>
    IAsyncEnumerable<UserAnimeListItem> GetUserAnimeListAsync(string userName = "@me",
                                                              WatchingStatus? status = null,
                                                              AnimeListSort sort = AnimeListSort.AnimeTitle,
                                                              int limit = 100,
                                                              int offset = 0,
                                                              bool nsfw = false,
                                                              UserAnimeListFieldsBuilder? fields = null,
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

    #region Manga
    IAsyncEnumerable<Models.Manga.Manga> SearchMangaAsync(string search,
                                                          int limit = 100,
                                                          int offset = 0,
                                                          bool nsfw = false,
                                                          MangaListFieldsBuilder? fields = null,
                                                          CancellationToken token = default);

    Task<Models.Manga.Manga?> GetMangaAsync(int mangaId,
                                            MangaFieldsBuilder? fields = null,
                                            CancellationToken token = default);

    IAsyncEnumerable<Ranked<Models.Manga.Manga>> GetMangaRanking(MangaRankingType rankingType,
                                                                 int limit = 100,
                                                                 int offset = 0,
                                                                 bool nsfw = false,
                                                                 MangaListFieldsBuilder? fields = null,
                                                                 CancellationToken token = default);
    #endregion

    #region Manga list
    /// <summary>
    /// Add specified manga to my manga list.
    /// If specified manga already exists, update its status.
    /// This endpoint updates only values specified by the parameter.
    /// </summary>
    /// <param name="score">Value between 0 and 10.</param>
    /// <param name="priority">Value between 0 and 2.</param>
    /// <param name="rereadValue">Value between 0 and 5.</param>
    Task<MangaListStatus> UpdateMyMangaListAsync(int mangaId,
                                                 ReadingStatus? status = null,
                                                 bool? isReading = null,
                                                 int? score = null,
                                                 int? numVolumesRead = null,
                                                 int? numChaptersRead = null,
                                                 int? priority = null,
                                                 int? numTimesReread = null,
                                                 int? rereadValue = null,
                                                 string? tags = null,
                                                 string? comments = null,
                                                 CancellationToken token = default);

    /// <summary>
    /// If the specified manga does not exist in user's manga list, throw an error.
    /// So be careful when retrying.
    /// </summary>
    Task DeleteMyMangaListItemAsync(int mangaId, CancellationToken token = default);

    /// <param name="status">Filters returned manga list by these statuses. To return all manga, don't specify this field.</param>
    IAsyncEnumerable<UserMangaListItem> GetUserMangaListAsync(string userName = "@me",
                                                              ReadingStatus? status = null,
                                                              MangaListSort sort = MangaListSort.MangaTitle,
                                                              int limit = 100,
                                                              int offset = 0,
                                                              bool nsfw = false,
                                                              UserMangaListFieldsBuilder? fields = null,
                                                              CancellationToken token = default);
    #endregion

    #region User
    Task<UserInformation> GetMyUserInformationsAsync(UserInformationFieldsBuilder? fields = null,
                                                     CancellationToken token = default);
    #endregion
}
