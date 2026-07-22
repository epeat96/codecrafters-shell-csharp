class Program
{
    static void Main()
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
                
        }while(!Eval(command,args).Equals(EvalCode.Success));
    }

    enum EvalCode
    {
        Success = 0,
        CleanExit = 1,
        Error = 2
    }

    static EvalCode Eval(string command, string[] args) => command switch
    {
       "exit" => Exit(),
       "echo" => Echo(args),
        _ => NotFound(command),
    };

    static EvalCode Exit()
    {
        return EvalCode.Success;
    }

    static EvalCode Echo(string[] args)
    {
        var output = string.Join(" ", args);
        Console.WriteLine(output);
        return EvalCode.CleanExit;
    }
    static EvalCode  NotFound(string command)
    {
        Console.WriteLine($"{command}: command not found");
        return EvalCode.Error;
    }
}
