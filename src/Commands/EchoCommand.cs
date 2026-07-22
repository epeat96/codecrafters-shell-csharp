namespace CodeCrafters.Shell.Commands;

public class EchoCommand : ICommand
{

    public ResultCode Execute(string command, string[] args)
    {
        var output = string.Join(" ", args);
        Console.WriteLine(output);
        return ResultCode.Success;
    }
}