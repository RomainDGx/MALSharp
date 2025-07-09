using MALSharp.Client.Forum;
using MALSharp.Models.Forum;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MALSharp.Client;

public partial class MALClient
{
    public async Task<IEnumerable<Category>> GetForumBoardsAsync(CancellationToken token = default)
    {
        var payload = await ExecuteRequestAsync<CategoriesPayload>(HttpMethod.Get, "forum/boards", token).ConfigureAwait(false);

        return payload.Categories;
    }

    public async Task<TopicDetail?> GetForumTopicDetailAsync(int topicId,
                                                             int limit = 100,
                                                             int offset = 0,
                                                             CancellationToken token = default)
    {
        var builder = new MALUriBuilder($"forum/topic/{CheckPositive(topicId, nameof(topicId))}")
            .AddLimit(limit, 100)
            .SetOffset(offset);

        TopicDetail? topic = null;

        try
        {
            while (!token.IsCancellationRequested && limit > 0)
            {
                var content = await ExecuteRequestAsync<TopicDetailPayload>(HttpMethod.Get, builder.Build(), token).ConfigureAwait(false);

                if (topic is null)
                {
                    topic = content.Topic;
                    limit -= topic.Posts.Count;
                    offset += topic.Posts.Count;

                    if (limit <= 0)
                    {
                        break;
                    }
                }
                else
                {
                    foreach (var post in content.Topic.Posts)
                    {
                        topic.Posts.Add(post);

                        if (--limit <= 0)
                        {
                            return topic;
                        }
                        offset++;
                    }
                }
                if (string.IsNullOrEmpty(content.Paging.Next))
                {
                    break;
                }
                builder.SetLimit(limit)
                       .SetOffset(offset);

                await Task.Delay(_options.InterRequestDelay, token).ConfigureAwait(false);
            }
        }
        catch (MALClientException e) when (e.StatusCode is HttpStatusCode.NotFound)
        {
            return null;
        }
        catch
        {
            throw;
        }

        return topic;
    }

    public IAsyncEnumerable<Topic> GetForumTopicsByBoardAsync(int boardId,
                                                              int limit = 100,
                                                              int offset = 0,
                                                              CancellationToken token = default)
    {
        return GetForumTopicsAsync("board_id", CheckPositive(boardId, nameof(boardId)), limit, offset, token);
    }

    public IAsyncEnumerable<Topic> GetForumTopicsBySubboardAsync(int subboardId,
                                                                 int limit = 100,
                                                                 int offset = 0,
                                                                 CancellationToken token = default)
    {
        return GetForumTopicsAsync("subboard_id", CheckPositive(subboardId, nameof(subboardId)), limit, offset, token);
    }

    public IAsyncEnumerable<Topic> GetForumTopicsByQuerysync(string query,
                                                             int limit = 100,
                                                             int offset = 0,
                                                             CancellationToken token = default)
    {
        return GetForumTopicsAsync("q", CheckStringParameter(query, nameof(query)), limit, offset, token);
    }

    public IAsyncEnumerable<Topic> GetForumTopicsByTopicUserNameAsync(string topicUserName,
                                                                      int limit = 100,
                                                                      int offset = 0,
                                                                      CancellationToken token = default)
    {
        return GetForumTopicsAsync("topic_user_name", CheckStringParameter(topicUserName, nameof(topicUserName)), limit, offset, token);
    }

    public IAsyncEnumerable<Topic> GetForumTopicsByUserNameAsync(string userName,
                                                                 int limit = 100,
                                                                 int offset = 0,
                                                                 CancellationToken token = default)
    {
        return GetForumTopicsAsync("user_name", CheckStringParameter(userName, nameof(userName)), limit, offset, token);
    }

    IAsyncEnumerable<Topic> GetForumTopicsAsync(string key,
                                                string value,
                                                int limit,
                                                int offset,
                                                CancellationToken token = default)
    {
        var builder = new MALUriBuilder("forum/topics")
            .Add("sort", "recent")
            .Add(key, value)
            .AddLimit(limit, 100);

        return ExecuteListRequestAsync<Topic>(builder, limit, offset, token);
    }
}
