using System.Text.Json;

namespace MALSharp.Models.Converters;

internal static class ConvertHelper
{
    /// <summary>
    /// Checks that the current JSON token is of type string.
    /// Throws a <see cref="JsonException"/> if the token is not a string.
    /// </summary>
    /// <param name="reader">The JSON reader to check.</param>
    /// <exception cref="JsonException">Thrown when the JSON token is not a string.</exception>
    internal static void CheckString(in Utf8JsonReader reader)
    {
        if (reader.TokenType is not JsonTokenType.String)
        {
            throw new JsonException($"Expected string, got {reader.TokenType.ToString().ToLower()}.");
        }
    }

    /// <summary>
    /// Checks that the current JSON token is of type number.
    /// Throws a <see cref="JsonException"/> if the token is not a number.
    /// </summary>
    /// <param name="reader">The JSON reader to check.</param>
    /// <exception cref="JsonException">Thrown when the JSON token is not a number.</exception>
    public static void CheckNumber(in Utf8JsonReader reader)
    {
        if (reader.TokenType is not JsonTokenType.Number)
        {
            throw new JsonException($"Expected number, got {reader.TokenType.ToString().ToLower()}.");
        }
    }
}
