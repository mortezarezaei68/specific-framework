using System;
using System.Threading.Tasks;

namespace Framework.CircuitBreakers
{
    public interface ICircuitBreaker
    {
        void Execute(Action action);
        T Execute<T>(Func<T> func);
        Task ExecuteAsync(Func<Task> func);
    }
}