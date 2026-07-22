namespace CodeCrafters.Shell.Commands;

public class CdCommand : ICommand
{
    public ResultCode Execute(string command, string[] args)
    {
        var shell = Program.GetShellInstance();

        if (args.Length == 0)
        {
            Console.WriteLine("Error, no arguments");
            return ResultCode.Error;
        }
        
        shell.Cwd = args[0];
        
        return ResultCode.Success;
    }
}