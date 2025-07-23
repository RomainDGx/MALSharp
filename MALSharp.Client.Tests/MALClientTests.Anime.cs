using MALSharp.Client.Tests.Models;
using MALSharp.Client.TestUtils;
using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MALSharp.Client.Tests;

public partial class MALClientTests
{
    [Test]
    public void Invlaid_anime_ID_throws_in_GetAnime_Async()
    {
        using var client = new MALClient(Generator.GenerateMALClientOptions());
        Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await client.GetAnimeAsync(-1));
    }

    [Test]
    public async Task Get_not_existing_anime_return_null_Async()
    {
        using var handler = new FakeHttpMessageHandler();
        handler.ConfigureResponse = r =>
        {
            r.StatusCode = HttpStatusCode.NotFound;
            r.Content = JsonContent.Create(new ErrorResponse { Error = "not_found" });
        };
        using var http = new HttpClient(handler);
        using var client = new MALClient(Generator.GenerateMALClientOptions(), http);
        var sut = await client.GetAnimeAsync(1);
        Assert.That(sut, Is.Null);
    }

    [Test]
    public async Task Send_and_receive_same_anime_Async()
    {
        var anime = Generator.GenerateAnime(true);
        using var handler = new FakeHttpMessageHandler();
        handler.ConfigureResponse = r => r.Content = JsonContent.Create(anime);
        using var http = new HttpClient(handler);
        using var client = new MALClient(Generator.GenerateMALClientOptions(), http);
        var sut = await client.GetAnimeAsync(1);
        Assert.That(JsonSerializer.Serialize(sut, _options), Is.EqualTo(JsonSerializer.Serialize(anime, _options)));
    }

    static readonly JsonSerializerOptions _options = new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
}
