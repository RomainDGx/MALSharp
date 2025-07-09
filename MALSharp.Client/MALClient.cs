using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MALSharp.Client;

public sealed partial class MALClient : IMALClient
{
    readonly HttpClient _http;
    readonly MALClientOptions _options;
    readonly JsonSerializerOptions _serializationOptions;

    public MALClient(HttpClient http, MALClientOptions options)
    {
        _http = http;
        _options = options;
        _serializationOptions = new JsonSerializerOptions
        {
            Encoder = _options.JavaScriptEncoder
        };
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
        using var request = new HttpRequestMessage(method, uri);

        using var response = await _http.SendAsync(request, token).ConfigureAwait(false);

        await EnsureSuccessResponseAsync(response, token).ConfigureAwait(false);

        var result = await response.Content.ReadFromJsonAsync<T>(_serializationOptions, token).ConfigureAwait(false);

        return result ?? throw new MALClientException(response.StatusCode, null, "An error has occured while parsing response content.");
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

}
