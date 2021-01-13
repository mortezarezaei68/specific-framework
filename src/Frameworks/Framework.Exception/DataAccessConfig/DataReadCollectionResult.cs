using System.Collections.Generic;

namespace Framework.Exception.DataAccessConfig
{
    public class DataReadCollectionResult<T>
    {
        private string _message;

        public int TotalCount { get; set; }
        public int Index { get; set; }
        public int Length { get; set; }
        public string SortField { get; set; }
        public SortOrder SortOrder { get; set; }
        public ReadResultStatus Status { get; set; }
        public ICollection<T> Result { get; set; }
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

        public static DataReadCollectionResult<T> SuccessResult(ICollection<T> result)
        {
            return new DataReadCollectionResult<T>()
            {
                Result = result,
                Status = ReadResultStatus.Success
            };
        }

        public static DataReadCollectionResult<T> ExceptionResult(System.Exception exception)
        {
            return new DataReadCollectionResult<T>()
            {
                Exception = exception,
                Status = ReadResultStatus.GeneralException
            };
        }
    }
}