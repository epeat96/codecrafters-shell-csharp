namespace CodeCrafters.Shell.Commands;

public class PwdCommand : ICommand
{
    public ResultCode Execute(string command, string[] args)
    {
        var shell = Program.GetShellInstance();
        var currentDirectory = shell.Cwd;
        Console.WriteLine(currentDirectory);
        return ResultCode.Success;
    }
}