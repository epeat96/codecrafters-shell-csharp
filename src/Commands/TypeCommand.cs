namespace CodeCrafters.Shell.Commands;

public class TypeCommand : ICommand
{
    public ResultCode Execute(string command, string[] args)
    {
        var typedCommand = args.First();
        var searchResult = CommandsHelper.GetCommand(typedCommand);
        if (searchResult is null)
        {
            var pathSearchResult = PathHelper.SearchPathForCommand(typedCommand);
            if (pathSearchResult is null)
            {
                return CommandsHelper.CommandNotFound(typedCommand);
            }
            Console.WriteLine($"{typedCommand} is {pathSearchResult}");

            return ResultCode.Success;
        }
        
        Console.WriteLine($"{typedCommand} is a shell builtin");
        return ResultCode.Success;
    }
}