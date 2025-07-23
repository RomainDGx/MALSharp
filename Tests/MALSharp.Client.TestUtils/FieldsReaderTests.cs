using NUnit.Framework;
using System;
using System.Linq;

namespace MALSharp.Client.TestUtils;

[TestFixture]
public class FieldsReaderTests
{
    [TestCase("")]
    [TestCase("a", FieldsTokenType.Field)]
    [TestCase("a,b,c", FieldsTokenType.Field, FieldsTokenType.Field, FieldsTokenType.Field)]
    [TestCase("a{b}", FieldsTokenType.Field, FieldsTokenType.OpenBracket, FieldsTokenType.Field, FieldsTokenType.CloseBracket)]
    [TestCase("a{b},c", FieldsTokenType.Field, FieldsTokenType.OpenBracket, FieldsTokenType.Field, FieldsTokenType.CloseBracket, FieldsTokenType.Field)]
    [TestCase("a{b,c}", FieldsTokenType.Field, FieldsTokenType.OpenBracket, FieldsTokenType.Field, FieldsTokenType.Field, FieldsTokenType.CloseBracket)]
    [TestCase("a{b,c{d},e},f", FieldsTokenType.Field, FieldsTokenType.OpenBracket, FieldsTokenType.Field, FieldsTokenType.Field, FieldsTokenType.OpenBracket, FieldsTokenType.Field, FieldsTokenType.CloseBracket, FieldsTokenType.Field, FieldsTokenType.CloseBracket, FieldsTokenType.Field)]
    [TestCase("a{b{c{d{e}}}}", FieldsTokenType.Field, FieldsTokenType.OpenBracket, FieldsTokenType.Field, FieldsTokenType.OpenBracket, FieldsTokenType.Field, FieldsTokenType.OpenBracket, FieldsTokenType.Field, FieldsTokenType.OpenBracket, FieldsTokenType.Field, FieldsTokenType.CloseBracket, FieldsTokenType.CloseBracket, FieldsTokenType.CloseBracket, FieldsTokenType.CloseBracket)]
    public void Can_parse(string fields, params FieldsTokenType[] tokens)
    {
        var tokensValuesEnumerator = fields.ToCharArray().Where(c => c != ',').GetEnumerator();
        var tokenEnumerator = tokens.GetEnumerator();

        var parser = new FieldsReader(fields);
        while (parser.Read())
        {
            Assert.That(tokensValuesEnumerator.MoveNext(), Is.True);
            Assert.That(parser.Current.ToString(), Is.EqualTo(tokensValuesEnumerator.Current.ToString()));
            Assert.That(tokenEnumerator.MoveNext(), Is.True);
            Assert.That(parser.TokenType, Is.EqualTo(tokenEnumerator.Current));
        }
        Assert.That(tokensValuesEnumerator.MoveNext(), Is.False);
        Assert.That(tokenEnumerator.MoveNext(), Is.False);
        Assert.That(parser.TokenType, Is.EqualTo(FieldsTokenType.None));
    }

    [TestCase(",")]
    [TestCase("{")]
    [TestCase("}")]
    [TestCase("a{{")]
    [TestCase("a{b}}")]
    [TestCase("a{")]
    [TestCase("a{,")]
    [TestCase("a,{")]
    [TestCase("a,,")]
    [TestCase("a{b,}")]
    [TestCase("a{b},c}")]
    public void Should_throw(string fields)
    {
        Assert.Throws<InvalidOperationException>(() =>
        {
            var parser = new FieldsReader(fields);
            while (parser.Read()) ;
        });
    }

    [Test]
    public void Reread_end_not_throw()
    {
        var reader = new FieldsReader("a");
        Assert.That(reader.TokenType, Is.EqualTo(FieldsTokenType.None));

        reader.Read();
        Assert.That(reader.TokenType, Is.EqualTo(FieldsTokenType.Field));

        for (int i = 0; i < 10; i++)
        {
            reader.Read();
            Assert.That(reader.TokenType, Is.EqualTo(FieldsTokenType.None));
        }
    }
}