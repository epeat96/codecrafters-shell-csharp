namespace CodeCrafters.Shell;

public static class EvalHelper
{
    public static bool IsExitCode(ResultCode resultCode) => resultCode switch
    {
        ResultCode.Success => false,
        ResultCode.CleanExit => true,
        ResultCode.CommandNotFound => false,
        _ => true
    };
}

