namespace CodeCrafters.Shell;

public class Shell
{
    
    public void Run()
    {
        // TODO: Uncomment the code below to pass the first stage
        var command = "";
        string[] args;
        do
        {
            Console.Write("$ ");
            var userInput = Console.ReadLine()!.Split(' ');
            command = userInput.First();
            args = userInput
                .Where(arg => !string.IsNullOrWhiteSpace(arg))
                .Skip(1)
                .ToArray();
                
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