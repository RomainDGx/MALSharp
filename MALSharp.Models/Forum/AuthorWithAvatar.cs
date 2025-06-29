using System;
using System.Text.Json.Serialization;

namespace MALSharp.Models.Forum;

public class AuthorWithAvatar : Author
{
    // Note: typo in field in api V2
    [JsonPropertyName("forum_avator")]
    public required Uri ForumAvatar { get; set; }
}
