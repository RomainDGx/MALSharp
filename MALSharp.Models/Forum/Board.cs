using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MALSharp.Models.Forum;

public class Board
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public required string Title { get; set; }

    [JsonPropertyName("description")]
    public required string Description { get; set; }

    [JsonPropertyName("subboards")]
    public required List<Subboard> Subboards { get; set; }
}
