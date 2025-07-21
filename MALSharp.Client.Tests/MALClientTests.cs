using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MALSharp.Client.Tests;

[TestFixture]
public partial class MALClientTests
{
    [TestCase(null)]
    [TestCase("")]
    [TestCase("   ")]
    public void Invalid_cient_ID_throws(string clientId)
    {
        Assert.Throws<ArgumentException>(() => new MALClient(new MALClientOptions { ClientId = clientId }));
    }

    [TestCase("XXX")]
    [TestCase("BA37A16A-5C1F-4002-A40F-398C01A65C15")]
    [TestCase("Test")]
    public async Task Client_ID_is_added_in_request(string clientId)
    {
        var isTestCalled = false;
        using var handler = new FakeHttpMessageHandler();
        handler.HandleRequest = r =>
        {
            isTestCalled = true;
            Assert.That(r.Headers.TryGetValues("X-MAL-CLIENT-ID", out var values), Is.True);
            Assert.That(values, Has.Length.EqualTo(1).And.Contains(clientId));
        };
        using var http = new HttpClient(handler);
        using var client = new MALClient(new MALClientOptions { ClientId = clientId }, http);
        await client.DeleteMyAnimeListItemAsync(1);
        Assert.That(isTestCalled, Is.True);
    }

    [Test]
    public async Task Access_token_is_not_in_request()
    {
        var isTestCalled = false;
        using var handler = new FakeHttpMessageHandler();
        handler.HandleRequest = r =>
        {
            isTestCalled = true;
            Assert.That(r.Headers.Authorization, Is.Null);
        };
        using var http = new HttpClient(handler);
        using var client = new MALClient(Generator.GenerateMALClientOptions(), http);
        await client.DeleteMyAnimeListItemAsync(1);
        Assert.That(isTestCalled, Is.True);
    }

    [TestCase("XXX")]
    [TestCase("BA37A16A-5C1F-4002-A40F-398C01A65C15")]
    [TestCase("Test")]
    public async Task Access_token_is_added_in_request(string accessToken)
    {
        var isTestCalled = false;
        using var handler = new FakeHttpMessageHandler();
        handler.HandleRequest = r =>
        {
            isTestCalled = true;
            Assert.That(r.Headers.Authorization, Is.Not.Null);
            Assert.That(r.Headers.Authorization!.Scheme, Is.EqualTo("Bearer"));
            Assert.That(r.Headers.Authorization!.Parameter, Is.EqualTo(accessToken));
        };
        using var http = new HttpClient(handler);
        var provider = new FakeAccessTokenProvider(accessToken);
        using var client = new MALClient(Generator.GenerateMALClientOptions(), http, provider);
        await client.DeleteMyAnimeListItemAsync(1);
        Assert.That(isTestCalled, Is.True);
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("   ")]
    [TestCase("test")]
    [TestCase("127.0.0.1:5000")]
    [TestCase("api.myanimelist.net/v2/")]
    public void Invalid_uri_throws(string uri)
    {
        var options = Generator.GenerateMALClientOptions();
        options.BaseUrl = uri;
        Assert.Throws<ArgumentException>(() => new MALClient(options));
    }

    [TestCase("http://localhost:5000")]
    [TestCase("https://api.myanimelist.net/v2/")]
    public async Task Valid_uri_works(string uri)
    {
        bool isTestCalled = false;
        using var handler = new FakeHttpMessageHandler();
        handler.HandleRequest = r =>
        {
            isTestCalled = true;
            Assert.That(r.RequestUri, Is.Not.Null);
            Assert.That(r.RequestUri!.AbsoluteUri, Does.StartWith(uri));
        };
        using var http = new HttpClient(handler);
        var options = Generator.GenerateMALClientOptions();
        options.BaseUrl = uri;
        using var client = new MALClient(options, http);
        await client.DeleteMyAnimeListItemAsync(1);
        Assert.That(isTestCalled, Is.True);
    }
}
