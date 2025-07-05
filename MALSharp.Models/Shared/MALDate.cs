using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace MALSharp.Models.Shared;

/// <summary>
/// Represents a date that can be partial (year-only, year-month, or full year-month-day).
/// A <see cref="MALDate"/> always requires a valid year (1–9999) when constructed.
/// The default value (Year = 0) is considered invalid and will throw if converted explicitly to <see cref="DateOnly"/> or <see cref="DateTime"/>.
/// Use <see cref="IsValid"/> to check validity before conversion.
/// </summary>
public readonly struct MALDate : IComparable<MALDate>, IEquatable<MALDate>, IEquatable<DateOnly>, IEquatable<DateTime>
{
    public readonly int Year;
    public readonly int? Month;
    public readonly int? Day;

    public MALDate(int year)
    {
        if (year is < 1 or > 9999)
        {
            throw new ArgumentOutOfRangeException(nameof(year));
        }
        Year = year;
    }

    public MALDate(int year, int month)
        : this(year)
    {
        if (month is < 1 or > 12)
        {
            throw new ArgumentOutOfRangeException(nameof(month));
        }
        Month = month;
    }

    public MALDate(int year, int month, int day)
        : this(year, month)
    {
        if (day < 1 || day > DateTime.DaysInMonth(year, month))
        {
            throw new ArgumentOutOfRangeException(nameof(day));
        }
        Day = day;
    }

    /// <summary>
    /// Initializes a new <see cref="MALDate"/> from a <see cref="DateOnly"/>.
    /// The resulting <see cref="MALDate"/> is fully specified with year, month, and day.
    /// </summary>
    /// <param name="date">The <see cref="DateOnly"/> to convert.</param>
    public MALDate(DateOnly date)
    {
        Year = date.Year;
        Month = date.Month;
        Day = date.Day;
    }

    /// <summary>
    /// Initializes a new <see cref="MALDate"/> from a <see cref="DateTime"/>.
    /// The resulting <see cref="MALDate"/> is fully specified with year, month, and day.
    /// </summary>
    /// <param name="date">The <see cref="DateTime"/> to convert.</param>
    public MALDate(DateTime date)
    {
        Year = date.Year;
        Month = date.Month;
        Day = date.Day;
    }

    /// <summary>
    /// Indicates whether this <see cref="MALDate"/> instance has a valid year.
    /// </summary>
    public bool IsValid => Year >= 1;

    /// <summary>
    /// Indicates whether this <see cref="MALDate"/> instance has both <see cref="Month"/> and <see cref="Day"/> specified,
    /// meaning the date is fully defined as a year-month-day.
    /// </summary>
    public bool IsFullySpecified => Month.HasValue && Day.HasValue;

    /// <summary>
    /// Attempts to parse a string in the formats "yyyy", "yyyy-MM", or "yyyy-MM-dd" into a <see cref="MALDate"/>.
    /// </summary>
    /// <param name="value">The date string to parse.</param>
    /// <param name="date">
    /// When this method returns, contains the parsed <see cref="MALDate"/> if parsing succeeded, or <c>default</c> if parsing failed.
    /// </param>
    /// <returns>
    /// <c>true</c> if the input string was successfully parsed; otherwise, <c>false</c>.
    /// </returns>
    public static bool TryParse([NotNullWhen(true)] string? value, out MALDate date)
    {
        date = default;
        if (value is not null)
        {
            if (value.Length is 4 && int.TryParse(value, out var year) && year > 0)
            {
                date = new MALDate(year);
            }
            else if (value.Length is 7 && DateOnly.TryParseExact(value, "yyyy-MM", null, DateTimeStyles.None, out var dateOnly))
            {
                date = new MALDate(dateOnly.Year, dateOnly.Month);
            }
            else if (value.Length is 10 && DateOnly.TryParseExact(value, "yyyy-MM-dd", null, DateTimeStyles.None, out dateOnly))
            {
                date = new MALDate(dateOnly);
            }
        }
        return date != default;
    }

    /// <summary>
    /// Parses a string in the formats "yyyy", "yyyy-MM", or "yyyy-MM-dd" into a <see cref="MALDate"/>.
    /// Throws <see cref="FormatException"/> if the input does not match any valid format.
    /// </summary>
    /// <param name="value">The date string to parse.</param>
    /// <returns>A <see cref="MALDate"/> with the parsed values.</returns>
    /// <exception cref="FormatException">Thrown if the format is invalid.</exception>
    public static MALDate Parse(string value)
    {
        if (TryParse(value, out var date))
        {
            return date;
        }
        throw new FormatException($"Input string '{value}' was not in a recognized format.");
    }

    /// <summary>
    /// Explicitly converts a <see cref="MALDate"/> to a <see cref="DateOnly"/>.
    /// If the <see cref="MALDate"/> is partial (missing month or day),
    /// missing components are defaulted to 1.
    /// This matches the behavior of <see cref="DateOnly.TryParse"/>.
    /// Throws <see cref="InvalidOperationException"/> if <see cref="Year"/> is zero.
    /// </summary>
    public static explicit operator DateOnly(MALDate date)
    {
        if (!date.IsValid)
        {
            throw new InvalidOperationException("Cannot convert a default MALDate to DateOnly. Year must be >= 1.");
        }
        return new(date.Year, date.Month ?? 1, date.Day ?? 1);
    }

    public static explicit operator MALDate(DateOnly date) => new(date);

    public DateOnly ToDateOnly() => (DateOnly)this;

    /// <summary>
    /// Attempts to convert this <see cref="MALDate"/> to a <see cref="DateOnly"/>.
    /// Returns false if the date is invalid (Year < 1).
    /// Missing month or day are defaulted to 1.
    /// </summary>
    public bool TryToDateOnly(out DateOnly date)
    {
        if (!IsValid)
        {
            date = default;
            return false;
        }
        date = new DateOnly(Year, Month ?? 1, Day ?? 1);
        return true;
    }

    /// <summary>
    /// Explicitly converts a <see cref="MALDate"/> to a <see cref="DateTime"/>.
    /// If the <see cref="MALDate"/> is partial (missing month or day),
    /// missing components are defaulted to 1,
    /// consistent with <see cref="DateTime.TryParse"/> behavior.
    /// Throws <see cref="InvalidOperationException"/> if <see cref="Year"/> is zero.
    /// </summary>
    public static explicit operator DateTime(MALDate date)
    {
        if (!date.IsValid)
        {
            throw new InvalidOperationException("Cannot convert a default MALDate to DateTime. Year must be >= 1.");
        }
        return new(date.Year, date.Month ?? 1, date.Day ?? 1);
    }

    public static explicit operator MALDate(DateTime date) => new(date);

    public DateTime ToDateTime() => (DateTime)this;

    public int CompareTo(MALDate other)
    {
        int yearComparison = Year.CompareTo(other.Year);
        if (yearComparison != 0)
        {
            return yearComparison;
        }
        int monthComparison = Nullable.Compare(Month, other.Month);
        if (monthComparison != 0)
        {
            return monthComparison;
        }
        return Nullable.Compare(Day, other.Day);
    }

    public static bool operator <(MALDate left, MALDate right) => left.CompareTo(right) < 0;

    public static bool operator >(MALDate left, MALDate right) => left.CompareTo(right) > 0;

    public static bool operator <=(MALDate left, MALDate right) => left.CompareTo(right) <= 0;

    public static bool operator >=(MALDate left, MALDate right) => left.CompareTo(right) >= 0;

    public static bool operator ==(MALDate left, MALDate right) => left.Equals(right);

    public static bool operator !=(MALDate left, MALDate right) => !left.Equals(right);

    public bool Equals(MALDate other) => Year == other.Year && Month == other.Month && Day == other.Day;

    public bool Equals(DateOnly other) => Year == other.Year && Month == other.Month && Day == other.Day;

    public bool Equals(DateTime other) => Year == other.Year && Month == other.Month && Day == other.Day && other.TimeOfDay == TimeSpan.Zero;

    public override bool Equals([NotNullWhen(true)] object? obj) => obj switch
    {
        MALDate other => Equals(other),
        DateOnly other => Equals(other),
        DateTime other => Equals(other),
        _ => false
    };

    public override string ToString()
    {
        if (!Month.HasValue)
        {
            return $"{Year:0000}";
        }
        if (!Day.HasValue)
        {
            return $"{Year:0000}-{Month:00}";
        }
        return $"{Year:0000}-{Month:00}-{Day:00}";
    }

    public override int GetHashCode() => HashCode.Combine(Year, Month, Day);
}
