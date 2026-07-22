namespace CodeCrafters.Shell.Commands;

public class CdCommand : ICommand
{
    public ResultCode Execute(string command, string[] args)
    {
        var shell = Program.GetShellInstance();

        if (args.Length == 0)
        {
            Console.WriteLine("cd: Error, no arguments");
            return ResultCode.Error;
        }
        
        var path = PathHelper.SearchPathForDir(args[0]);
        if (path == null)
        {
            Console.WriteLine($"cd: {args[0]}: No such file or directory");
            return ResultCode.Error;
        }
        
        shell.Cwd = args[0];
        
        return ResultCode.Success;
    }
}