using System;

namespace MALSharp.Client.TestUtils;

public ref struct FieldsReader
{
    readonly ReadOnlySpan<char> _fields;
    int _start;
    int _current;
    FieldsTokenType _tokenType;
    int _deep;

    public FieldsReader(ReadOnlySpan<char> fields)
    {
        _fields = fields;
        _start = 0;
        _current = 0;
        _tokenType = FieldsTokenType.None;
        _deep = 0;
    }

    public readonly FieldsTokenType TokenType => _tokenType;

    public readonly ReadOnlySpan<char> Current => _fields[_start.._current];

    public readonly int Deep => _deep;

    public bool Read()
    {
        if (_current > 0 && _current < _fields.Length)
        {
            switch (_fields[_current])
            {
                case ',':
                    _start = ++_current;
                    break;
                case '{':
                    if (_tokenType is not FieldsTokenType.Field)
                    {
                        throw new InvalidOperationException();
                    }
                    _tokenType = FieldsTokenType.OpenBracket;
                    _start = _current++;
                    _deep++;
                    return true;
                case '}':
                    if (--_deep < 0)
                    {
                        throw new InvalidOperationException();
                    }
                    _tokenType = FieldsTokenType.CloseBracket;
                    _start = _current++;
                    return true;
                default:
                    _start = _current;
                    break;
            }
        }
        else
        {
            _start = _current;
        }
        while (_current < _fields.Length)
        {
            if (_fields[_current] is ',')
            {
                if (_tokenType is FieldsTokenType.None or FieldsTokenType.OpenBracket)
                {
                    throw new InvalidOperationException();
                }
                if (_fields[_current - 1] is ',')
                {
                    throw new InvalidOperationException();
                }
                return true;
            }
            if (_fields[_current] is '{')
            {
                if (_tokenType is not FieldsTokenType.Field)
                {
                    throw new InvalidOperationException();
                }
                if (_fields[_current - 1] is ',')
                {
                    throw new InvalidOperationException();
                }
                return true;
            }
            if (_fields[_current] is '}')
            {
                if (_tokenType is not FieldsTokenType.Field)
                {
                    throw new InvalidOperationException();
                }
                if (_fields[_current - 1] is ',')
                {
                    throw new InvalidOperationException();
                }
                return true;
            }
            else
            {
                _tokenType = FieldsTokenType.Field;
                _current++;
            }
        }
        if (_start == _current)
        {
            _tokenType = FieldsTokenType.None;
        }
        if (_deep != 0)
        {
            throw new InvalidOperationException();
        }
        return _start < _current;
    }
}
