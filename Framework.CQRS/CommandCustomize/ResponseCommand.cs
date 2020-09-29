using System.Collections;
using System.Collections.Generic;

namespace Framework.CQRS.CommandCustomize
{
    public class ResponseCommand
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
    public class ResponseCommand<TResult>:ResponseCommand
    {
        public TResult Data { get; set; }
        public IEnumerable<TResult> Datas { get; set; }
        
    }
}