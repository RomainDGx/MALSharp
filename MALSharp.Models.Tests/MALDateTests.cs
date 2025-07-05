using MALSharp.Models.Shared;
using NUnit.Framework;
using System;

namespace MALSharp.Models.Tests;

[TestFixture]
public class MALDateTests
{
    [Test]
    public void Valid_year()
    {
        for (int year = 1; year <= 9999; year++)
        {
            var sut = new MALDate(year);
            Assert.That(sut.Year, Is.EqualTo(year));
            Assert.That(sut.Month, Is.Null);
            Assert.That(sut.Day, Is.Null);
        }
    }

    [TestCase(0)]
    [TestCase(10_000)]
    [TestCase(-1)]
    [TestCase(int.MinValue)]
    [TestCase(int.MaxValue)]
    public void Invaid_year(int year)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new MALDate(year));
    }

    [Test]
    public void Valid_month()
    {
        int year = 2025;
        for (int month = 1; month <= 12; month++)
        {
            var sut = new MALDate(year, month);
            Assert.That(sut.Year, Is.EqualTo(year));
            Assert.That(sut.Month, Is.EqualTo(month));
            Assert.That(sut.Day, Is.Null);
        }
    }

    [TestCase(2025, 0)]
    [TestCase(2025, 13)]
    [TestCase(2025, -1)]
    [TestCase(2025, int.MinValue)]
    [TestCase(2025, int.MaxValue)]
    public void Invalid_month(int year, int month)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new MALDate(year, month));
    }

    [Test]
    public void Valid_day()
    {
        int year = 2025;
        for (int month = 1; month <= 12; month++)
        {
            for (int day = 1; day <= DateTime.DaysInMonth(year, month); day++)
            {
                var sut = new MALDate(year, month, day);
                Assert.That(sut.Year, Is.EqualTo(year));
                Assert.That(sut.Month, Is.EqualTo(month));
                Assert.That(sut.Day, Is.EqualTo(day));
            }
        }
    }

    [TestCase(2025, 6, 0)]
    [TestCase(2025, 6, 32)]
    [TestCase(2025, 6, -1)]
    [TestCase(2025, 6, int.MinValue)]
    [TestCase(2025, 6, int.MaxValue)]
    public void Invalid_day(int year, int month, int day)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new MALDate(year, month, day));
    }

    [TestCase(2025, 6, 30)]
    [TestCase(1970, 1, 1)]
    [TestCase(1, 1, 1)]
    [TestCase(9999, 12, 31)]
    public void Create_from_DateOnly(int year, int month, int day)
    {
        var date = new DateOnly(year, month, day);
        var sut = new MALDate(date);
        Assert.That(sut.Year, Is.EqualTo(date.Year));
        Assert.That(sut.Month, Is.EqualTo(date.Month));
        Assert.That(sut.Day, Is.EqualTo(date.Day));
    }

    [TestCase(2025, 6, 30)]
    [TestCase(1970, 1, 1)]
    [TestCase(1, 1, 1)]
    [TestCase(9999, 12, 31)]
    public void Create_from_DateTime(int year, int month, int day)
    {
        var date = new DateTime(year, month, day);
        var sut = new MALDate(date);
        Assert.That(sut.Year, Is.EqualTo(date.Year));
        Assert.That(sut.Month, Is.EqualTo(date.Month));
        Assert.That(sut.Day, Is.EqualTo(date.Day));
    }

    [Test]
    public void Date_is_not_valid()
    {
        MALDate sut = default;
        Assert.That(sut.IsValid, Is.False);
        Assert.That(sut.Year, Is.Zero);
        Assert.That(sut.Month, Is.Null);
        Assert.That(sut.Day, Is.Null);
    }

    [TestCase(2025, 6, 30)]
    [TestCase(1970, 1, 1)]
    [TestCase(1, 1, 1)]
    [TestCase(9999, 12, 31)]
    public void Date_is_valid(int year, int? month, int? day)
    {
        var sut = CreateMALDate(year, month, day);
        Assert.That(sut.IsValid, Is.True);
        Assert.That(sut.Year, Is.EqualTo(year));
        Assert.That(sut.Month, Is.EqualTo(month));
        Assert.That(sut.Day, Is.EqualTo(day));
    }

    [TestCase(2025, 6, 30, true)]
    [TestCase(2025, 6, null, false)]
    [TestCase(2025, null, null, false)]
    public void Date_is_fully_specified(int year, int? month, int? day, bool isFullySpecified)
    {
        Assert.That(CreateMALDate(year, month, day).IsFullySpecified, Is.EqualTo(isFullySpecified));
    }

    [TestCase("2025", 2025, null, null)]
    [TestCase("2025-06", 2025, 6, null)]
    [TestCase("2025-06-30", 2025, 6, 30)]
    [TestCase("1970-01-01", 1970, 1, 1)]
    [TestCase("0001-01-01", 1, 1, 1)]
    [TestCase("9999-12-31", 9999, 12, 31)]
    public void Can_try_parse(string value, int year, int? month, int? day)
    {
        Assert.That(MALDate.TryParse(value, out var sut), Is.True);
        Assert.That(sut.Year, Is.EqualTo(year));
        Assert.That(sut.Month, Is.EqualTo(month));
        Assert.That(sut.Day, Is.EqualTo(day));
    }

    [TestCase("")]
    [TestCase("0")]
    [TestCase("0000")]
    [TestCase("2025-00")]
    [TestCase("2025-13")]
    [TestCase("2025-06-00")]
    [TestCase("2025-06-32")]
    [TestCase("2025-13-30")]
    [TestCase("20250630")]
    [TestCase("2025 06 30")]
    [TestCase("test")]
    [TestCase(null)]
    [TestCase("30-06-2025")]
    [TestCase("          ")]
    [TestCase("2025-06-31")] // Month of 30 days.
    public void Cannot_tryparse(string? value)
    {
        Assert.That(MALDate.TryParse(value!, out var sut), Is.False);
        Assert.That(sut, Is.Default);
    }

    [TestCase("2025", 2025, null, null)]
    [TestCase("2025-06", 2025, 6, null)]
    [TestCase("2025-06-30", 2025, 6, 30)]
    [TestCase("1970-01-01", 1970, 1, 1)]
    [TestCase("0001-01-01", 1, 1, 1)]
    [TestCase("9999-12-31", 9999, 12, 31)]
    public void Can_parse(string value, int year, int? month, int? day)
    {
        var sut = MALDate.Parse(value);
        Assert.That(sut.Year, Is.EqualTo(year));
        Assert.That(sut.Month, Is.EqualTo(month));
        Assert.That(sut.Day, Is.EqualTo(day));
    }

    [TestCase("")]
    [TestCase("0")]
    [TestCase("0000")]
    [TestCase("2025-00")]
    [TestCase("2025-13")]
    [TestCase("2025-06-00")]
    [TestCase("2025-06-32")]
    [TestCase("2025-13-30")]
    [TestCase("20250630")]
    [TestCase("2025 06 30")]
    [TestCase("test")]
    [TestCase(null)]
    [TestCase("30-06-2025")]
    [TestCase("          ")]
    [TestCase("2025-06-31")] // Month of 30 days.
    public void Cannot_parse(string? value)
    {
        Assert.Throws<FormatException>(() => MALDate.Parse(value!));
    }

    [TestCase(2025, 6, 30, 6, 30)]
    [TestCase(1, 1, 1, 1, 1)]
    [TestCase(9999, 12, 31, 12, 31)]
    [TestCase(2025, null, null, 1, 1)]
    [TestCase(2025, 6, null, 6, 1)]
    public void Explicit_MALDate_to_DateOnly(int year, int? month, int? day, int dateOnlyMonth, int dateOnlyDay)
    {
        var date = CreateMALDate(year, month, day);
        Assert.That(date.Year, Is.EqualTo(year));
        Assert.That(date.Month, Is.EqualTo(month));
        Assert.That(date.Day, Is.EqualTo(day));
        Assert.That(date.IsValid, Is.True);
        var sut = (DateOnly)date;
        Assert.That(sut.Year, Is.EqualTo(year));
        Assert.That(sut.Month, Is.EqualTo(dateOnlyMonth));
        Assert.That(sut.Day, Is.EqualTo(dateOnlyDay));
        sut = date.ToDateOnly();
        Assert.That(sut.Year, Is.EqualTo(year));
        Assert.That(sut.Month, Is.EqualTo(dateOnlyMonth));
        Assert.That(sut.Day, Is.EqualTo(dateOnlyDay));
    }

    [TestCase(2025, 6, 30)]
    [TestCase(1, 1, 1)]
    [TestCase(9999, 12, 31)]
    public void Explicit_DateOnly_to_MALDate(int year, int month, int day)
    {
        var date = new DateOnly(year, month, day);
        var sut = (MALDate)date;
        Assert.That(sut.Year, Is.EqualTo(date.Year).And.EqualTo(year));
        Assert.That(sut.Month, Is.EqualTo(date.Month).And.EqualTo(month));
        Assert.That(sut.Day, Is.EqualTo(date.Day).And.EqualTo(day));
        Assert.That(sut.IsValid, Is.True);
    }

    [TestCase(2025, 6, 30, 6, 30)]
    [TestCase(1, 1, 1, 1, 1)]
    [TestCase(9999, 12, 31, 12, 31)]
    [TestCase(2025, null, null, 1, 1)]
    [TestCase(2025, 6, null, 6, 1)]
    public void Try_to_DateOnly_success(int year, int? month, int? day, int dateOnlyMonth, int dateOnlyDay)
    {
        var date = CreateMALDate(year, month, day);
        Assert.That(date.Year, Is.EqualTo(year));
        Assert.That(date.Month, Is.EqualTo(month));
        Assert.That(date.Day, Is.EqualTo(day));
        Assert.That(date.IsValid, Is.True);
        Assert.That(date.TryToDateOnly(out var sut), Is.True);
        Assert.That(sut.Year, Is.EqualTo(year));
        Assert.That(sut.Month, Is.EqualTo(dateOnlyMonth));
        Assert.That(sut.Day, Is.EqualTo(dateOnlyDay));
    }

    [Test]
    public void Try_to_DateTimeOnly_fail()
    {
        MALDate date = default;
        Assert.That(date.TryToDateOnly(out var sut), Is.False);
        Assert.That(sut, Is.Default);
    }

    [TestCase(2025, 6, 30, 6, 30)]
    [TestCase(1, 1, 1, 1, 1)]
    [TestCase(9999, 12, 31, 12, 31)]
    [TestCase(2025, null, null, 1, 1)]
    [TestCase(2025, 6, null, 6, 1)]
    public void Explicit_MALDate_to_DateTime(int year, int? month, int? day, int dateOnlyMonth, int dateOnlyDay)
    {
        var date = CreateMALDate(year, month, day);
        Assert.That(date.Year, Is.EqualTo(year));
        Assert.That(date.Month, Is.EqualTo(month));
        Assert.That(date.Day, Is.EqualTo(day));
        Assert.That(date.IsValid, Is.True);
        var sut = (DateTime)date;
        Assert.That(sut.Year, Is.EqualTo(year));
        Assert.That(sut.Month, Is.EqualTo(dateOnlyMonth));
        Assert.That(sut.Day, Is.EqualTo(dateOnlyDay));
        Assert.That(sut.Hour, Is.Zero);
        Assert.That(sut.Minute, Is.Zero);
        Assert.That(sut.Second, Is.Zero);
        sut = date.ToDateTime();
        Assert.That(sut.Year, Is.EqualTo(year));
        Assert.That(sut.Month, Is.EqualTo(dateOnlyMonth));
        Assert.That(sut.Day, Is.EqualTo(dateOnlyDay));
        Assert.That(sut.Hour, Is.Zero);
        Assert.That(sut.Minute, Is.Zero);
        Assert.That(sut.Second, Is.Zero);
    }

    [TestCase(2025, 6, 30)]
    [TestCase(1, 1, 1)]
    [TestCase(9999, 12, 31)]
    public void Explicit_DateTime_to_MALDate(int year, int month, int day)
    {
        var date = new DateTime(year, month, day);
        var sut = (MALDate)date;
        Assert.That(sut.Year, Is.EqualTo(date.Year).And.EqualTo(year));
        Assert.That(sut.Month, Is.EqualTo(date.Month).And.EqualTo(month));
        Assert.That(sut.Day, Is.EqualTo(date.Day).And.EqualTo(day));
        Assert.That(sut.IsValid, Is.True);
    }

    [TestCase(2024, null, null, 2025, null, null, -1)]
    [TestCase(2025, null, null, 2025, null, null, 0)]
    [TestCase(2025, null, null, 2024, null, null, 1)]
    [TestCase(2025, null, null, 2025, 1, null, -1)]
    [TestCase(2025, 1, null, 2025, null, null, 1)]
    [TestCase(2025, 1, null, 2025, 2, null, -1)]
    [TestCase(2025, 1, null, 2025, 1, null, 0)]
    [TestCase(2025, 2, null, 2025, 1, null, 1)]
    [TestCase(2025, 1, null, 2025, 1, 1, -1)]
    [TestCase(2025, 1, 1, 2025, 1, null, 1)]
    [TestCase(2025, 1, 1, 2025, 1, 2, -1)]
    [TestCase(2025, 1, 1, 2025, 1, 1, 0)]
    [TestCase(2025, 1, 2, 2025, 1, 1, 1)]
    [TestCase(2025, null, null, 2025, 1, 1, -1)]
    [TestCase(2025, 1, 1, 2025, null, null, 1)]
    public void Compare_operators(int year1, int? month1, int? day1, int year2, int? month2, int? day2, int result)
    {
        var date1 = CreateMALDate(year1, month1, day1);
        var date2 = CreateMALDate(year2, month2, day2);

        Assert.That(date1.CompareTo(date2), Is.EqualTo(result));
        Assert.That(date1 < date2, Is.EqualTo(result == -1));
        Assert.That(date1 > date2, Is.EqualTo(result == 1));
        Assert.That(date1 <= date2, Is.EqualTo(result <= 0));
        Assert.That(date1 >= date2, Is.EqualTo(result >= 0));
        Assert.That(date1 == date2, Is.EqualTo(result == 0));
        Assert.That(date1 != date2, Is.EqualTo(result != 0));
        Assert.That(date1.Equals(date2), Is.EqualTo(result == 0));
        if (month2.HasValue && day2.HasValue)
        {
            Assert.That(date1.Equals(new DateOnly(year2, month2.Value, day2.Value)), Is.EqualTo(result == 0));
            Assert.That(date1.Equals(new DateTime(year2, month2.Value, day2.Value)), Is.EqualTo(result == 0));
        }
    }

    [TestCase(2025, 6, 30, null)]
    [TestCase(2025, 6, 30, "")]
    [TestCase(2025, 6, 30, "2025-06-30")]
    [TestCase(2025, 6, 30, 1)]
    public void Equals_with_incompatible_object(int year, int? month, int? day, object? obj)
    {
        Assert.That(CreateMALDate(year, month, day).Equals(obj), Is.False);
    }

    [TestCase(2025, 6, 30, 2025, 6, 30, true)]
    [TestCase(2025, 6, 30, 2025, 7, 1, false)]
    [TestCase(2025, 6, null, 2025, 6, 30, false)]
    [TestCase(2025, null, null, 2025, 6, 30, false)]
    [TestCase(2025, null, null, 2025, 6, 30, false)]
    public void Equals_with_compatible_object(int year1, int? month1, int? day1, int year2, int month2, int day2, bool result)
    {
        var sut = CreateMALDate(year1, month1, day1);
        object obj = CreateMALDate(year2, month2, day2);
        Assert.That(sut.Equals(obj), Is.EqualTo(result));
        obj = new DateOnly(year2, month2, day2);
        Assert.That(sut.Equals(obj), Is.EqualTo(result));
        obj = new DateTime(year2, month2, day2);
        Assert.That(sut.Equals(obj), Is.EqualTo(result));
    }

    [TestCase(2025, 6, 30, "2025-06-30")]
    [TestCase(2025, 6, null, "2025-06")]
    [TestCase(2025, null, null, "2025")]
    [TestCase(1, 1, 1, "0001-01-01")]
    [TestCase(9999, 12, 30, "9999-12-30")]
    public void To_string(int year, int? month, int? day, string result)
    {
        Assert.That(CreateMALDate(year, month, day).ToString(), Is.EqualTo(result));
    }

    static MALDate CreateMALDate(int year, int? month, int? day)
    {
        if (month.HasValue)
        {
            if (day.HasValue)
            {
                return new MALDate(year, month.Value, day.Value);
            }
            return new MALDate(year, month.Value);
        }
        return new MALDate(year);
    }
}
