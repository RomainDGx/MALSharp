using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MALSharp.Models.Forum;

public class Category
{
    [JsonPropertyName("title")]
    public required string Title { get; set; }

    [JsonPropertyName("boards")]
    public required List<Board> Boards { get; set; }
}
