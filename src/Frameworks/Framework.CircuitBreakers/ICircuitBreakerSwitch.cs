using Framework.CircuitBreakers.States;

namespace Framework.CircuitBreakers
{
    internal interface ICircuitBreakerSwitch
    {
        void OpenCircuit(ICircuitBreakerState from);
        void AttemptToCloseCircuit(ICircuitBreakerState from);
        void CloseCircuit(ICircuitBreakerState from);
    }
}