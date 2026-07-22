namespace CodeCrafters.Shell.Commands;

public class TypeCommand : ICommand
{
    public EvalCode Execute(string command, string[] args)
    {
        var verifiedCommand = args.First();
        var searchResult = CommandsHelper.GetCommand(verifiedCommand);
        if (searchResult is null)
        {
            return CommandsHelper.CommandNotFound(verifiedCommand);
        }
        
        Console.WriteLine($"{verifiedCommand} is a shell builtin");
        return EvalCode.Success;
    }
}