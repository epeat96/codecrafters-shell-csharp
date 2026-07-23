namespace CodeCrafters.Shell;

public static class UserInputHelper
{
    public static (string, string[]) Parse(string? input)
    {
        var command = "";
        var args = Array.Empty<string>();
        return (command, args);
    }
}