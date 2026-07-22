namespace CodeCrafters.Shell;

public static class PathHelper
{

    public static string? SearchPathForDir(string path)
    {
        if(!Directory.Exists(path))
        {
            return null;
        }
        return path;
    }
    public static string? SearchPathForCommand(string command)
    {
        var path = Environment.GetEnvironmentVariable("PATH") ?? "";
        var dirs = path.Split(Path.PathSeparator);

        foreach (var dir in dirs)
        {
            var testPath = Path.Combine(dir, command);
            if (Path.Exists(testPath) && File.Exists(testPath) &&  IsExecutable(testPath))
            {
                return  testPath; 
            }
        }
        return null;
    }

    public static bool IsExecutable(string path)
    {
        var permissions = File.GetUnixFileMode(path);
        return (permissions &  (UnixFileMode.GroupExecute | UnixFileMode.OtherExecute | UnixFileMode.UserExecute))!=0;
        
    }
    
}