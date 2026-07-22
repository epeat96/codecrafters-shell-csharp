class Program
{
    static void Main()
    {
        // TODO: Uncomment the code below to pass the first stage
        var command = "";
        do
        {
            Console.Write("$ ");
            command = Console.ReadLine() ?? "";
        }while(Eval(command) != 0);
    }

    static int Eval(string command)
    {
        if(command.Equals("exit")) 
        {
            return 0;
        }
        Console.WriteLine($"{command}: command not found");
        return 1;
    }
}
