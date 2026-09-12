namespace CodeCrafters.Shell;

public interface ICommand
{
   ResultCode Execute(string command, string[] args);
}