using System;
using System.Text.Json.Serialization;

namespace MALSharp.Models.Forum;

public class AuthorWithAvatar : Author
{
    [JsonPropertyName("mods_title")]
    public string? ModsTitle { get; set; }

    [JsonPropertyName("forum_title")]
    public string? ForumTitle { get; set; }

    // Note: typo in field in api V2
    [JsonPropertyName("forum_avator")]
    public required Uri ForumAvatar { get; set; }
}
