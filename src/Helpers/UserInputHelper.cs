namespace CodeCrafters.Shell;

public static class UserInputHelper
{
    public static (string, string[]) Parse(string? input)
    {
        var command = "";
        var args = Array.Empty<string>();
        var split = input.Split(' ');
        command = split.First();
        args = split.Skip(1).ToArray();
        return (command, args);
    }
}