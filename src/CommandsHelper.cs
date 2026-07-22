using CodeCrafters.Shell.Commands;
namespace CodeCrafters.Shell;

public static class CommandsHelper
{
    public static ICommand? GetCommand(string command)
    {
        return command switch
        {
            "exit" => new ExitCommand(),
            "echo" => new EchoCommand(),
            "type"  => new TypeCommand(),
            _ => null,
        };
    }
    
    public static EvalCode  CommandNotFound(string command)
    {
        Console.WriteLine($"{command}: not found");
        return EvalCode.Success;
    }
}