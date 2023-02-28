using Framework.Exception.DataAccessConfig;

namespace Framework.Exception.Exceptions.Enum;

public class ResponseCommand
{
    protected ResponseCommand(ResultStatus status, object? data)
    {
        Status = status;
        Data = data;
    }

    public object? Data { get;  }

    public ResultStatus Status { get; }

}