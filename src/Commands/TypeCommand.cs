namespace CodeCrafters.Shell.Commands;

public class TypeCommand : ICommand
{
    public EvalCode Execute(string command, string[] args)
    {
        var typedCommand = args.First();
        var searchResult = CommandsHelper.GetCommand(typedCommand);
        if (searchResult is null)
        {
            var pathSearchResult = CommandsHelper.SearchPathForCommand(typedCommand, args);
            if (pathSearchResult is null)
            {
                return CommandsHelper.CommandNotFound(typedCommand);
            }
            Console.WriteLine($"{typedCommand} is {pathSearchResult}");

            return EvalCode.Success;
        }
        
        Console.WriteLine($"{typedCommand} is a shell builtin");
        return EvalCode.Success;
    }
}