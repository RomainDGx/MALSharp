# MALSharp.Models

`MALSharp.Models` provides a set of data models representing core entities from the [MyAnimeList API V2](https://myanimelist.net/apiconfig/references/api/v2).  
The model definitions are also based on the [MAL Client Upgraded’s documentation](https://mal-api-client-upgraded.readthedocs.io/en/latest/index.html) for consistency and completeness.

It includes models for anime, manga, user profiles, and lists.  
These models are fully independent from the API client and can be used for serialization, validation, testing, or integration into custom tools.

**Key features**:
- Clean and lightweight POCOs
- Designed for JSON (de)serialization (`System.Text.Json`)
- Reusable across applications and layers
- No external dependencies
