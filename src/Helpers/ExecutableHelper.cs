using System;
using System.Diagnostics;

namespace CodeCrafters.Shell;

public class ExecutableHelper
{
    public static ResultCode Execute(string path, string[] args)
    {
        var startInfo = new ProcessStartInfo
        {
            FileName = path,
            UseShellExecute =
                false, // Set to false to run the executable directly (safer and required for redirecting output)
            CreateNoWindow = true // Prevents a new console window from popping up
        };

        args.ToList().ForEach(a => startInfo.ArgumentList.Add(a));

        using var process = new Process();
        process.StartInfo = startInfo;
        process.Start();

        // Halts your C# app's execution on this thread until the target program closes.
        // Omit this ONLY if you explicitly need asynchronous execution.
        process.WaitForExit();

        return ResultCode.Success;
    }
}