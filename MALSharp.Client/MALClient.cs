using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MALSharp.Client;

public sealed partial class MALClient : IMALClient, IDisposable
{
    readonly MALClientOptions _options;
    readonly JsonSerializerOptions _serializationOptions;
    readonly bool _disposeHttpClient;
    readonly HttpClient _http;
    readonly IAccessTokenProvider? _accessTokenProvider;
    readonly ILogger<MALClient>? _logger;

    public MALClient(MALClientOptions options) : this(options, (IAccessTokenProvider?)null, null, null) { }

    public MALClient(MALClientOptions options, ILogger<MALClient> logger) : this(options, (IAccessTokenProvider?)null, null, logger) { }

    public MALClient(MALClientOptions options, HttpClient httpClient) : this(options, null, httpClient, null) { }

    public MALClient(MALClientOptions options, HttpClient httpClient, ILogger<MALClient> logger) : this(options, null, httpClient, logger) { }

    public MALClient(MALClientOptions options, IAccessTokenProvider accessTokenProvider) : this(options, accessTokenProvider, null, null) { }

    public MALClient(MALClientOptions options, IAccessTokenProvider accessTokenProvider, ILogger<MALClient> logger) : this(options, accessTokenProvider, null, logger) { }

    public MALClient(MALClientOptions options, HttpClient httpClient, IAccessTokenProvider accessTokenProvider) : this(options, accessTokenProvider, httpClient, null) { }

    public MALClient(MALClientOptions options, HttpClient httpClient, IAccessTokenProvider accessTokenProvider, ILogger<MALClient> logger) : this(options, accessTokenProvider, httpClient, logger) { }

    MALClient(MALClientOptions options, IAccessTokenProvider? accessTokenProvider, HttpClient? httpClient, ILogger<MALClient>? logger)
    {
        if (string.IsNullOrWhiteSpace(options.ClientId))
        {
            throw new ArgumentException("ClientId must be provided.", nameof(options));
        }
        if (!Uri.TryCreate(options.BaseUrl, UriKind.Absolute, out var uri))
        {
            throw new ArgumentException("BaseUrl must contains an absolute Uri.", nameof(options));
        }
        _options = options;
        _serializationOptions = new JsonSerializerOptions
        {
            Encoder = _options.JavaScriptEncoder
        };
        _disposeHttpClient = httpClient is null;
        _http = httpClient ?? new HttpClient();
        _http.BaseAddress ??= uri;
        _http.Timeout = _options.Timeout;
        if (!_http.DefaultRequestHeaders.Contains("X-MAL-CLIENT-ID"))
        {
            _http.DefaultRequestHeaders.Add("X-MAL-CLIENT-ID", _options.ClientId);
        }
        _accessTokenProvider = accessTokenProvider;
        _logger = logger;

        _logger?.LogInformation("MALClient initialized with BaseUrl: {BaseUrl}", _http.BaseAddress);
    }

    async IAsyncEnumerable<T> ExecuteListRequestAsync<T>(MALUriBuilder builder, int limit, int offset, [EnumeratorCancellation] CancellationToken token)
    {
        if (limit <= 0)
        {
            _logger?.LogWarning("ExecuteListRequestAsync called with non-positive limit: {Limit}", limit);
            yield break;
        }

        while (!token.IsCancellationRequested)
        {
            var uri = builder.SetLimit(limit).SetOffset(offset).Build();

            _logger?.LogDebug("Sending paginated request with limit={Limit} offset={Offset} uri={Uri}", limit, offset, uri);

            var content = await ExecuteRequestAsync<ResponseListPayload<T>>(HttpMethod.Get, uri, token).ConfigureAwait(false);

            foreach (var item in content.Data)
            {
                yield return item;

                if (--limit <= 0)
                {
                    _logger?.LogDebug("Pagination limit reached, stopping iteration");
                    yield break;
                }
                offset++;
            }
            if (string.IsNullOrEmpty(content.Paging.Next))
            {
                _logger?.LogDebug("No more pages to fetch, stopping iteration");
                yield break;
            }

            await Task.Delay(_options.InterRequestDelay, token).ConfigureAwait(false);
        }
    }

    async Task<T> ExecuteRequestAsync<T>(HttpMethod method, string uri, CancellationToken token)
    {
        using var request = await BuildRequestAsync(method, uri, token).ConfigureAwait(false);

        _logger?.LogDebug("Sending HTTP request: {Method} {Uri}", method, uri);

        using var response = await _http.SendAsync(request, token).ConfigureAwait(false);

        _logger?.LogDebug("Received HTTP response: {StatusCode} {Uri}", response.StatusCode, uri);

        await EnsureSuccessResponseAsync(response, token).ConfigureAwait(false);

        var result = await response.Content.ReadFromJsonAsync<T>(_serializationOptions, token).ConfigureAwait(false);

        if (result is null)
        {
            _logger?.LogError("Failed to deserialize response for: {Uri}", uri);
            throw new MALClientException(response.StatusCode, null, "An error has occured while parsing response content.");
        }
        return result;
    }

    async Task<HttpRequestMessage> BuildRequestAsync(HttpMethod method, string uri, CancellationToken token)
    {
        var request = new HttpRequestMessage(method, uri);

        if (_accessTokenProvider is not null)
        {
            var accessToken = await _accessTokenProvider.GetAccessTokenAsync(token).ConfigureAwait(false);
            if (accessToken is not null)
            {
                _logger?.LogDebug("Attached Bearer token to request: {Uri}", uri);
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }
            else
            {
                _logger?.LogWarning("AccessTokenProvider returned null or empty token for request: {Uri}", uri);
            }
        }
        return request;
    }

    async Task EnsureSuccessResponseAsync(HttpResponseMessage response, CancellationToken token)
    {
        if (!response.IsSuccessStatusCode)
        {
            _logger?.LogWarning("Non-success status code received: {StatusCode}", response.StatusCode);

            var error = await response.Content.ReadFromJsonAsync<ErrorResponse>(_serializationOptions, token).ConfigureAwait(false);

            if (error is not null)
            {
                _logger?.LogError("API returned error: {Error} - {Message}", error.Error, error.Message);
                throw new MALClientException(response.StatusCode, error.Error, error.Message);
            }
            _logger?.LogError("API returned non-success status code with unparseable body");
            throw new MALClientException(response.StatusCode, null, "An error has occured while parsing response error content.");
        }
    }

    static string CheckPositive(int value, string paramName)
    {
        if (value < 0)
        {
            throw new ArgumentException("Parameter cannot be negative or zero.", paramName);
        }
        return value.ToString();
    }

    static string CheckStringParameter(string value, string paramName)
    {
        if (string.IsNullOrEmpty(value = value.Trim()))
        {
            throw new ArgumentException("Parameter cannot be null, empty or white space.", paramName);
        }
        return value;
    }

    public void Dispose()
    {
        if (_disposeHttpClient)
        {
            _logger?.LogInformation("Disposing HttpClient created by MALClient");
            _http.Dispose();
        }
    }
}
