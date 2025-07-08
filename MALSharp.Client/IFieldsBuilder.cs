namespace MALSharp.Client;

internal interface IFieldsBuilder
{
    bool IsEmpty { get; }

    string Build(bool explicitFields);
}
