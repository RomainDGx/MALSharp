using MALSharp.Client.User;
using MALSharp.Models.Forum;
using MALSharp.Models.User;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MALSharp.Client;

public interface IMALClient
{
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
