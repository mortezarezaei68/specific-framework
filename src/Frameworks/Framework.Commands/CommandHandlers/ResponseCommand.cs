namespace Framework.Commands.CommandHandlers
{
    public class ResponseCommand
    {
        public ResponseCommand( bool isSuccess,string message=null)
        {
            Message = message;
            IsSuccess = isSuccess;
        }
        public bool IsSuccess { get; }
        public string Message { get;  }
    }

    public class ResponseCommand<TResult> : ResponseCommand where TResult:class
    {
        public TResult Data { get;  }

        public ResponseCommand(bool isSuccess, string message = null, TResult data=null) : base(isSuccess, message)
        {
            Data = data;
        }
    }
}