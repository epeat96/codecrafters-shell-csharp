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
            "pwd" => new PwdCommand(),
            _ => null,
        };
    }
    
    public static ResultCode CommandNotFound(string command)
    {
        Console.WriteLine($"{command}: not found");
        return ResultCode.CommandNotFound;
    }



}