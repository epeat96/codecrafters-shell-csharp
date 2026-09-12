namespace CodeCrafters.Shell.Commands;

public class EchoCommand : ICommand
{
    public ResultCode Execute(string command, string[] args)
    {
        if (args.Length == 1)
        {
            Console.WriteLine(args[0]);
            return ResultCode.Success;
        }

        var output = string.Join(" ", args);
        Console.WriteLine(output);
        return ResultCode.Success;
    }
}