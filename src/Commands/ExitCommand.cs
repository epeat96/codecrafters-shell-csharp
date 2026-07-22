namespace CodeCrafters.Shell.Commands;

public class ExitCommand : ICommand
{
    public EvalCode Execute(string command, string[] args)
    {
        return EvalCode.CleanExit;
    }
}