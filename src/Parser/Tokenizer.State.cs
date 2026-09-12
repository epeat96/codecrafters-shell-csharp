namespace CodeCrafters.Shell.Parser;

public partial class Tokenizer
{
    private enum State
    {
        Default,
        DefaultBackslash,
        Whitespace,
        OpeningSingleQuote,
        InsideSingleQuote,
        SingleQuoteNotClosed,
        ClosingSingleQuote,
        OpeningDoubleQuote,
        InsideDoubleQuote,
        DoubleQuoteNotClosed,
        ClosingDoubleQuote,
        Final,
    }
}