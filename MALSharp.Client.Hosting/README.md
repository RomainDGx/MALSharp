# MALSharp.Client.Hosting

`MALSharp.Client.Hosting` provides seamless integration of the `MALClient` with .NET dependency injection and hosting abstractions.
It enables you to register and configure the MyAnimeList client for both public and authenticated API usage using idiomatic .NET practices.

## Features

- Register `IMALClient` via `IServiceCollection`.
- Supports both unauthenticated and authenticated MyAnimeList API calls via `IAccessTokenProvider`.
- Preconfigured named `HttpClient` with `ClientId`, base address, and timeout.
- Integration with `IHostBuilder` and `IHostApplicationBuilder`.
- Configuration-driven setup through `IConfiguration`.

## Using `AddMALClient`

You can register the `IMALClient` into the DI via `IServiceCollection` extensions methods and edit `MALClientOptions`:

### Unauthenticated Usage

```cs
builder.Services.AddMALClient(options =>
{
    options.ClientId = "your-mal-client-id";
});
```

_Note:_ You can view the default configuration of [MALClientOptions](../MALSharp.Client/MALClientOptions.cs).

### Authenticated Usage

```cs
builder.Services.AddMALClient(options =>
{
    options.ClientId = "your-mal-client-id";
},
provider => new MyAccessTokenProvider(provider));
```
This approach is ideal when you want to programmatically define options and/or resolve your own `IAccessTokenProvider`.

## Using Host Builders

`MALSharp.Client.Hosting` provides integration methods for both `IHostBuilder` and `IHostApplicationBuilder`:

With this approach you can configure your client with `Configuration`.

You can configure the client through `appsettings.json` using the `MALClient` section:
```json
{
  "MALClient": {
    "ClientId": "your-mal-client-id",
    "BaseUrl": "https://api.myanimelist.net/v2/",
    "Timeout": "00:00:30",
    "ExplicitFields": true,
    "InterRequestDelay": "00:00:01"
  }
}
```

Then register with:
```cs
hostBuilder.UseMALClient();
```

Or with Access Token Provider:
```cs
hostBuilder.UseMALClient(provider => new MyAccessTokenProvider(provider));
```

### JavaScriptEncoder Limitation

Due to the limitations of configuration binding, `JavaScriptEncoder` cannot be configured via `IConfiguration`.
You must set it manually using the delegate overload of `AddMALClient`.
```cs
services.AddMALClient(options =>
{
    options.ClientId = "<your-client-id>";
    options.JavaScriptEncoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
});
```

## Registered Services
- `IMALClient` as scoped.
- `HttpClient` named `"MALSharp"` with preconfigured headers and timeout.
- Optional: custom `IAccessTokenProvider` for authenticated access.
