namespace CodeCrafters.Shell;

public static class EvalHelper
{
    public static bool IsExitCode(ResultCode resultCode) => resultCode switch
    {
        ResultCode.CleanExit => true,
        _ => false
    };
}

