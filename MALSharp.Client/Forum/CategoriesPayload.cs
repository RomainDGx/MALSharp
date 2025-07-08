using MALSharp.Models.Forum;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MALSharp.Client.Forum;

internal class CategoriesPayload
{
    [JsonPropertyName("categories")]
    public required List<Category> Categories { get; set; }
}
