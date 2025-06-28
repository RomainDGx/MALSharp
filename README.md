# MALSharp

## About

**MALSharp** is a modern, user-friendly C# implementation for interacting with the MyAnimeList API v2.  
It aims to provide a clean and maintainable developer experience through a modular architecture:  
- **[MALSharp.Models](./MALSharp.Models/README.md)**: Reusable POCO models decoupled from the transport layer.
- **MALSharp.Client**: A strongly-typed, easy-to-use REST API client.
- **MALSharp.Client.AspNetCore**: An optional ASP.NET Core extension for OAuth2 flows and token management.

By keeping each concern in its own package, MALSharp stays flexible, testable, and simple to integrate into any .NET application.
