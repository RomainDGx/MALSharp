# MALSharp.Client.Hosting

`MALSharp.Client.Hosting` provides seamless integration of the `MALClient` with .NET dependency injection and hosting abstractions.
It enables you to register and configure the MyAnimeList client for both public and authenticated API usage using idiomatic .NET practices.

## Features

- Register `IMALClient` via `IServiceCollection`.
- Supports both unauthenticated and authenticated MyAnimeList API calls via `IAccessTokenProvider`.
- Integration with `IHostBuilder` and `IHostApplicationBuilder`.
- Configuration-driven setup through `IConfiguration`.

## Using `AddMALClient`

You can register the `IMALClient` into the DI via `IServiceCollection` extensions methods and configure `MALClientOptions`:

### Unauthenticated Usage

For authenticated calls, you provide your own `IAccessTokenProvider` implementation:
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
});

builder.Services.AddScoped<IAccessTokenProvider, MyAccessTokenProvider>();
```
This approach allows you to plug in any token resolution logic (e.g. from ASP.NET Core `HttpContext`, a database, or a cache).

## Using Host Builders

`MALSharp.Client.Hosting` provides integration methods for both `IHostBuilder` and `IHostApplicationBuilder`.

With this approach, you can configure the client via configuration files.

### Example: appsettings.json
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

### Registering with `IHostBuilder`
```cs
hostBuilder.UseMALClient();
```

### With Additional Code-Based Configuration
```cs
hostBuilder.UseMALClient(options =>
{
    options.JavaScriptEncoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
});
```
**Note:** When using the `UseMALClient(Action<MALClientOptions>)` overload, the options provided in `appsettings.json` are applied first.  
The `configureOptions` delegate is then applied on top, allowing you to override or extend the configuration values.

### JavaScriptEncoder Limitation

Due to the limitations of configuration binding, `JavaScriptEncoder` cannot be configured via `IConfiguration`.
You must set it manually using the delegate overload of `AddMALClient` or `UseMALClient`.
```cs
services.AddMALClient(options =>
{
    options.ClientId = "<your-client-id>";
    options.JavaScriptEncoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
});

hostBuilder.UseMALClient(options =>
{
    options.JavaScriptEncoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
});
```

## Registered Services
- `IMALClient` as scoped.
- Optional: user-provided `IAccessTokenProvider` for authenticated access.
