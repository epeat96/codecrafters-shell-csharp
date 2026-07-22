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
            args = userInput.Skip(1).ToArray();
                
        }while(Eval(command,args).Equals(EvalCode.Success));
    }

    static EvalCode Eval(string command, string[] args)
    {
        var routerResult = CommandsHelper.GetCommand(command);
        if (routerResult is null)
        {
            return CommandsHelper.CommandNotFound(command);
        }
        
        return routerResult.Execute(command, args);
    }

}