using System;
using System.Net;

namespace MALSharp.Client;

public class MALClientException : Exception
{
    readonly HttpStatusCode _statusCode;
    readonly string? _error;

    public MALClientException(HttpStatusCode statusCode, string? error, string? message)
        : base(message)
    {
        _statusCode = statusCode;
        _error = error;
    }

    public HttpStatusCode StatusCode => _statusCode;

    public string? Error => _error;
}
