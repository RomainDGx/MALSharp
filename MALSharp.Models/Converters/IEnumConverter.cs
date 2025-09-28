using System;

namespace MALSharp.Models.Converters;

public interface IEnumConverter<T> where T : struct, Enum
{
    static abstract T Parse(string? value);

    static abstract string Format(T value);
}
