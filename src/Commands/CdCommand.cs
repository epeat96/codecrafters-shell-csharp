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
        
        var pathToSearch = (args[0] == "~" ? Environment.GetEnvironmentVariable("HOME") : args[0]) ?? "";
        
        var path = PathHelper.SearchPathForDir(pathToSearch);
        if (path == null)
        {
            Console.WriteLine($"cd: {args[0]}: No such file or directory");
            return ResultCode.Error;
        }
        
        shell.Cwd = Path.TrimEndingDirectorySeparator(Path.GetFullPath(path, shell.Cwd));
        
        return ResultCode.Success;
    }
}