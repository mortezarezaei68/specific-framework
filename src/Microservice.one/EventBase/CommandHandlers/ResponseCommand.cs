using System.Collections.Generic;

namespace Framework.CQRS.MediatRCommands
{
    public class ResponseCommand
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    public class ResponseCommand<TResult> : ResponseCommand
    {
        public TResult Data { get; set; }
        public IEnumerable<TResult> Datas { get; set; }
    }
}