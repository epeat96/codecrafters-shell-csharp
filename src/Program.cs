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
            Console.WriteLine($"{command}: command not found");
        }while(!command.Equals("exit"));
    }
}
