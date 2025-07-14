using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

class FakeHttpMessageHandler : HttpMessageHandler
{
    public Action<HttpRequestMessage>? HandleRequest { get; set; }

    public Func<HttpRequestMessage, Task>? HandleRequestAsync { get; set; }

    public Action<HttpResponseMessage>? ConfigureResponse { get; set; }

    public Func<HttpResponseMessage, Task>? ConfigureResponseAsync { get; set; }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        HandleRequest?.Invoke(request);

        if (HandleRequestAsync is not null)
        {
            await HandleRequestAsync(request);
        }

        var response = new HttpResponseMessage
        {
            RequestMessage = request
        };

        ConfigureResponse?.Invoke(response);

        if (ConfigureResponseAsync is not null)
        {
            await ConfigureResponseAsync(response);
        }

        return response;
    }
}