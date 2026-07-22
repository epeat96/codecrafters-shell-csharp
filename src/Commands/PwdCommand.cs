namespace CodeCrafters.Shell.Commands;

public class PwdCommand : ICommand
{
    public ResultCode Execute(string command, string[] args)
    {
        Console.WriteLine(Program.GetShellInstance().Cwd);
        return ResultCode.Success;
    }
}