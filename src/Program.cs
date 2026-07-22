using CodeCrafters.Shell;
class Program
{
    private static readonly Shell Shell = new();
    static void Main()
    {
        Shell.Run();
    }

    public static Shell GetShellInstance()
    {
        return Shell;
    } 
    
}
