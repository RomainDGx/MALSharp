namespace MALSharp.Client.TestUtils;

public enum FieldsTokenType
{
    None,
    /// <summary>
    /// <see cref="FieldsReader.Current"/> is a text.
    /// </summary>
    Field,
    OpenBracket,
    CloseBracket
}
