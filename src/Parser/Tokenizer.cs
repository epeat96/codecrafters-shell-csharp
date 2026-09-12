using System.Linq.Expressions;
using System.Text;

namespace CodeCrafters.Shell.Parser;

public partial class Tokenizer(string input)
{
    private readonly Cursor _cursor = new(input);
    private State _state = State.Default;
    private readonly List<string> _tokens = new();

    public List<string> Tokenize()
    {
        var buff = new StringBuilder();
        while (_cursor.Current is char c)
        {
            if (_state == State.Final)
            {
                SaveToken();
                break;
            }

            _state = Transition(c);
            switch (_state)
            {
                case State.Default:
                case State.InsideSingleQuote:
                    buff.Append(c);
                    break;
                case State.Whitespace:
                    SaveToken();
                    break;
            }

            if (!_cursor.Next())
            {
                SaveToken();
                break;
            }
        }

        return _tokens;

        void SaveToken()
        {
            var token = buff.ToString();
            buff.Clear();
            if (!string.IsNullOrWhiteSpace(token))
            {
                _tokens.Add(token);
            }
        }
    }

    private State Transition(char? symbol) => _state switch
    {
        State.OpeningSingleQuote => OpeningSingleQuoteTransition(symbol),
        State.InsideSingleQuote => InsideSingleQuoteTransition(symbol),
        _ => DefaultTransition(symbol)
    };

    private State DefaultTransition(char? symbol)
    {
        if (symbol is not char c)
        {
            return State.Final;
        }

        if (char.IsWhiteSpace(c))
        {
            return State.Whitespace;
        }

        return c switch
        {
            '\'' => State.OpeningSingleQuote,
            _ => State.Default
        };
    }

    private State InsideSingleQuoteTransition(char? symbol)
    {
        if (symbol is not char c)
        {
            return State.SingleQuoteNotClosed;
        }

        return c switch
        {
            '\'' => State.ClosingSingleQuote,
            _ => State.InsideSingleQuote
        };
    }

    private State OpeningSingleQuoteTransition(char? symbol)
    {
        if (symbol is not char c)
        {
            return State.SingleQuoteNotClosed;
        }

        return c switch
        {
            '\'' => State.ClosingSingleQuote,
            _ => State.InsideSingleQuote
        };
    }
}