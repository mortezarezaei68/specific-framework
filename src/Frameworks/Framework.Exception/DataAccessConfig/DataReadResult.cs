namespace Framework.Exception.DataAccessConfig
{
    public class DataReadResult<T>
    {
        private string _message;

        public T Result { get; set; }
        public ReadResultStatus Status { get; set; }
        public System.Exception Exception { get; set; }
        public string Message
        {
            get
            {
                return string.IsNullOrWhiteSpace(_message) ? Status.ToDisplay() : _message;
            }
            set
            {
                _message = value;
            }
        }

        public static DataReadResult<T> SuccessResult(T result)
        {
            return new DataReadResult<T>()
            {
                Result = result,
                Status = ReadResultStatus.Success
            };
        }

        public static DataReadResult<T> ExceptionResult(System.Exception exception)
        {
            return new DataReadResult<T>()
            {
                Exception = exception,
                Status = ReadResultStatus.GeneralException
            };
        }
    }
}