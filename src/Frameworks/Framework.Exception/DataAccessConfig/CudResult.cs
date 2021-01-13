namespace Framework.Exception.DataAccessConfig
{
    public class CudResult
    {
        private string _message;

        public CudResultStatus Status { get; set; }
        public System.Exception Exception { get; set; }
        public string Message
        {
            get => string.IsNullOrWhiteSpace(_message) ? Status.ToDisplay() : _message; 
            set => _message = value;
        }
    }
}