namespace CodeCrafters.Shell.Parser;

public partial class Tokenizer
{
    private enum State
    {
        Default,
        Whitespace,
        OpeningSingleQuote,
        InsideSingleQuote,
        SingleQuoteNotClosed,
        ClosingSingleQuote,
        Final,
    }
}