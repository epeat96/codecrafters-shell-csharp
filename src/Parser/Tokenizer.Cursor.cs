namespace CodeCrafters.Shell.Parser;

public partial class Tokenizer
{
    private class Cursor(string input)
    {
        private int CurrentIndex { get; set; } = 0;

        public bool Next()
        {
            if (CurrentIndex >= input.Length - 1)
            {
                return false;
            }

            CurrentIndex++;
            return true;
        }

        public char? Current => string.IsNullOrWhiteSpace(input) ? null : input[CurrentIndex];
    }
}