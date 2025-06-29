using System.Text.Json.Serialization;

namespace MALSharp.Models.Shared;

/// <summary>
/// Object representing simplified anime/manga info.
/// </summary>
public class Node
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public required string Title { get; set; }

    [JsonPropertyName("main_picture")]
    public Picture? MainPicture { get; set; }
}
