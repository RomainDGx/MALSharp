# MALSharp.Client

`MALSharp.Client` is a strongly typed C# client for the [MyAnimeList REST API V2](https://myanimelist.net/apiconfig/references/api/v2).

It wraps all available endpoints (anime, manga, user, lists, etc.) and provides asynchronous methods with type-safe request/response contracts.

**Key features**:
- Full support for [MyAnimeList REST API V2](https://myanimelist.net/apiconfig/references/api/v2)
- Typed request/response interfaces
- Built-in error handling and pagination
- Designed for DI and unit testing
- Depends on [MALSharp.Models](../MALSharp.Models/README.md)