namespace CodeCrafters.Shell.Commands;

public class ExitCommand : ICommand
{
    public ResultCode Execute(string command, string[] args)
    {
        return ResultCode.CleanExit;
    }
}