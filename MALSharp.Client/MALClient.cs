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

    public MALClient(MALClientOptions options)
        : this(options, (IAccessTokenProvider?)null, null)
    {
    }

    public MALClient(MALClientOptions options, HttpClient httpClient)
        : this(options, null, httpClient)
    {
    }

    public MALClient(MALClientOptions options, IAccessTokenProvider accessTokenProvider)
        : this(options, accessTokenProvider, null)
    {
    }

    public MALClient(MALClientOptions options, HttpClient httpClient, IAccessTokenProvider accessTokenProvider)
        : this(options, accessTokenProvider, httpClient)
    {
    }

    MALClient(MALClientOptions options, IAccessTokenProvider? accessTokenProvider, HttpClient? httpClient)
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
    }

    async IAsyncEnumerable<T> ExecuteListRequestAsync<T>(MALUriBuilder builder, int limit, int offset, [EnumeratorCancellation] CancellationToken token)
    {
        if (limit <= 0)
        {
            yield break;
        }

        while (!token.IsCancellationRequested)
        {
            builder.SetLimit(limit)
                   .SetOffset(offset);

            var content = await ExecuteRequestAsync<ResponseListPayload<T>>(HttpMethod.Get, builder.Build(), token).ConfigureAwait(false);

            foreach (var item in content.Data)
            {
                yield return item;

                if (--limit <= 0)
                {
                    yield break;
                }
                offset++;
            }
            if (string.IsNullOrEmpty(content.Paging.Next))
            {
                yield break;
            }

            await Task.Delay(_options.InterRequestDelay, token).ConfigureAwait(false);
        }
    }

    async Task<T> ExecuteRequestAsync<T>(HttpMethod method, string uri, CancellationToken token)
    {
        using var request = await BuildRequestAsync(method, uri, token).ConfigureAwait(false);

        using var response = await _http.SendAsync(request, token).ConfigureAwait(false);

        await EnsureSuccessResponseAsync(response, token).ConfigureAwait(false);

        var result = await response.Content.ReadFromJsonAsync<T>(_serializationOptions, token).ConfigureAwait(false);

        return result ?? throw new MALClientException(response.StatusCode, null, "An error has occured while parsing response content.");
    }

    async Task<HttpRequestMessage> BuildRequestAsync(HttpMethod method, string uri, CancellationToken token)
    {
        var request = new HttpRequestMessage(method, uri);

        if (_accessTokenProvider is not null)
        {
            var accessToken = await _accessTokenProvider.GetAccessTokenAsync(token).ConfigureAwait(false);
            if (accessToken is not null)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }
        }
        return request;
    }

    async Task EnsureSuccessResponseAsync(HttpResponseMessage response, CancellationToken token)
    {
        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadFromJsonAsync<ErrorResponse>(_serializationOptions, token).ConfigureAwait(false);

            if (error is not null)
            {
                throw new MALClientException(response.StatusCode, error.Error, error.Message);
            }
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
            _http.Dispose();
        }
    }
}
