using CodeCrafters.Shell.Commands;
using System.IO;
using System;
namespace CodeCrafters.Shell;

public static class CommandsHelper
{
    public static ICommand? GetCommand(string command)
    {
        return command switch
        {
            "exit" => new ExitCommand(),
            "echo" => new EchoCommand(),
            "type"  => new TypeCommand(),
            _ => null,
        };
    }
    
    public static EvalCode  CommandNotFound(string command)
    {
        Console.WriteLine($"{command}: not found");
        return EvalCode.CommandNotFound;
    }

    public static string? SearchPathForCommand(string command, string[] args)
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

    public static bool IsExitCode(EvalCode code) => code switch
    {
        EvalCode.Success => false,
        EvalCode.CleanExit => true,
        EvalCode.CommandNotFound => false,
        _ => true
    };

}