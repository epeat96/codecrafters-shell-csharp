using System;
using System.IO;
namespace CodeCrafters.Shell;

public class Shell
{
   
    public string Cwd { get; set; } = Directory.GetCurrentDirectory();
    
    public void Run()
    {
        // TODO: Uncomment the code below to pass the first stage
        var command = "";
        string[] args;
        do
        {
            Console.Write("$ ");
            (command,args) = UserInputHelper.Parse(Console.ReadLine());
        }while(!EvalHelper.IsExitCode(Eval(command,args)));
    }

    static ResultCode Eval(string command, string[] args)
    {
        var routerResult = CommandsHelper.GetCommand(command);
        if (routerResult is null)
        {
            var binary = PathHelper.SearchPathForCommand(command);
            if (binary is not null)
            {
               return ExecutableHelper.Execute(command, args);
            }
            return CommandsHelper.CommandNotFound(command);
        }
        
        return routerResult.Execute(command, args);
    }

}