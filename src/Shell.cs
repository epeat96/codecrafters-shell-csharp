using System;
using System.IO;
using System.Reflection;
using CodeCrafters.Shell.Parser;

namespace CodeCrafters.Shell;

public class Shell()
{
    public string Cwd { get; set; } = Directory.GetCurrentDirectory();

    public void Run()
    {
        // TODO: Uncomment the code below to pass the first stage
        var tokens = new List<string>();
        do
        {
            Console.Write("$ ");
            var userInput = Console.ReadLine();
            if (userInput is null)
            {
                Console.WriteLine("Please enter a command.");
                continue;
            }

            var lexer = new Tokenizer(userInput);
            tokens = lexer.Tokenize();
        } while (!EvalHelper.IsExitCode(Eval(tokens)));
    }

    static ResultCode Eval(List<string> tokens)
    {
        var routerResult = CommandsHelper.GetCommand(tokens.First());
        if (routerResult is null)
        {
            var binary = PathHelper.SearchPathForCommand(tokens.First());
            if (binary is not null)
            {
                return ExecutableHelper.Execute(tokens.First(), tokens.Skip(1).ToArray());
            }

            return CommandsHelper.CommandNotFound(tokens.First());
        }

        return routerResult.Execute(tokens.First(), tokens.Skip(1).ToArray());
    }
}