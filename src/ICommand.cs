namespace CodeCrafters.Shell;

public interface ICommand
{
   EvalCode Execute(string command, string[] args);
}