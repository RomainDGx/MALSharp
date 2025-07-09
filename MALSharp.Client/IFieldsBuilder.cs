namespace MALSharp.Client;

internal interface IFieldsBuilder
{
    internal bool IsEmpty { get; }

    internal string Build(bool explicitFields);
}
